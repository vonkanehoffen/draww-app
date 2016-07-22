using UnityEngine;
using System.Collections;

public class SlaveSpawner : MonoBehaviour {

	public GameObject slave;
	public int numberOfSlaves = 16;
	public float radius = 2f;

	// https://docs.unity3d.com/Manual/InstantiatingPrefabs.html

	void Start () {
//		for (int y = 0; y < 5; y++) {
//			for (int x = 0; x < 5; x++) {
//				Instantiate(slave, new Vector3(x, y, 0), Quaternion.identity);
//			}
//		}
		for (int i = 0; i < numberOfSlaves; i++) {
			float angle = i * Mathf.PI * 2 / numberOfSlaves;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0.25f, Mathf.Sin(angle)) * radius;
			GameObject clone = (GameObject)Instantiate(slave, pos, Quaternion.identity);
			SlaveMover cloneMover = clone.GetComponent<SlaveMover> ();
			cloneMover.angle = angle * Mathf.Rad2Deg;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
