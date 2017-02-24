using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Attached to User Input Object
// Moves it according to touch input
// Note: brush prefabs look to this object to get ther positions.

public class UserInputController : MonoBehaviour {

	private Rigidbody rb;
	public float sensitivity;
	public GameObject floor;
	private Collider floorCollider;
//	private Camera main_camera;
//	private float cam_distance;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		floorCollider = floor.GetComponent<Collider> ();
//		main_camera = Camera.main.GetComponent<Camera>();
//		cam_distance = Vector3.Distance (main_camera.transform.position, floor.transform.position);
	}
	
	void FixedUpdate () {

		// Accelerate towards mouse
//		if (Input.GetMouseButton (0)) {
//			
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//
//			if (floorCollider.Raycast (ray, out hit, 100)) {
//				
//				Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				mousePos = new Vector3 (mousePos.x, 0f, mousePos.z);
//				Vector3 force = mousePos - transform.position;
//				rb.AddForce (force * sensitivity);
//
//			}
//		}

		// Accelerate on touch swipe
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			Vector3 force = new Vector3 (touchDeltaPosition.x, 0f, touchDeltaPosition.y);
			rb.AddForce (force * sensitivity);
		}

	}

	// Note: Targeted on the slider under "dynamic float"
	public void OnSensitivitySliderChange( float sliderVal ) {
		sensitivity = sliderVal;
	}
}
