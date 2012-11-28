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
		}else{
			base.depth=2;
			base._solid=true;
		}
	}
	}


