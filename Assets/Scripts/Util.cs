using UnityEngine;

public class Util {
	public static float DistanceSquared(Vector3 a, Vector3 b) {
		float dx = a.x - b.x;
		float dy = a.y - b.y;
		float dz = a.z - b.z;
		return dx * dx + dy * dy + dz * dz;
	}

	public static float DistanceIgnoreY(Vector3 a, Vector3 b) {
		return Mathf.Sqrt(DistanceSquaredIgnoreY(a, b));
	}

	public static float DistanceSquaredIgnoreY(Vector3 a, Vector3 b) {
		float dx = a.x - b.x;
		float dz = a.z - b.z;
		return dx * dx + dz * dz;
	}

	public static Vector3 SetX(Vector3 vec, float x) {
		vec.Set(x, vec.y, vec.z);
		return vec;
	}

	public static Vector3 SetY(Vector3 vec, float y) {
		vec.Set(vec.x, y, vec.z);
		return vec;
	}

	public static Vector3 SetZ(Vector3 vec, float z) {
		vec.Set(vec.x, vec.y, z);
		return vec;
	}
}
