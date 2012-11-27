using System;

using UnityEngine;
	public class ClonerExit : ReactiveTile
	{
		// Use this for initialization
		void Start () 
		{
			base.depth=1;
			base._solid=false;
			base._canMove=false;
		}
	public override void SetActive (bool value)
	{
		base.SetActive (value);
		if(value)
		{
				// add the hero:
		GameObject heroResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Hero"));
		TiledObj heroTile=heroResource.GetComponent(typeof(Character)) as TiledObj;
		heroTile.x=x;
		heroTile.y=y;
			
			grid=(GridController)GameObject.FindObjectOfType(typeof(GridController));
			grid.insertTile(heroTile);
		}
	}
	}


