using UnityEngine;
using System.Collections;

public class BrushMover : MonoBehaviour {

	public float angle;
	private GameObject master;

	void Start() {
		master = GameObject.FindGameObjectWithTag ("userInput");
	}

	void Update () {
		this.transform.position = master.transform.position;
		this.transform.RotateAround (Vector3.zero, Vector3.up, angle);
	}
}
