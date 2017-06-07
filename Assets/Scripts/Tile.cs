using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public SpriteRenderer TileRenderer;
	public SpriteRenderer BreakRenderer;

	public int Life = 5;


	public void DestroyTile()
	{
		Destroy(gameObject);
	}

	public void OnMouseDown()
	{
		Damage();
	}

	void Damage()
	{
		Life -= 1;
		if (Life > 0)
		{
			UpdateAppearance();
		}
		else
		{
			DestroyTile();
		}
	}

	void UpdateAppearance()
	{
		if (Life == 5)
		{
			BreakRenderer.sprite = null;
		}
		else
		{
			BreakRenderer.sprite = GameManager.Instance.BreakTiles[Life - 1];
		}
	}
}
