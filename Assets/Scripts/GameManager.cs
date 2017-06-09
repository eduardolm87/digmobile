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



	public Player PlayerPrefab;
	public UI PlayerHUD;
	public TitleScreen TitleScreen;

	[HideInInspector]
	public Player Player;
	[HideInInspector]
	public Section CurrentSection;

	public List<Sprite> BreakTiles = new List<Sprite>();
	public Color StunColor;

	public List<Section> Sections = new List<Section>();



	bool busy = false;


	void InstantiatePlayer()
	{
		GameObject plObj = GameObject.Instantiate(PlayerPrefab.gameObject) as GameObject;
		Player = plObj.GetComponent<Player>();

		if (CurrentSection != null)
		{
			Player.transform.position = CurrentSection.StartPosition.position;
		}
	}

	public void StartGame()
	{
		if (busy)
			return;
		
		StartCoroutine(StartGameCoroutine());
	}

	IEnumerator StartGameCoroutine()
	{
		busy = true;

		TitleScreen.Hide();

		yield return new WaitForSeconds(0.5f);

		OpenLevel("Section_Debug");

		InstantiatePlayer();

		PlayerHUD.Show();

		busy = false;
		Debug.Log("Game Start");
	}

	void OpenLevel(string LevelName)
	{
		Section SectionPrefab = Sections.FirstOrDefault(x => x.name == LevelName);
		if (SectionPrefab == null)
		{
			Debug.LogError("Can't find level " + LevelName);
			return;
		}

		GameObject go = GameObject.Instantiate(SectionPrefab.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
		CurrentSection = go.GetComponent<Section>();
	}


	public void ResetGame()
	{
		CloseCurrentLevel();
		TitleScreen.Show();
	}

	public void ResetLevel()
	{
		CloseCurrentLevel();
		//todo
	}

	void CloseCurrentLevel()
	{
		DeinstantiatePlayer();

		Destroy(CurrentSection.gameObject);
		CurrentSection = null;
	}

	void DeinstantiatePlayer()
	{
		Destroy(Player.gameObject);
		Player = null;
	}


}
