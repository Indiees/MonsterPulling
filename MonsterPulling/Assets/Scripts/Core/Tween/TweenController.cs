using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum EaseType { Linear, Clerp, Spring, Punch, Quad, Cubic, Quart, Quint, Sine, Expo, Circ, Bounce, Back, Elastic }
public enum EaseMode { In, Out, InOut }
public enum TweenState { Running, Paused, Stopped }
public enum TweenStopState { NotModify, Complete }

public class TweenController : MonoBehaviour {
	#region Class members
	private static GameObject root;
	private static readonly List<Tween> tweens = new List<Tween> ();
	#endregion

	#region MonoBehaviour overrides
	private void Awake () {
		tweens.Clear ();
	}

	private void Update () {
		for (int i = 0; i < tweens.Count; i++) {
			Tween tween = tweens[i];

			if (tween.reference == null || !tween.reference.activeSelf) {
				tweens.RemoveAt (i);
				continue;
			}

			tween.Update (tween.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			//tweens.RemoveAt (i);
		}
	}
	#endregion

	#region Class implementation
	public static Tween Tween (GameObject reference, string identifier, bool useUnscaledTime, float start, float end, float duration, Action<Tween> progress) {
		return StartTween (reference, identifier, useUnscaledTime, start, end, duration, EasingCurves.linear, progress, null);
	}

	public static Tween Tween (GameObject reference, string identifier, bool useUnscaledTime, float start, float end, float duration, Func<float, float> easing, Action<Tween> progress) {
		return StartTween (reference, identifier, useUnscaledTime, start, end, duration, easing, progress, null);
	}

	public static Tween Tween (GameObject reference, string identifier, bool useUnscaledTime, float start, float end, float duration, Action<Tween> progress, Action<Tween> finish) {
		return StartTween (reference, identifier, useUnscaledTime, start, end, duration, EasingCurves.linear, progress, finish);
	}

	public static Tween Tween (GameObject reference, string identifier, bool useUnscaledTime, float start, float end, float duration, Func<float, float> easing, Action<Tween> progress, Action<Tween> finish) {
		return StartTween (reference, identifier, useUnscaledTime, start, end, duration, easing, progress, finish);
	}

	protected static Tween StartTween (GameObject reference, string identifier, bool useUnscaledTime, float start, float end, float duration, Func<float, float> easing, Action<Tween> progress, Action<Tween> finish) {
		Tween tween = new Tween (reference, reference.GetInstanceID () + identifier, useUnscaledTime, start, end, duration, easing, progress, finish);
		AddTween (tween);
		return tween;
	}

	protected static void AddTween (Tween tween) {
		if (root == null)
			root = new GameObject ("TweenController", typeof (TweenController));

		if (tween.identifier != null)
			RemoveTween (tween.identifier, TweenStopState.NotModify);

		tweens.Add (tween);
	}

	protected static bool RemoveTween (Tween tween, TweenStopState stopState) {
		tween.Stop (stopState);
		return tweens.Remove (tween);
	}

	protected static bool RemoveTween (string identifier, TweenStopState stopState) {
		bool founded = false;
		for (int i = 0; i < tweens.Count - 1; i++) {
			Tween tween = tweens[i];

			if (identifier == tween.identifier) {
				tween.Stop (stopState);
				tweens.RemoveAt (i);
				founded = true;
			}
		}

		return founded;
	}
	#endregion
}