using System;
using UnityEngine;

public class ToggleTrigger:TriggerTile
{
	//Class used for toggle functionality. Hero goes over, it goes to true. 
	//Hero leaves and steps back on, it goes to false. etc...
	
	
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
			this.SetTriggered (!this.IsTriggered);
		}
		
	}
}


