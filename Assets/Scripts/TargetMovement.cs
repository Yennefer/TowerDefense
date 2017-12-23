using UnityEngine;
using UnityEngine.AI;

public class TargetMovement : MonoBehaviour {

	private Transform path;
	private NavMeshAgent agent;
	private int currentNode = 0;

	private void Awake () {
        agent = GetComponent<NavMeshAgent>();
        if (!agent) {
			Debug.LogError("Object with TargetMovement script should have a NavMeshAgent component");
		}
    }

	private void Update() {
		if (agent.remainingDistance <= 0.25f) {
			MoveToNode(currentNode++);
		}
	}

	public void StartPathMovement (GameObject path) {
		this.path = path.transform;

		agent.enabled = true;
		MoveToNode(0);
    }

	private void MoveToNode (int nodeIndex) {
		if (nodeIndex < path.childCount) {
			Vector3 nodePosition = path.transform.GetChild(nodeIndex).transform.position;
			nodePosition.y = 0;
			agent.SetDestination( nodePosition );
		} else {
			Destroy(gameObject);
		}
    }
}