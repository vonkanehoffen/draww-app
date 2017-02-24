using UnityEngine;
using System.Collections;

// Attached to Kaleidoscope parent object
// Sets webcam texture on all triangles.

public class KaleidoController : MonoBehaviour {

	public GameObject[] faces;
	public float textureScale;

	// NatCam? https://www.assetstore.unity3d.com/en/#!/content/52154

	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		foreach (GameObject face in faces) {
			Renderer renderer = face.GetComponent<Renderer> ();
			renderer.material.mainTexture = webcamTexture;
			renderer.material.mainTextureScale = new Vector2 (textureScale, textureScale);
		}
		webcamTexture.Play();
	}

}
