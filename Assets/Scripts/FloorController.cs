using UnityEngine;
using System.Collections;
using System.IO;

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
		string filePath = Application.persistentDataPath + "/share.png";
		Debug.Log("Sharing to: " + filePath);

		File.WriteAllBytes (filePath, pngData);

		shareScript.Share ("#draww", filePath, "");
	}

}
