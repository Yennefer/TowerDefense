using UnityEngine;
using UnityEngine.AI;

public class TargetMovement : MonoBehaviour {

	[SerializeField]
	private Transform target;

	private NavMeshAgent agent;

	private void Awake () {
        agent = GetComponent<NavMeshAgent>();

        if (!agent) {
			Debug.LogError("Object with TargetMovement script should have a NavMeshAgent component");
		}
    }

    private void Start () {
		agent.enabled = true;
        agent.destination = target.position;
    }
}
