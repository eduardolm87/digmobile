using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

	public Image HPBar;

	public void Refresh()
	{
		float hpFill = GameManager.Instance.Player.HP * 1f / GameManager.Instance.Player.MaxHP;
		HPBar.fillAmount = hpFill;
	}

}
