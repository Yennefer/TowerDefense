using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

	public float moveSpeed;
	public float rotationSpeed;
	private Transform transf;

	// Use this for initialization
	void Start ()
	{
		transf = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontalAxis = Input.GetAxis("Horizontal");
		float verticalAxis = Input.GetAxis( "Vertical" );
		float timeDelta = Time.deltaTime;

		float yMovement = 0;
		if( Input.GetKey( KeyCode.Q ) )
		{
			yMovement = 1f;
		}
		else if( Input.GetKey( KeyCode.E ) )
		{
			yMovement = -1f;
		}

		transf.Rotate(Vector3.up, horizontalAxis * ( rotationSpeed  * timeDelta ) );
		Vector3 forward = transf.forward * verticalAxis;
		forward.y = yMovement;
		transf.position += forward * ( moveSpeed * timeDelta );
	}
}
