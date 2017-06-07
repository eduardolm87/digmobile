using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSword : Hitbox
{

	void Update()
	{
		if (owner.rigidbody.velocity.x > 0)
		{
			Look(true);
		}
		else if (owner.rigidbody.velocity.x < 0)
		{
			Look(false);
		}
	}

	void Look(bool right)
	{
		Vector3 positionRight = new Vector3(0.45f, -0.2f, 0);
		Vector3 scaleRight = new Vector3(1, 1, 1);

		Vector3 positionLeft = new Vector3(-0.45f, -0.2f, 0);
		Vector3 scaleLeft = new Vector3(1, -1, 1);


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
