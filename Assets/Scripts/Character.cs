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

	[HideInInspector]
	public SpriteRenderer bodyRenderer;

	[HideInInspector]
	public float Stun = 0;


	public bool IsPlayer = false;



	protected virtual void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		bodyRenderer = GetComponent<SpriteRenderer>();

		if (this is Player)
			IsPlayer = true;
	}

	protected virtual void Start()
	{
		
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
				bodyRenderer.color = Color.white;
			}
			else
			{
				if (((int)(Stun * 10)) % 2 == 0)
					bodyRenderer.color = Color.white;
				else
					bodyRenderer.color = GameManager.Instance.StunColor;
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

		if (IsPlayer)
		{
			GameManager.Instance.UI.Refresh();
		}
	}

	public void Knockback(Vector3 direction)
	{
		if (IsPlayer)
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
