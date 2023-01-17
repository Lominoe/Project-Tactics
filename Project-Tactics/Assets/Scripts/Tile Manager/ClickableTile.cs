using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour
{

	public int tileX;
	public int tileY;
	public TileMap map;
	public GameManager gm;
	void OnEnable()
	{
		gm = GameManager.SeekManager();
	}

	void OnMouseUp()
	{
		Debug.Log("" + tileX + " " + tileY);
		if (gm.sUnit != null) {
			map.GeneratePathTo(tileX, tileY);
		}
	}

}
