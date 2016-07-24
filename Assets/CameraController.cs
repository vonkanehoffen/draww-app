using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject floorObject;

	// Use this for initialization
	void Start () {
		Vector3 floorSize = floorObject.GetComponent<Renderer> ().bounds.size;
		float orthoSize = Camera.main.orthographicSize;
		float aspect = Camera.main.aspect;
		float zoomedOrthoSize = (floorSize.x / 2) / aspect;

		Debug.Log ("floor size: " + floorSize);
		Debug.Log ("Ortho size: " + Camera.main.orthographicSize);
		Debug.Log ("Aspect: " + Camera.main.aspect);
		Debug.Log ("Zoomed ortho size: " + zoomedOrthoSize);

		Camera.main.orthographicSize = zoomedOrthoSize;

		// Pan camera to top edge of floor
		float camZ = -( (zoomedOrthoSize*2) - floorSize.z ) / 2;
		Vector3 cp = Camera.main.transform.position;
		Camera.main.transform.position = new Vector3 (cp.x, cp.y, camZ);
	}

}
