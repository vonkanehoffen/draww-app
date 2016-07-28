using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {

	private Renderer rend;

	void Start () {
		rend = GetComponent<Renderer> ();
	}

	public void FreezeImage() {
		// TRhis is necessary so the capture happens after drawing.
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
	}

}
