using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PathMovement : MonoBehaviour {

	private Transform path;
	private NavMeshAgent agent;
	private int currentNode = 0;
	private UnityAction pathEndedListener;
	private bool stop = false;

	private void Awake () {
        agent = GetComponent<NavMeshAgent>();
        if (!agent) {
			Debug.LogError("Object with TargetMovement script should have a NavMeshAgent component");
		}
    }

	private void Update() {
		if (agent.remainingDistance <= 0.25f && !stop) {
			MoveToNode(currentNode++);
		}
	}

	public void StartPathMovement (GameObject path, UnityAction onPathEndedListener) {
		this.path = path.transform;
		this.pathEndedListener = onPathEndedListener;

		agent.enabled = true;
		MoveToNode(0);
    }

	private void MoveToNode (int nodeIndex) {
		if (nodeIndex < path.childCount) {
			Vector3 nodePosition = path.transform.GetChild(nodeIndex).transform.position;
			nodePosition.y = 0;
			agent.SetDestination( nodePosition );
		} else {
			pathEndedListener.Invoke();
			stop = true;
		}
    }
}