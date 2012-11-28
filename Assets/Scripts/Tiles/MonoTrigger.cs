using System;
using UnityEngine;
	public class MonoTrigger:TriggerTile
	{
		//Class used for single trigger functionality. Hero goes over, it goes to true. 
	//thats it. Will not change anymore. 
		// Use this for initialization
	void Start ()
	{
		base.depth = 1;
		base._solid = false;
		base._canMove = false;
	}

	public override void onOver (TiledObj tile)
	{
		base.onOver (tile);
		if (tile.tileType == Character.TILE_TYPE) 
		{
			
			this.SetTriggered (true);
		}
	}
	}


