using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	//Movement Setup
	public float ClickingMaxHeightDifference = 0.33f;
	public float XMovementSensitivity = 0.1f;
	public float XMovementSpeed = 10f;
	public float XMovementStopDistance = 0.1f;
	public float YFallSpeedTolerance = 1f;


	//Elements
	public PowerupSword Sword;


	//Auxiliar
	Vector2 MovementTarget = Vector2.zero;
	bool MovementTargetSet = false;





	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	  
	protected override void Update()
	{
		base.Update();

		if (Stun > 0)
			return;

		GetInput();
		TryMovingToTarget();
		FallingCancelMovement();
	}

	void GetInput()
	{
		if (Input.GetMouseButtonUp(0))
		{
			ClickedOn((Vector2)Input.mousePosition);
		}
	}

	void ClickedOn(Vector2 ClickPosition)
	{
		Vector2 WorldPositionClicked = (Vector2)Camera.main.ScreenToWorldPoint(ClickPosition);

		float YDifference = Mathf.Abs(WorldPositionClicked.y - transform.position.y);

		if (YDifference < ClickingMaxHeightDifference)
		{
			TryToMoveToX(new Vector2(WorldPositionClicked.x, transform.position.y));
		}
	}



	void TryToMoveToX(Vector2 Pos)
	{
		Vector2 mypos = transform.position;
		if (Vector2.Distance(mypos, Pos) < XMovementSensitivity)
		{
			return;
		}

		MovementTarget = new Vector2(Pos.x, mypos.y);
		MovementTargetSet = true;
	}


	void TryMovingToTarget()
	{
		if (MovementTargetSet == false)
			return;

		float DistanceToDestiny = Vector2.Distance(transform.position, MovementTarget);
		if (DistanceToDestiny < XMovementStopDistance)
		{
			Stop();
		}
		else
		{
			MoveToTarget();
		}
	}

	void MoveToTarget()
	{
		int direction = 1;
		if (transform.position.x > MovementTarget.x)
			direction = -1;
		Vector2 force = Vector2.right * direction * XMovementSpeed;

		rigidbody.AddForce(force);
	}

	public void Stop()
	{
		MovementTargetSet = false;
		rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
	}


	void FallingCancelMovement()
	{
		

		if (Falling())
		{
			Stop();
		}
	}

	bool Falling()
	{
		float YVel = Mathf.Abs(rigidbody.velocity.y);
		return (YVel > YFallSpeedTolerance);
	}
	
}
