using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public GameObject cell;
	public int width = 10;
	public int height = 10;
	[Range(0f, 1f)]
	public float polePercentage = .1f;
	public GameObject sphere;
	public GameObject grid;
	public Transform cameraAnchor;
	public CameraController cameraController;

	private float xyRadius;
	private float zRadius;

	void Awake() {
		GenerateMap();
		cameraController = Camera.main.transform.parent.GetComponent<CameraController>();
		cameraController.SnapCameraTo(new Vector3(xyRadius / 2, xyRadius, zRadius / 2));
	}

	void GenerateMap() {
		sphere = Instantiate(sphere);
		if (height <= 0) {
			height = Mathf.FloorToInt((width * 0.577f + 1));
		}
		xyRadius = width * 0.5f * Mathf.Cos(Mathf.PI/6);
		zRadius = 0.75f * height + 0.25f;
		height = Mathf.FloorToInt((width * 0.577f + 1) * (1f - polePercentage));
		
		sphere.transform.localScale = new Vector3(xyRadius * 2, xyRadius * 2, zRadius * 2);

		if (cell != null) {
			grid = new GameObject("Grid");
			float dx = 2 * Mathf.Cos(Mathf.PI/6);
			float dz = 1.5f;
			float m = dz / dx;

			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {
					float x = i * dx + (j % 2) * m;
					float z = j * dz;
					Vector3 pos = new Vector3(x, 0, z);
					Instantiate(cell, pos, Quaternion.identity, grid.transform);
				}
			}
		}
	}

	void Update() {
		if (grid != null) {
			Vector3 sphereCenter = cameraAnchor.localPosition - new Vector3(0, xyRadius, 0);
			sphere.transform.localPosition = sphereCenter;
			foreach (Transform cell in grid.transform) {
				Vector3 cellCenter = cell.localPosition;
				// Calculations to keep cells close
				if (cellCenter.x - cameraAnchor.localPosition.x < -xyRadius * 2) {
					cell.localPosition = Util.SetX(cellCenter, cellCenter.x + xyRadius * 4);
				}
				if (cellCenter.x - cameraAnchor.localPosition.x > xyRadius * 2) {
					cell.localPosition = Util.SetX(cellCenter, cellCenter.x - xyRadius * 4);
				}

				// Calculations for oblate spheroid
				float dx = cellCenter.x - sphereCenter.x;
				float dz = cellCenter.z - sphereCenter.z;
				float radicand = (xyRadius * xyRadius * zRadius * zRadius - xyRadius * xyRadius * dz * dz) / (zRadius * zRadius) - dx * dx;
				MeshRenderer mr = cell.GetComponentInChildren<MeshRenderer>();
				if (mr == null) continue;
				if (radicand < 0) {	
					cell.GetComponentInChildren<MeshRenderer>().enabled = false;
					// cell.localPosition = Util.SetY(cell.localPosition, 0);
				} else {
					cell.GetComponentInChildren<MeshRenderer>().enabled = true;
					cell.localPosition = Util.SetY(cell.localPosition, Mathf.Sqrt(radicand));
					Vector3 directionToCenter = sphereCenter - cellCenter;
					cell.localRotation = Quaternion.FromToRotation(Vector3.down, directionToCenter);
				}
			}
		}
	}
}
