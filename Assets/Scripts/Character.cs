using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public int MaxHP = 5;
	public int HP = 5;
	public float KnockbackModifier = 2f;
	public float StunDuration = 1f;

	[HideInInspector]
	public Rigidbody2D rigidbody;

	//[HideInInspector]
	public float Stun = 0;


	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	protected virtual void Update()
	{
		StunCounter();
	}


	void StunCounter()
	{
		if (Stun > 0)
		{
			Stun -= Time.deltaTime;
			if (Stun < Time.deltaTime)
			{
				Stun = 0;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		Hitbox hitbox = other.GetComponent<Hitbox>();
		if (hitbox != null)
		{
			TouchHitbox(hitbox);
		}
	}


	void TouchHitbox(Hitbox hitbox)
	{
		if (Stun > 0)
		{
			return;
		}

		Damage(1); //to do

		if (HP > 0)
		{
			Vector3 KBDirection = transform.position - hitbox.owner.transform.position;
			Knockback(KBDirection.normalized + Vector3.up);
			Stun = StunDuration;
		}
		else
		{
			Die();
		}
	}

	public void Damage(int damage)
	{
		HP -= damage;
	}

	public void Knockback(Vector3 direction)
	{
		if (this is Player)
		{
			this.GetComponent<Player>().Stop();
		}

		rigidbody.velocity = direction * KnockbackModifier;

	}

	public void Die()
	{
		//to do
		Destroy(gameObject);
	}
}
