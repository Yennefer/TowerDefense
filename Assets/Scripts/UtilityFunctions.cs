using UnityEngine;

public class UtilityFunctions
{
	public static Vector3 RandomizeShot(Transform trans) {
		float rndx = Random.Range(-0.1f, 0.1f);
		float rndz = Random.Range(-0.1f, 0.1f);

		return (trans.forward + new Vector3(rndx, 0, rndz));
	}
}