using UnityEngine;
using System.Collections;

public class Kaleidoscope : MonoBehaviour {

	void Start() {
//		Mesh mesh = new Mesh();
//		GetComponent<MeshFilter>().mesh = mesh;
//		mesh.vertices = newVertices;
//		mesh.uv = newUV;
//		mesh.triangles = newTriangles;
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = new Vector3[] {new Vector3(0, 0.5f, 0), new Vector3(0, 0.5f, 1), new Vector3(1, 0.5f, 1)};
		mesh.uv = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1)};
		mesh.triangles = new int[] {0, 1, 2};
	}

}
