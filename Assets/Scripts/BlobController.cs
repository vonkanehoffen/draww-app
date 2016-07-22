using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour {

//	private Rigidbody rb;
	public float sensitivity;
	public float speed;

	void Start () {
//		rb = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {

//		float haxis = Input.GetAxis ("Horizontal");
//		float vaxis = Input.GetAxis ("Vertical");
//		Vector3 force = new Vector3 (haxis, 0.0f, vaxis);
//		rb.AddForce (force*sensitivity);

		Camera camera = Camera.main.GetComponent<Camera>();
		// 20f = distance of camera from floor
		Vector3 p = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f ));
		Debug.logger.Log (p);
		transform.position = p;
	}
}
