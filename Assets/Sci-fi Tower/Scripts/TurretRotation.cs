using UnityEngine;

public class TurretRotation : MonoBehaviour
{
	[SerializeField]
	private RotationData yAxisRotation;
	[SerializeField]
	private RotationData xAxisRotation;
	[SerializeField]
	[Range( 0, 180f )]
	private float yAngleToTargetToStartXRotation;
	[SerializeField]
	private Transform target;
	//[SerializeField]
	//[Range( 0f, 360f )]
	//private float rocketsHolderMinAngle;
	//[SerializeField]
	//[Range( 0f, 360f )]
	//private float rocketsHolderMaxAngle;

	private void Awake( )
	{
		yAxisRotation.Init();
		xAxisRotation.Init();
	}

	public bool xPointingActive;
	// Update is called once per frame
	float currentVelocity = 0;
	void Update( )
	{
		if( target != null )
		{
			float timeDelta = Time.deltaTime;
			yAxisRotation.SetTarget( target );
			yAxisRotation.Update( timeDelta, CalculateAngleToLookAtTarget_Y() );

			xPointingActive = yAxisRotation.getCurrentAbsAngle <= yAngleToTargetToStartXRotation;
			if( xPointingActive )
			{
				float angle = Quaternion.LookRotation( ( target.position - xAxisRotation.rotatedTransform.position ).normalized, xAxisRotation.rotatedTransform.up ).eulerAngles.x;
				angle = FixNegativeAngle( angle );
				xAxisRotation.rotatedTransform.localRotation = Quaternion.Lerp( xAxisRotation.rotatedTransform.localRotation, Quaternion.Euler( xAxisRotation.rotationMask * angle ), xAxisRotation.rotationSpeed * timeDelta );
			}
			else
			{
				xAxisRotation.rotatedTransform.localRotation = Quaternion.Lerp( xAxisRotation.rotatedTransform.localRotation, Quaternion.identity, xAxisRotation.rotationSpeed * timeDelta );
			}
		}
	}

	private float FixNegativeAngle(float angle)
	{
		return angle > 0 ? angle : angle + 360f;
	}

	private float Abs(float val)
	{
		return val < 0 ? -val : val;
	}

	private float GetAngleBetween(Vector2 vector1, Vector2 vector2)
	{
		float dot = vector1.x * vector2.x + vector1.y * vector2.y;
		float det = vector1.x * vector2.y - vector1.y * vector2.x;
		return Mathf.Rad2Deg * Mathf.Atan2( det, dot );
	}

	private float CalculateAngleToLookAtTarget_Y( )
	{
		Vector3 targetPos = target.position;
		targetPos.y = targetPos.z;
		Vector3 transfPos = yAxisRotation.rotatedTransform.position;
		transfPos.y = transfPos.z;
		Vector3 forward = yAxisRotation.rotatedTransform.forward;
		forward.y = forward.z;
		return GetAngleBetween( forward, ( targetPos - transfPos ).normalized );
	}



#if UNITY_EDITOR
	[Header( "Editor variables" )]
	[SerializeField]
	private bool drawGizmos_EDITOR;
	[SerializeField]
	private Color gizmosColor;
	[SerializeField]
	private float gizmosSphereRadius = 1f;

	//[SerializeField]
	//private Color rocketsHolderRotationRangeLinesColor;
	[SerializeField]
	private Color angleZoneGizmosColor;
	[SerializeField]
	private float angleZoneGizmosLineWidth = 1f;

	private void OnDrawGizmos( )
	{
		if( drawGizmos_EDITOR && ( target != null && xAxisRotation.rotatedTransform != null ) )
		{
			Vector3 pos = xAxisRotation.rotatedTransform.position;

			Gizmos.color = gizmosColor;
			Gizmos.DrawLine( pos, target.position );
			Gizmos.DrawSphere( target.position, gizmosSphereRadius );
			if( yAxisRotation.rotatedTransform != null )
			{
				Gizmos.color = angleZoneGizmosColor;
				Gizmos.DrawLine( pos, pos + Quaternion.Euler( 0, -yAngleToTargetToStartXRotation, 0 ) * yAxisRotation.rotatedTransform.forward * angleZoneGizmosLineWidth );
				Gizmos.DrawLine( pos, pos + Quaternion.Euler( 0, yAngleToTargetToStartXRotation, 0 ) * yAxisRotation.rotatedTransform.forward * angleZoneGizmosLineWidth );
			}
			//Gizmos.color = rocketsHolderRotationRangeLinesColor;
			//Gizmos.DrawLine( pos, pos + ( Quaternion.Euler( rocketsHolderMinAngle, 0, 0 ) /** xAxisRotation.rotatedTransform.rotation*/ ) * yAxisRotation.rotatedTransform.up * angleZoneGizmosLineWidth );
			//Gizmos.DrawLine( pos, pos + ( Quaternion.Euler( rocketsHolderMaxAngle, 0, 0 ) /** xAxisRotation.rotatedTransform.rotation*/ ) * yAxisRotation.rotatedTransform.up * angleZoneGizmosLineWidth );
		}
	}
#endif
}
