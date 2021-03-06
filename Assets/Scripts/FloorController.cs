﻿using UnityEngine;
using System.Collections;
using System.IO;

// Attached to floor object
// FreezeImage() called by UI Shutter Button which reads 
// - copies current pixels into texture for floor
// - encodes it as a PNG ready to share
// - Turns of the kaleidoscope 
// - Sets UI to draw mode

// ShareImage() called from UI to share (obs!)

public class FloorController : MonoBehaviour {

	public GameObject kaleido;
	public NativeShare shareScript;
	public UIController ui;

	private Renderer rend;
	private Renderer cursorRenderer;
	private byte[] pngData;

	void Start () {
		rend = GetComponent<Renderer> ();
		cursorRenderer = GameObject.FindGameObjectWithTag ("userInput").GetComponent<Renderer> ();
	}

	public void FreezeImage() {
		cursorRenderer.enabled = false;
		// This is necessary so the capture happens after drawing.
		StartCoroutine (SetTexture ());
	}

	IEnumerator SetTexture() {
		yield return new WaitForEndOfFrame();

		int w = Screen.width;
		int h = Screen.height;

		Texture2D tex = new Texture2D(w, w);
		tex.ReadPixels(new Rect(0, h-w, w, w), 0, 0);
		tex.Apply();
		rend.material.mainTexture = tex;

		pngData = tex.EncodeToPNG ();

		cursorRenderer.enabled = true;
		kaleido.SetActive (false);
		ui.setState ("draw");

		// First run hints...
		if (HintsController.hintState <= 4) {
			HintsController.hintState++;
		}
	}

/**

Sharing. Using:
https://github.com/ChrisMaire/unity-native-sharing

Application.persistentDataPath:
/storage/emulated/0/Android/data/com.kanec.MandalaTest/files/share.jpg

Application.temporaryCachePat
/storage/emulated/0/Android/data/com.kanec.MandalaTest/cache/share.jpg

then there's...
/storage/emulated/0/Pictures/Instagram    etc

Android native:
https://developer.android.com/guide/topics/data/data-storage.html#filesExternal
https://developer.android.com/reference/android/os/Environment.html#getExternalStoragePublicDirectory(java.lang.String)
getExternalStoragePublicDirectory()
https://developer.android.com/reference/android/os/Environment.html#DIRECTORY_PICTURES

actually now it's about FileProvider (no external sd writing)
https://developer.android.com/training/secure-file-sharing/setup-sharing.html

...maybe needs less permissions?

*/

	public void ShareImage() {

		// First run hints...
		if(HintsController.hintState == 4) 
			HintsController.hintState++;

		string filePath = Application.persistentDataPath + "/share.png";
//		Debug.Log("Sharing to: " + filePath);

		File.WriteAllBytes (filePath, pngData);

		shareScript.Share ("#draww", filePath, "");
	}

}
