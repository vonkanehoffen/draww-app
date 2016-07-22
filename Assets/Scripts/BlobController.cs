using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour {

	private Rigidbody rb;
	public float sensitivity;
//	public GameObject slave;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float haxis = Input.GetAxis ("Horizontal");
		float vaxis = Input.GetAxis ("Vertical");
		Vector3 force = new Vector3 (haxis, 0.0f, vaxis);
		rb.AddForce (force*sensitivity);
	}
	void Update() {
//		slave.transform.position = this.transform.position;
//		slave.transform.RotateAround (Vector3.zero, Vector3.up, 90.0f);
	}
}
