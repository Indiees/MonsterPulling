using System;
using UnityEngine;

public class EasingCurves {
	public static readonly Func<float, float> linear = Linear;
	public static readonly Func<float, float> quadratic = Quadratic;
	public static readonly Func<float, float> clerp = Clerp;
	public static readonly Func<float, float> spring = Spring;
	public static readonly Func<float, float, float> punch = Punch;
	public static readonly Func<float, float> easeInQuad = EaseInQuad;
	public static readonly Func<float, float> easeOutQuad = EaseOutQuad;
	public static readonly Func<float, float> easeInOutQuad = EaseInOutQuad;
	public static readonly Func<float, float> easeInCubic = EaseInCubic;
	public static readonly Func<float, float> easeOutCubic = EaseOutCubic;
	public static readonly Func<float, float> easeInOutCubic = EaseInOutCubic;
	public static readonly Func<float, float> easeInQuart = EaseInQuart;
	public static readonly Func<float, float> easeOutQuart = EaseOutQuart;
	public static readonly Func<float, float> easeInOutQuart = EaseInOutQuart;
	public static readonly Func<float, float> easeInQuint = EaseInQuint;
	public static readonly Func<float, float> easeOutQuint = EaseOutQuint;
	public static readonly Func<float, float> easeInOutQuint = EaseInOutQuint;
	public static readonly Func<float, float> easeInSine = EaseInSine;
	public static readonly Func<float, float> easeOutSine = EaseOutSine;
	public static readonly Func<float, float> easeInOutSine = EaseInOutSine;
	public static readonly Func<float, float> easeInExpo = EaseInExpo;
	public static readonly Func<float, float> easeOutExpo = EaseOutExpo;
	public static readonly Func<float, float> easeInOutExpo = EaseInOutExpo;
	public static readonly Func<float, float> easeInCirc = EaseInCirc;
	public static readonly Func<float, float> easeOutCirc = EaseOutCirc;
	public static readonly Func<float, float> easeInOutCirc = EaseInOutCirc;
	public static readonly Func<float, float> easeInBounce = EaseInBounce;
	public static readonly Func<float, float> easeOutBounce = EaseOutBounce;
	public static readonly Func<float, float> easeInOutBounce = EaseInOutBounce;
	public static readonly Func<float, float> easeInBack = EaseInBack;
	public static readonly Func<float, float> easeOutBack = EaseOutBack;
	public static readonly Func<float, float> easeInOutBack = EaseInOutBack;
	public static readonly Func<float, float> easeInElastic = EaseInElastic;
	public static readonly Func<float, float> easeOutElastic = EaseOutElastic;
	public static readonly Func<float, float> easeInOutElastic = EaseInOutElastic;

	protected static float Linear (float value) {
		float start = 0;
		float end = 1;
		return Mathf.Lerp (start, end, value);
	}

	protected static float Quadratic (float value) {
		return -4 * Mathf.Pow (value, 2) + value * 4;
	}

	protected static float Clerp (float value) {
		float start = 0;
		float end = 1;
		float min = 0.0f;
		float max = 360.0f;
		float half = Mathf.Abs ((max - min) * 0.5f);
		float retval = 0.0f;
		float diff = 0.0f;

		if ((end - start) < -half) {
			diff = ((max - start) + end) * value;
			retval = start + diff;
		}
		else if ((end - start) > half) {
			diff = -((max - end) + start) * value;
			retval = start + diff;
		}
		else retval = start + (end - start) * value;
		return retval;
	}

