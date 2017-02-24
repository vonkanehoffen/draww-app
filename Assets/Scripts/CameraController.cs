using UnityEngine;
using System.Collections;

// Attached to Main Camera
// Pans and Zooms cam to show draw area full screen.

public class CameraController : MonoBehaviour {

	public GameObject floorObject;

	// Use this for initialization
	void Start () {
		Vector3 floorSize = floorObject.GetComponent<Renderer> ().bounds.size;
		float aspect = Camera.main.aspect;
		float zoomedOrthoSize = (floorSize.x / 2) / aspect;

		Camera.main.orthographicSize = zoomedOrthoSize;

		// Pan camera to top edge of floor
		float camZ = -( (zoomedOrthoSize*2) - floorSize.z ) / 2;
		Vector3 cp = Camera.main.transform.position;
		Camera.main.transform.position = new Vector3 (cp.x, cp.y, camZ);
	}

}
