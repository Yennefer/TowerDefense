using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
	Timer would preform "callback" action 
	with specified in seconds "timePeriod"
	after calling Start() and before Stop() is called
 */
public class Timer : MonoBehaviour {

	private float timePeriod = 0;
	private float timeLeft = 0;
	private UnityAction callback;
	private bool ticking = false;

	public static Timer AddAsComponent(GameObject gameObject, UnityAction callback) {
    	Timer timer = gameObject.AddComponent<Timer>();
    	timer.Init(callback);
    	return timer;
	}

	public void StartTimer(float timePeriod) {
		this.timePeriod = timePeriod;
		this.timeLeft = timePeriod;
		ticking = true;
	}

	public void StopTimer() {
		ticking = false;
	}

	public void RestartTimer(float timePeriod) {
		if (ticking) {
			this.timePeriod = timePeriod;
			this.timeLeft = timePeriod;
		}
	}

	private void Init(UnityAction callback) {
		this.callback = callback;
	}

	public void Update() {
		if (ticking) {
			timeLeft -= Time.deltaTime;
    		if (timeLeft <= 0) {
    			callback();
				timeLeft = timePeriod;
    		}
		}
	}

	public bool IsTicking() {
		return ticking;
	}
}
