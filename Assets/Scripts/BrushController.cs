using UnityEngine;
using System.Collections;

// Attached to empty object.
// - `changeBrush` method called from 'Colour Toggle' UI which...
// - Instantiates circle of appropriate colour prefab brush objects
// - Sets `angle` property of their `BrushMover` scripts 

public class BrushController : MonoBehaviour {

	// Brushes
	public GameObject redTrail;
	public GameObject greenTrail;
	public GameObject blueTrail;
	public GameObject orangeTrail;
	public GameObject stripesTrail;

	public int numberOfSlaves = 16;
	public float radius = 2f;
	private string currentBrush;

	void Start () {
		instantiateBrushes (redTrail);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void instantiateBrushes( GameObject brush ) {
		for (int i = 0; i < numberOfSlaves; i++) {
			float angle = i * Mathf.PI * 2 / numberOfSlaves;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0.25f, Mathf.Sin(angle)) * radius;
			GameObject clone = (GameObject)Instantiate(brush, pos, Quaternion.identity);
			BrushMover cloneMover = clone.GetComponent<BrushMover> ();
			cloneMover.angle = angle * Mathf.Rad2Deg;
		}
	}

	void destroyBrushes() {
		GameObject[] brushes = GameObject.FindGameObjectsWithTag ("brush");
		foreach (GameObject brush in brushes) {
			Destroy (brush);
		}
	}

	public void changeBrush (string brushName) {
//		if (brushName != currentBrush) {
			destroyBrushes ();
			switch (brushName) {
				case "redTrail":
					instantiateBrushes (redTrail);
					break;
				case "greenTrail":
					instantiateBrushes (greenTrail);
					break;
				case "blueTrail":
					instantiateBrushes (blueTrail);
					break;
				case "orangeTrail":
					instantiateBrushes (orangeTrail);
					break;
				case "stripesTrail":
					instantiateBrushes (stripesTrail);
					break;
				default:
					Debug.Log ("Unknown brush: " + brushName);
					break;
			}
//		}

//		Debug.Log ("changeBrush: " + brushName);

	}
}
