using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	[Range(0.01f, 0.1f)]
	public float zoomSmoothness = 0.01f;

	[Range(0.5f, 2f)]
	public float zoomAmount = 1f;

	[Range(0.01f, 0.1f)]
	public float moveSmoothness = 0.1f;

	[Range(1f, 30f)]
	public float moveSpeed;

	public float maxZ = -4f;
	public float minZ = -25f;

	public Camera cam;

	private float targetZoom = -10f;
	private float targetX = 0;
	private float targetZ = 0;

	void Awake() {
		cam = Camera.main;
	}

	void Update() {
		CalculateZoom();
		CalculateMovement();
	}

	private void CalculateZoom() {
		if (Input.mouseScrollDelta.y != 0) {
			targetZoom += Input.mouseScrollDelta.y;
			targetZoom = Mathf.Clamp(targetZoom, minZ, maxZ);
		}

		// Move towards targetZoom
		float newZoom = Mathf.Lerp(cam.transform.localPosition.z, targetZoom, zoomSmoothness);
		newZoom = Mathf.Clamp(newZoom, minZ, maxZ);
		cam.transform.localPosition = Util.SetZ(cam.transform.localPosition, newZoom);
	}

	private void CalculateMovement() {
		float dx = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
		float dz = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
		targetX += dx;
		targetZ += dz;

		float newX = Mathf.Lerp(transform.localPosition.x, targetX, moveSmoothness);
		float newZ = Mathf.Lerp(transform.localPosition.z, targetZ, moveSmoothness);
		transform.localPosition = new Vector3(newX, transform.localPosition.y, newZ);
	}

	public void SnapCameraTo(Vector3 location) {
		targetX = location.x;
		targetZ = location.z;
		transform.localPosition = new Vector3(location.x, location.y, location.z);
	}
}
