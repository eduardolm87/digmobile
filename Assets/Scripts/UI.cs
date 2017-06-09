using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public Image HPBar;

	public Image PauseButtonImage;
	public Sprite PauseButtonNormal, IconPauseButtonCloseIcon;

	public GameObject PausePopup;

	public void Refresh()
	{
		float hpFill = GameManager.Instance.Player.HP * 1f / GameManager.Instance.Player.MaxHP;
		HPBar.fillAmount = hpFill;
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}



	public void PauseButtonClicked()
	{
		if (PausePopup.activeInHierarchy)
		{
			HidePopup();
		}
		else
		{
			ShowPopup();
		}
	}

	public void ShowPopup()
	{
		PausePopup.SetActive(true);
		PauseButtonImage.sprite = IconPauseButtonCloseIcon;
	}

	public void HidePopup()
	{
		PausePopup.SetActive(false);
		PauseButtonImage.sprite = PauseButtonNormal;

	}


	public void PauseMenu_TitleScreen()
	{
		HidePopup();
		GameManager.Instance.ResetGame();
	}

	public void PauseMenu_Reset()
	{
		HidePopup();
		GameManager.Instance.ResetGame();
	}

	public void PauseMenu_Continue()
	{
		HidePopup();
	}
}
