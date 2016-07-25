using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlobController : MonoBehaviour {

	private Rigidbody rb;
	public float sensitivity;
	public GameObject floor;
//	private Camera main_camera;
//	private float cam_distance;

	void Start () {
		rb = GetComponent<Rigidbody> ();
//		main_camera = Camera.main.GetComponent<Camera>();
//		cam_distance = Vector3.Distance (main_camera.transform.position, floor.transform.position);
	}
	
	void FixedUpdate () {

		// Cursor keys and force
//		float haxis = Input.GetAxis ("Horizontal");
//		float vaxis = Input.GetAxis ("Vertical");
//		Vector3 force = new Vector3 (haxis, 0.0f, vaxis);
//		rb.AddForce (force*sensitivity);

		// Pinned to Mouse (also works with touch on mobile)
//		if (Input.GetMouseButton(0)) {
//			Vector3 p = main_camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam_distance));
////			Debug.logger.Log (cam_distance);
//			transform.position = p;
//		} 

		// Accelerate towards mouse
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				print ("Hit something!" + hit.collider.gameObject);	// This gets the walls too though, so lets not bother
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mousePos = new Vector3 (mousePos.x, 0f, mousePos.z);
				Vector3 force = mousePos - transform.position;
				rb.AddForce (force * sensitivity);
			}
		}
	}

	// Note: Targeted on the slider under "dynamic float"
	public void OnSensitivitySliderChange( float sliderVal ) {
		sensitivity = sliderVal;
	}
}
