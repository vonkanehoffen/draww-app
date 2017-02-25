using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shows and hides hint labels

public class HintsController : MonoBehaviour {

	private int oldHintState;
	public static int hintState = 0; // Static vars are per clas, not per instance of class.
	public GameObject step1;
	public GameObject step2;
	public GameObject step3;
	public GameObject step4;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();
		hintState = PlayerPrefs.GetInt("hintState", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if(hintState != oldHintState) {
			Debug.Log("changed hint");
			PlayerPrefs.SetInt ("hintState", hintState);
			step1.SetActive (false);
			step2.SetActive (false);
			step3.SetActive (false);
			step4.SetActive (false);
			switch (hintState) {
				case 1:
					step1.SetActive (true);
					break;
				case 2:
					step2.SetActive (true);
					break;
				case 3:
					step3.SetActive (true);
					break;
				case 4:
					step4.SetActive (true);
					break;
			}
			oldHintState = hintState;
		}
	}
}
