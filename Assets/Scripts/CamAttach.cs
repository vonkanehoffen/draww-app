using UnityEngine;
using System.Collections;

public class CamAttach : MonoBehaviour {

	// NatCam? https://www.assetstore.unity3d.com/en/#!/content/52154
	// http://forum.unity3d.com/threads/webcamtexture-issue.392993/

	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}

	// Update is called once per frame
	void Update () {

	}
}
