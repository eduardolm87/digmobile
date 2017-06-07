using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour 
{
	[HideInInspector]
	public Character owner;

	protected virtual void Start()
	{
		owner = GetComponentInParent<Character>();
	}
}
