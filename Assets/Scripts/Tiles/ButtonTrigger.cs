using System;

using UnityEngine;
	public class ButtonTrigger:TriggerTile
	{
	//Class used for button trigger functionality. Hero goes over, it goes to true. 
	//Hero leaves, it goes to false. Hero steps back on, it goes back to true, etc....
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
		public override void onLeave(TiledObj tile)
	{
		base.onLeave (tile);
		if(tile.tileType==Character.TILE_TYPE)
		{
		this.SetTriggered(false);
		}
	}
	}

