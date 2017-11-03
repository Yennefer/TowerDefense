using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RotationData
{
	public Transform		rotatedTransform;
	public float			rotationSpeed;
	public float			minAngleToStopRotating;
	//public Vector3			forwardVector = Vector3.up;
	public Vector3			rotationMask;

	private Transform		target;
	private bool			lookAtTarget;
	private float			angle;

	public float getCurrentAbsAngle
	{
		get
		{
			return Abs( angle );
		}
	}

	public void Init( )
	{
		//forwardVector = rotatedTransform.forward;
	}

	public void SetTarget(Transform targetTransf)
	{
		target = targetTransf;
		lookAtTarget = true;
	}

	private void CalculateAngleToLookAtTarget( )
	{
		Vector3 targetPos = target.position;
		targetPos.y = targetPos.z;
		Vector3 transfPos = rotatedTransform.position;
		transfPos.y = transfPos.z;
		Vector3 forward = rotatedTransform.forward;
		forward.y = forward.z;
		angle = GetAngleBetween( forward, ( targetPos - transfPos ).normalized );
	}

	public float GetAngleBetween(Vector2 vector1, Vector2 vector2)
	{
		float dot = vector1.x * vector2.x + vector1.y * vector2.y;
		float det = vector1.x * vector2.y - vector1.y * vector2.x;
		return Mathf.Rad2Deg * Mathf.Atan2( det, dot );
	}

	private float Abs( float val )
	{
		return val < 0 ? -val : val;
	}

	// Update is called once per frame
	public void Update( float timeDelta, float angle )
	{
		if( lookAtTarget )
		{
			this.angle = angle;
			//CalculateAngleToLookAtTarget();
			if( Abs( angle ) >= minAngleToStopRotating )
			{
				rotatedTransform.Rotate( rotationMask * ( rotationSpeed * timeDelta * Mathf.Sign( angle ) ) );
			}
		}

	}
}
