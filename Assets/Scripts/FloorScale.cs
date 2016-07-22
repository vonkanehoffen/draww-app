using UnityEngine;
using System.Collections;

public class FloorScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera main_camera = Camera.main.GetComponent<Camera>();
//		float screen_width = main_camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0.0f, 0.0f)).x;
//		Debug.Log (Screen.width);
//		this.transform.localScale = new Vector3 (screen_width, 1.0f, screen_width);
		Debug.Log(Camera.main.orthographicSize);
		Debug.Log(Camera.main.aspect);
		float height = Camera.main.orthographicSize * 2;
		float width = height * Camera.main.aspect;
		gameObject.transform.localScale = new Vector3 (width/10, 1.0f, width/10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
