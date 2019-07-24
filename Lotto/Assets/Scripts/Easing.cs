﻿// Call in loop when the x value is in range[0, 1]
using UnityEngine;
public static class Easing {

	public static float Linear(float x)
	{
		return x;
	}

	public static float EaseInQuad(float x)
	{
		return x*x;
	}

	public static float EaseOutQuad(float x)
	{
		return x*(2-x);
	}

	public static float EaseInOutQuad(float x)
	{
		return x < 0.5 ? 2*x*x : -1+(4-2*x)*x;
	}

	public static float EaseInCubic(float x)
	{
		return x*x*x;
	}

	public static float EaseOutCubic(float x)
	{
		return (--x)*x*x+1;
	}

	public static float EaseInOutCubic(float x)
	{
		return x < 0.5 ? 4*x*x*x : (x-1)*(2*x-2)+1;
	}

	public static float EaseInQuart(float x)
	{
		return x*x*x*x;
	}

	public static float EaseInOutQuart(float x)
	{
		return x < 0.5 ? 8*x*x*x*x : 1-8*(--x)*x*x*x;
	}

	public static float EaseInQuint(float x)
	{
		return x*x*x*x*x;
	}

	public static float EaseOutQuint(float x)
	{
		return 1+(--x)*x*x*x*x;
	}

	public static float EaseInOutQuint(float x)
	{
		return x < 0.5 ? 16*x*x*x*x*x : 1+16*(--x)*x*x*x*x;
	}

	public static float EaseInSine(float x)
	{
		return 1f - Mathf.Cos(x*Mathf.PI/2f);
	}

	public static float EaseOutSine(float x)
	{
		return Mathf.Sin(x*Mathf.PI/2f);
	}

	public static float EaseInOutSine(float x)
	{
		return 0.5f*(1f - Mathf.Cos(Mathf.PI*x));
	}

	public static float EaseInBounce(float x)
	{
		return 1f - EaseOutBounce(1f-x);
	}

	public static float EaseOutBounce(float x)
	{
		if(x < (1f/2.75f))
		{
			return 7.5625f * x * x;
		}
		else if (x < (2f/2.75f)) {
			return 7.5625f*(x -= (1.5f/2.75f))*x + 0.75f;
		}
		else if (x < (2.5f/2.75f)) {
			return 7.5625f *(x -= (2.25f/2.75f))*x + 0.9375f;
		}
		else {
			return 7.5625f*(x -= (2.625f/2.75f))*x + 0.984375f;
		}
	}

	public static float EaseInOutBounce(float x)
	{
		if (x < 0.5f) return EaseInBounce(x*2f)*0.5f;
		return EaseOutBounce(x*2f - 1f)*0.5f + 0.5f;
	}
}