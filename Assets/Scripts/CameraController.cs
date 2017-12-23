using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera cam;
	private float camSpd = 0.5f;
	private float accFactor = 3.0f;

	private void Start()
	{
		cam = GetComponent<Camera>();
	}

	private void Update()
	{
		if (Input.GetMouseButton(1)) 
		{
			float y = Input.GetAxis("Mouse X");
			float x = Input.GetAxis("Mouse Y");
			Vector3 rotation = new Vector3(x, -y, 0);
			transform.eulerAngles = transform.eulerAngles - rotation;
		}

		if (Input.GetKey(KeyCode.A))
		{
			cam.transform.Translate(Vector3.forward * camSpd, Space.World);
		}

		if (Input.GetKey(KeyCode.D))
		{
			cam.transform.Translate(Vector3.back * camSpd, Space.World);
		}

		if (Input.GetKey(KeyCode.W))
		{
			cam.transform.Translate(Vector3.right * camSpd, Space.World);
		}

		if (Input.GetKey(KeyCode.S))
		{
			cam.transform.Translate(Vector3.left * camSpd, Space.World);
		}

		if (Input.GetKey(KeyCode.Q))
		{
			cam.transform.Translate(Vector3.down * camSpd);
		}

		if (Input.GetKey(KeyCode.E))
		{
			cam.transform.Translate(Vector3.up * camSpd);
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			cam.transform.Translate(Vector3.forward * camSpd);
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			cam.transform.Translate(Vector3.back * camSpd);
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			camSpd *= accFactor;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			camSpd /= accFactor;
		}
	}
}
