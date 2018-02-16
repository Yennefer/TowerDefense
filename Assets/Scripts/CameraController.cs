using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Terrain trn;
	private float camSpd = 0.5f;
	private float accFactor = 3.0f;
	private float scaleSpdFactor = 8.0f;
	private bool _active = false;

	public bool active {
		get { return _active; }
		set { _active = value; }
	}

	private void Start()
	{
		trn = GameObject.FindObjectOfType<Terrain>();
	}

	private void Update()
	{
		if (!active) {
			return;
		}
		
		if (Input.GetMouseButton(1)) 
		{
			float y = Input.GetAxis("Mouse X");
			float x = Input.GetAxis("Mouse Y");
			Vector3 rotation = new Vector3(x, -y, 0);
			transform.eulerAngles = transform.eulerAngles - rotation;
		}

		if (Input.GetKey(KeyCode.A) && transform.position.z <= trn.terrainData.size.z/2)
		{
			transform.Translate(Vector3.left * camSpd, Space.Self);
		}

		if (Input.GetKey(KeyCode.D) && -transform.position.z <= trn.terrainData.size.z/2)
		{
			transform.Translate(Vector3.right * camSpd, Space.Self);
		}

		if (Input.GetKey(KeyCode.W) && transform.position.x <= trn.terrainData.size.x/2)
		{
			transform.Translate(Vector3.forward * camSpd, Space.Self);
		}

		if (Input.GetKey(KeyCode.S) && -transform.position.x <= trn.terrainData.size.x/2)
		{
			transform.Translate(Vector3.back * camSpd, Space.Self);
		}

		if (Input.GetKey(KeyCode.Q) && transform.position.y >= 0)
		{
			transform.Translate(Vector3.down * camSpd);
		}

		if (Input.GetKey(KeyCode.E) && transform.position.y <= trn.terrainData.size.x/4)
		{
			transform.Translate(Vector3.up * camSpd);
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			transform.Translate(Vector3.forward * camSpd * scaleSpdFactor);
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			transform.Translate(Vector3.back * camSpd * scaleSpdFactor);
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
