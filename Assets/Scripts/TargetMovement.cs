using UnityEngine;
using UnityEngine.AI;

public class TargetMovement : MonoBehaviour {

	private GameObject path;
	private NavMeshAgent agent;

	private void Awake () {
        agent = GetComponent<NavMeshAgent>();

        if (!agent) {
			Debug.LogError("Object with TargetMovement script should have a NavMeshAgent component");
		}
    }

	public void StartPathMovement (GameObject path) {
		agent.enabled = true;
        agent.destination = path.transform.position;
    }
}
