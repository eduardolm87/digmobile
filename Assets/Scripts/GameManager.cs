using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance = null;

	void Awake()
	{
		Instance = this;
	}




	public Player Player;
	public UI UI;

	public List<Sprite> BreakTiles = new List<Sprite>();
	public Color StunColor;


}
