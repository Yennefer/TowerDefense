using UnityEngine;

public class CameraController : MonoBehaviour {
 
    private void Update() {
		    if (Input.GetMouseButton(1)) {
            float y = Input.GetAxis("Mouse X");
        	  float x = Input.GetAxis("Mouse Y");
        	  Vector3 rotation = new Vector3(x, -y, 0);
        	  transform.eulerAngles = transform.eulerAngles - rotation;
			  }
    }
}
