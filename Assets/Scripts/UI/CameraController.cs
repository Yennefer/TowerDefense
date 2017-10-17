using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private float x;
    private float y;
    private Vector3 rotateValue;
 
    void Update()
    {
		if (Input.GetMouseButton(1)) 
		{
        	y = Input.GetAxis("Mouse X");
        	x = Input.GetAxis("Mouse Y");
        	rotateValue = new Vector3(x, -y, 0);
        	transform.eulerAngles = transform.eulerAngles - rotateValue;
		}
    }
}
