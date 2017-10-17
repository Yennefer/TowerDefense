using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetMovement : MonoBehaviour {

	[SerializeField]
	private Transform target;
	private NavMeshAgent agent;

	void Awake () {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start () {
    	agent.destination = target.position; 
    }
}
