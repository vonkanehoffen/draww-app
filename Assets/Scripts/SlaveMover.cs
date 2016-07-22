using UnityEngine;
using System.Collections;

public class SlaveMover : MonoBehaviour {

	public float angle;
	private GameObject master;

	void Start() {
		master = GameObject.FindGameObjectWithTag ("masterBlob");
	}

	void Update () {
		this.transform.position = master.transform.position;
		this.transform.RotateAround (Vector3.zero, Vector3.up, angle);
	}
}
