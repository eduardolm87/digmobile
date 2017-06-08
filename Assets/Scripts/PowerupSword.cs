using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSword : Hitbox
{
	private Vector3 positionRight = new Vector3(0.25f, -0.16f, 0);
	private Vector3 scaleRight = new Vector3(1, 1, 1);

	private Vector3 positionLeft = new Vector3(-0.25f, -0.16f, 0);
	private Vector3 scaleLeft = new Vector3(-1, -1, 1);

	void Update()
	{
		Look(owner.OrientationRight);
	}

	void Look(bool right)
	{
		if(right)
		{
			transform.localPosition = positionRight;
			transform.localScale = scaleRight;
		}
		else
		{
			transform.localPosition = positionLeft;
			transform.localScale = scaleLeft;
		}


	}
}
