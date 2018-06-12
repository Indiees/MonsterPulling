using System;
using UnityEngine;

public class Tween {
	#region Class members
	public TweenState state;

	private float startValue;
	private float endValue;
	private float currentTime;
	private Func<float, float> easing;

	private Action<Tween> progressCallback;
	private Action<Tween> finishCallback;
	#endregion

	#region Class accesors
	public GameObject reference { get; private set; }
	public string identifier { get; private set; }
	public bool useUnscaledTime { get; private set; }
	public float duration { get; set; }
	public float value { get; private set; }
	public float progress { get; private set; }
	#endregion

	#region Class implementation
	public Tween (GameObject reference, string identifier, bool useUnscaledTime, float start, float end, float duration, Func<float, float> easing, Action<Tween> progress, Action<Tween> finish) {
		this.reference = reference;
		this.identifier = identifier;
		this.useUnscaledTime = useUnscaledTime;
		this.startValue = start;
		this.endValue = end;
		this.duration = duration;
		this.easing = easing;
		progressCallback = progress;
		finishCallback = finish;

		currentTime = 0;
		UpdateValue ();
	}

	public void Pause () {
		if (state == TweenState.Running)
			state = TweenState.Paused;
	}

	public void Resume () {
		if (state == TweenState.Paused)
			state = TweenState.Running;
	}

	public void Stop (TweenStopState stopState) {
		if (state != TweenState.Stopped) {
			state = TweenState.Stopped;

			if (stopState == TweenStopState.Complete) {
				currentTime = duration;
				UpdateValue ();

				if (finishCallback != null) {
					finishCallback.Invoke (this);
					finishCallback = null;
				}
			}
		}
	}

	public bool Update (float elapsedTime) {
		if (reference == null) {
			Stop (TweenStopState.NotModify);
			return false;
		}

		if (state == TweenState.Running) {
			currentTime += elapsedTime;

			if (currentTime >= duration) {
				Stop (TweenStopState.Complete);
				return true;
			}
			else {
				UpdateValue ();
				return false;
			}
		}
		return (state == TweenState.Stopped);
	}

	private void UpdateValue () {
		if (reference == null) {
			Stop (TweenStopState.NotModify);
			return;
		}

		progress = currentTime / duration;
		value = Mathf.Lerp (startValue, endValue, easing (progress));

		if (progressCallback != null)
			progressCallback.Invoke (this);
	}
	#endregion
}