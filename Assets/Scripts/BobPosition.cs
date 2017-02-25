using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobPosition : MonoBehaviour {

	public float Frequency;
	public float Amplitude;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset = new Vector3 (0, Mathf.Sin(Time.time*Frequency)*Amplitude, 0);
		transform.position = startPos+offset;
	}
}
