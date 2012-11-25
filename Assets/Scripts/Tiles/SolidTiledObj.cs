using System;
using UnityEngine;

	public class SolidTiledObj : TiledObj
	{
		public SolidTiledObj ()
			: base()
		{
		}
		// Use this for initialization
		void Start () 
		{
			base.depth=1;
			base._solid=true;
			base._canMove=false;
		}
	}


