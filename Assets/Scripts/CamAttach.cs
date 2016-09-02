using UnityEngine;
using System.Collections;

public class CamAttach : MonoBehaviour {

	public GameObject[] faces;
	public float textureScale;

	// NatCam? https://www.assetstore.unity3d.com/en/#!/content/52154
	// http://forum.unity3d.com/threads/webcamtexture-issue.392993/

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

}
