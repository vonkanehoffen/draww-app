using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour {

//	private Rigidbody rb;
	public float sensitivity;
	public float speed;
	public GameObject floor;
	private Camera main_camera;
	private float cam_distance;

	void Start () {
//		rb = GetComponent<Rigidbody> ();
		main_camera = Camera.main.GetComponent<Camera>();
		cam_distance = Vector3.Distance (main_camera.transform.position, floor.transform.position);
//		Debug.Log ("got cam distance");
	}
	
	void FixedUpdate () {

		// Cursor keys and force
//		float haxis = Input.GetAxis ("Horizontal");
//		float vaxis = Input.GetAxis ("Vertical");
//		Vector3 force = new Vector3 (haxis, 0.0f, vaxis);
//		rb.AddForce (force*sensitivity);

		// Pinned to Mouse (also works with touch on mobile)
		if (Input.GetMouseButton(0)) {
			Vector3 p = main_camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam_distance));
//			Debug.logger.Log (cam_distance);
			transform.position = p;
		} 
	}
}
