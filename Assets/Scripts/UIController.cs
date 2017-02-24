using UnityEngine;
using System.Collections;

// Attached to UI Canvas
// Called from UI draw/kaleido buttons + floor controller.
// Switches UI mode between kaleidoscope or drawing by showing / hiding elements

public class UIController : MonoBehaviour {

	private string uiState;
	public GameObject drawButton;
	public GameObject kaleidoButton;
	public GameObject colorToggle;
	public GameObject kaleido;

	// Use this for initialization
	void Start () {
		uiState = "kaleido";
	}

	public void setState (string state) {
		uiState = state;
//		Debug.Log (uiState);
		switch (uiState) {
		case "kaleido":
			drawButton.SetActive (true);
			kaleidoButton.SetActive (false);
			colorToggle.SetActive (false);
			kaleido.SetActive (true);
			break;
		case "draw":
			drawButton.SetActive (false);
			kaleidoButton.SetActive (true);
			colorToggle.SetActive (true);
			kaleido.SetActive (false);
			break;
		default:
			Debug.Log ("Invalid state");
			break;
		}
	}

}
