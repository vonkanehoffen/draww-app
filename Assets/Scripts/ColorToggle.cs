using UnityEngine;
using System.Collections;

public class ColorToggle : MonoBehaviour {

	public Material trailMaterial;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateColor( string color ) {
		Debug.Log ("Color: "+color);
//		trailMaterial.mainTexture = color;
	}
}
