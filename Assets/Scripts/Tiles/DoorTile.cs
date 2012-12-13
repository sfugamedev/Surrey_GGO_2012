using System;
using UnityEngine;
	public class DoorTile:ReactiveTile
	{
		void Start ()
	{
		base.depth = 2;
		base._solid = true;
		base._canMove = false;
	}
	public override void SetActive(bool value)
	{
		base.SetActive(value);
		if(value)
		{
			base.depth=0;
			base._solid=false;
			Vector3 setPos = new Vector3(
				transform.position.x,
				depth,
				transform.position.z
				);
			this.transform.position=setPos;
		}else{
			base.depth=2;
			base._solid=true;
		}
	}
		public override void collide(TiledObj tile){
	    if(tile.tileType==Character.TILE_TYPE){
			setVel(x-tile.x, y-tile.y);
		}
		base.collide(tile);
	}
	}


