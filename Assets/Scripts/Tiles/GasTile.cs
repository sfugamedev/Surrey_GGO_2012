using System;
using UnityEngine;
	public class GasTile:GrowingTile
	{
	public static uint TILE_TYPE = 0xff;
		void Start ()
	{
		base.depth = 2;
		base._solid = false;
		base._canMove = false;
		_tileType=TILE_TYPE;
		moveTime=300;
	}
	
	}


