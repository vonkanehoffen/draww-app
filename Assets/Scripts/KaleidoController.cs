using UnityEngine;
using System.Collections;

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

	void Update () {
//		foreach (GameObject face in faces) {
//			Renderer renderer = face.GetComponent<Renderer> ();
//			renderer.material.mainTextureScale = new Vector2 (textureScale, textureScale);
//		}
	}

	// Not used any more? UI controller instead.
	public void ToggleKaleido() {
		if (gameObject.activeSelf) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive (true);
		}
	}
}
