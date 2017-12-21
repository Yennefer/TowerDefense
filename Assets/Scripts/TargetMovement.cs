﻿using UnityEngine;
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

	void OnDrawGizmosSelected()
	{
		if (agent == null || agent.path == null) {
			return;
		}
		for (int i = 0; i < agent.path.corners.Length - 1; i++)
		{
			Gizmos.DrawLine (agent.path.corners [i], agent.path.corners [i + 1]);
		}

	}
}
