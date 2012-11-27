using System;

using UnityEngine;
	public class ClonerEntrance:TriggerTile
	{
			// Use this for initialization
		void Start () 
		{
			base.depth=1;
			base._solid=false;
			base._canMove=false;
		}
	public override void onOver (TiledObj tile)
	{
		base.onOver (tile);
		if(tile.tileType==Character.TILE_TYPE)
		{
		this.SetTriggered(true);
		}
	}
	}

