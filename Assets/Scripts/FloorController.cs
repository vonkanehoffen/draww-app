using UnityEngine;
using System.Collections;
using System.IO;

public class FloorController : MonoBehaviour {

	public GameObject kaleido;

	private Renderer rend;
	private Renderer cursorRenderer;
	private byte[] jpgData;

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

		jpgData = tex.EncodeToJPG (90);

		cursorRenderer.enabled = true;
		kaleido.SetActive (false);

	}

/**
Use native OS sharing stuff.
For iOS?: http://x-team.com/2014/06/unity-instagram-sharing/

Android for now though
http://www.daniel4d.com/blog/sharing-image-unity-android/
http://docs.unity3d.com/ScriptReference/AndroidJavaClass.html
https://developer.android.com/training/sharing/shareaction.html
...or is this classed as a file?

adb logcat

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

Paid plugin?
https://www.assetstore.unity3d.com/en/#!/content/58972
UniShare

or free: 
Cross Platform Native Plugins - Lite Version
https://www.assetstore.unity3d.com/en/#!/content/37272

*/

	public void ShareImage() {
//		string filePath = Application.persistentDataPath + "/share.jpg";
		string filePath = "/storage/emulated/0/Pictures/mandala_share.jpg";
		Debug.Log("Sharing to: " + filePath);

		File.WriteAllBytes (filePath, jpgData);

		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");

		//instantiate the object Uri with the parse of the url's file
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse",filePath);

		//call putExtra with the uri object of the file
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

		//set the type of file
		intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");

		//instantiate the class UnityPlayer
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		//instantiate the object currentActivity
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

		//call the activity with our Intent
		currentActivity.Call("startActivity", intentObject);
	}

}