	protected static float Spring (float value) {
		float start = 0;
		float end = 1;
		value = Mathf.Clamp01 (value);
		value = (Mathf.Sin (value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow (1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
		return start + (end - start) * value;
	}

	protected static float Punch (float amplitude, float value) {
		float s = 9;
		if (value == 0) {
			return 0;
		}
		else if (value == 1) {
			return 0;
		}
		float period = 1 * 0.3f;
		s = period / (2 * Mathf.PI) * Mathf.Asin (0);
		return (amplitude * Mathf.Pow (2, -10 * value) * Mathf.Sin ((value * 1 - s) * (2 * Mathf.PI) / period));
	}

	protected static float EaseInQuad (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * value * value + start;
	}

	protected static float EaseOutQuad (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return -end * value * (value - 2) + start;
	}

	protected static float EaseInOutQuad (float value) {
		float start = 0;
		float end = 1;
		value /= 0.5f;
		end -= start;

		if (value < 1)
			return end * 0.5f * value * value + start;

		value--;
		return -end * 0.5f * (value * (value - 2) - 1) + start;
	}

	protected static float EaseInCubic (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * value * value * value + start;
	}

	protected static float EaseOutCubic (float value) {
		float start = 0;
		float end = 1;
		value--;
		end -= start;
		return end * (value * value * value + 1) + start;
	}

	protected static float EaseInOutCubic (float value) {
		float start = 0;
		float end = 1;
		value /= 0.5f;
		end -= start;

		if (value < 1)
			return end * 0.5f * value * value * value + start;

		value -= 2;
		return end * 0.5f * (value * value * value + 2) + start;
	}

	protected static float EaseInQuart (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * value * value * value * value + start;
	}

	protected static float EaseOutQuart (float value) {
		float start = 0;
		float end = 1;
		value--;
		end -= start;
		return -end * (value * value * value * value - 1) + start;
	}

	protected static float EaseInOutQuart (float value) {
		float start = 0;
		float end = 1;
		value /= 0.5f;
		end -= start;

		if (value < 1)
			return end * 0.5f * value * value * value * value + start;

		value -= 2;
		return -end * 0.5f * (value * value * value * value - 2) + start;
	}

	protected static float EaseInQuint (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * value * value * value * value * value + start;
	}

	protected static float EaseOutQuint (float value) {
		float start = 0;
		float end = 1;
		value--;
		end -= start;
		return end * (value * value * value * value * value + 1) + start;
	}

	protected static float EaseInOutQuint (float value) {
		float start = 0;
		float end = 1;
		value /= 0.5f;
		end -= start;

		if (value < 1)
			return end * 0.5f * value * value * value * value * value + start;

		value -= 2;
		return end * 0.5f * (value * value * value * value * value + 2) + start;
	}

	protected static float EaseInSine (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return -end * Mathf.Cos (value * (Mathf.PI * 0.5f)) + end + start;
	}

	protected static float EaseOutSine (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * Mathf.Sin (value * (Mathf.PI * 0.5f)) + start;
	}

	protected static float EaseInOutSine (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return -end * 0.5f * (Mathf.Cos (Mathf.PI * value) - 1) + start;
	}

	protected static float EaseInExpo (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * Mathf.Pow (2, 10 * (value - 1)) + start;
	}

	protected static float EaseOutExpo (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return end * (-Mathf.Pow (2, -10 * value) + 1) + start;
	}

	protected static float EaseInOutExpo (float value) {
		float start = 0;
		float end = 1;
		value /= 0.5f;
		end -= start;

		if (value < 1)
			return end * 0.5f * Mathf.Pow (2, 10 * (value - 1)) + start;

		value--;
		return end * 0.5f * (-Mathf.Pow (2, -10 * value) + 2) + start;
	}

	protected static float EaseInCirc (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		return -end * (Mathf.Sqrt (1 - value * value) - 1) + start;
	}

	protected static float EaseOutCirc (float value) {
		float start = 0;
		float end = 1;
		value--;
		end -= start;
		return end * Mathf.Sqrt (1 - value * value) + start;
	}

	protected static float EaseInOutCirc (float value) {
		float start = 0;
		float end = 1;
		value /= 0.5f;
		end -= start;
		if (value < 1) return -end * 0.5f * (Mathf.Sqrt (1 - value * value) - 1) + start;
		value -= 2;
		return end * 0.5f * (Mathf.Sqrt (1 - value * value) + 1) + start;
	}

	protected static float EaseInBounce (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		float d = 1f;
		return end - EaseOutBounce (d - value) + start;
	}

	protected static float EaseOutBounce (float value) {
		float start = 0;
		float end = 1;
		value /= 1f;
		end -= start;
		if (value < (1 / 2.75f)) {
			return end * (7.5625f * value * value) + start;
		}
		else if (value < (2 / 2.75f)) {
			value -= (1.5f / 2.75f);
			return end * (7.5625f * (value) * value + .75f) + start;
		}
		else if (value < (2.5 / 2.75)) {
			value -= (2.25f / 2.75f);
			return end * (7.5625f * (value) * value + .9375f) + start;
		}
		else {
			value -= (2.625f / 2.75f);
			return end * (7.5625f * (value) * value + .984375f) + start;
		}
	}

	protected static float EaseInOutBounce (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		float d = 1f;
		if (value < d * 0.5f) return EaseInBounce (value * 2) * 0.5f + start;
		else return EaseOutBounce (value * 2 - d) * 0.5f + end * 0.5f + start;
	}

	protected static float EaseInBack (float value) {
		float start = 0;
		float end = 1;
		end -= start;
		value /= 1;
		float s = 1.70158f;
		return end * (value) * value * ((s + 1) * value - s) + start;
	}

	protected static float EaseOutBack (float value) {
		float start = 0;
		float end = 1;
		float s = 1.70158f;
		end -= start;
		value = (value) - 1;
		return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
	}

	protected static float EaseInOutBack (float value) {
		float start = 0;
		float end = 1;
		float s = 1.70158f;
		end -= start;
		value /= 0.5f;
		if ((value) < 1) {
			s *= (1.525f);
			return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
		}
		value -= 2;
		s *= (1.525f);
		return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
	}

	protected static float EaseInElastic (float value) {
		float start = 0;
		float end = 1;
		end -= start;

		float d = 1f;
		float p = d * 0.3f;
		float s = 0;
		float a = 0;

		if (value == 0) return start;

		if ((value /= d) == 1) return start + end;

		if (a == 0f || a < Mathf.Abs (end)) {
			a = end;
			s = p / 4;
		}
		else {
			s = p / (2 * Mathf.PI) * Mathf.Asin (end / a);
		}

		return -(a * Mathf.Pow (2, 10 * (value -= 1)) * Mathf.Sin ((value * d - s) * (2 * Mathf.PI) / p)) + start;
	}

	protected static float EaseOutElastic (float value) {
		float start = 0;
		float end = 1;
		end -= start;

		float d = 1f;
		float p = d * 0.3f;
		float s = 0;
		float a = 0;

		if (value == 0) return start;

		if ((value /= d) == 1) return start + end;

		if (a == 0f || a < Mathf.Abs (end)) {
			a = end;
			s = p * 0.25f;
		}
		else {
			s = p / (2 * Mathf.PI) * Mathf.Asin (end / a);
		}

		return (a * Mathf.Pow (2, -10 * value) * Mathf.Sin ((value * d - s) * (2 * Mathf.PI) / p) + end + start);
	}

	protected static float EaseInOutElastic (float value) {
		float start = 0;
		float end = 1;
		end -= start;

		float d = 1f;
		float p = d * 0.3f;
		float s = 0;
		float a = 0;

		if (value == 0) return start;

		if ((value /= d * 0.5f) == 2) return start + end;

		if (a == 0f || a < Mathf.Abs (end)) {
			a = end;
			s = p / 4;
		}
		else {
			s = p / (2 * Mathf.PI) * Mathf.Asin (end / a);
		}

		if (value < 1) return -0.5f * (a * Mathf.Pow (2, 10 * (value -= 1)) * Mathf.Sin ((value * d - s) * (2 * Mathf.PI) / p)) + start;
		return a * Mathf.Pow (2, -10 * (value -= 1)) * Mathf.Sin ((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
	}
}