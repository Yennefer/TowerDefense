using UnityEngine;
using UnityEngine.Events;

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

	private void Update() {
		if (ticking) {
			timeLeft -= Time.deltaTime;
    		if (timeLeft <= 0) {
    			callback();
				timeLeft = timePeriod;
    		}
		}
	}

	private bool IsTicking() {
		return ticking;
	}
}
