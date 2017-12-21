using UnityEngine;

public class ChangeTurretMaterial : MonoBehaviour {
#if UNITY_EDITOR

	public Material newMaterial;
	public bool change;
	private void OnDrawGizmosSelected( )
	{
		if( change )
		{
			change = false;
			MeshRenderer[ ] renderers = GetComponentsInChildren<MeshRenderer>();
			for( int i = 0; i < renderers.Length; i++ )
			{
				renderers[i].sharedMaterial = newMaterial;
			}
		}
	}
#endif
}
