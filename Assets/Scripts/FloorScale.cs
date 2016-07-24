using UnityEngine;
using System.Collections;

public class FloorScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Camera main_camera = Camera.main.GetComponent<Camera>();

//		Debug.Log("Ortho size: " + Camera.main.orthographicSize);
//		Debug.Log("Aspect: " + Camera.main.aspect);
//		Debug.Log ("Floor original localScale: " + transform.localScale);

		// Scale floor to camera's ortho width
//		float height = Camera.main.orthographicSize * 2;
//		float width = height * Camera.main.aspect;
//		transform.localScale = new Vector3 (width/10, 1.0f, width/10);
//		Debug.Log ("Floor new localScale: " + transform.localScale);
//
//		// Try and fail to move floor up to top of cam box 
//		Vector3 floorSize = GetComponent<Renderer> ().bounds.size;
//		Debug.Log ("Size: " + floorSize);
//		transform.position = new Vector3 (0f, 0f, floorSize.z/2);

//		Camera.main.orthographicSize = 30;

		Vector3 floorSize = GetComponent<Renderer> ().bounds.size;
		float orthoSize = Camera.main.orthographicSize;
		float aspect = Camera.main.aspect;
		float zoomedOrthoSize = (floorSize.x / 2) / aspect;

		Debug.Log ("floor size: " + floorSize);
		Debug.Log ("Ortho size: " + Camera.main.orthographicSize);
		Debug.Log ("Aspect: " + Camera.main.aspect);
		Debug.Log ("Zoomed ortho size: " + zoomedOrthoSize);

		Camera.main.orthographicSize = zoomedOrthoSize;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
