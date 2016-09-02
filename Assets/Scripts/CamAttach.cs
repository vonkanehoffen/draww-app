using UnityEngine;
using System.Collections;

public class CamAttach : MonoBehaviour {

	public GameObject target1;
	public GameObject target2;

	// NatCam? https://www.assetstore.unity3d.com/en/#!/content/52154
	// http://forum.unity3d.com/threads/webcamtexture-issue.392993/

	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		Renderer renderer1 = target1.GetComponent<Renderer>();
		Renderer renderer2 = target2.GetComponent<Renderer>();
		renderer1.material.mainTexture = webcamTexture;
		renderer2.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}

	// Update is called once per frame
	void Update () {

	}
}
