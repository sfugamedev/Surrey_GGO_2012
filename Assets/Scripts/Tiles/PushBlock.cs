using System;
using UnityEngine;

	public class PushBlock : TiledObj 
	{	
		public PushBlock ()
			: base()
		{
		}
		// Use this for initialization
		void Start () 
		{
			base.depth=1;
			base._solid=true;
			base._canMove=true;
		}
	}
