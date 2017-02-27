using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shows and hides hint labels

public class HintsController : MonoBehaviour {
	
	private static int hintsShown;
	private static int oldHintState = 0;
	public static int hintState = 1; // Static vars are per class, not per instance of class.
	public GameObject step1;
	public GameObject step2;
	public GameObject step3;
	public GameObject step4;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();
		hintsShown = PlayerPrefs.GetInt("hintsShown", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(hintState != oldHintState) {
			step1.SetActive (false);
			step2.SetActive (false);
			step3.SetActive (false);
			step4.SetActive (false);
			if(hintsShown != 1) {
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
				case 5:
					hintsShown = 1;
					PlayerPrefs.SetInt ("hintsShown", 1);
					break;
				}
			}
			oldHintState = hintState;
		}
	}
}
