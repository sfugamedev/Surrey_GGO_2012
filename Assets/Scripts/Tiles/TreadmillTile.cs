using System;
using UnityEngine;

	public class TreadmillTile:TiledObj
	{
	private int textureOffset=0;
	// Use this for initialization
		void Start () 
		{
			base.depth=1;
			base._solid=false;
			base._canMove=false;
		}
	/// Update is called once per frame
	void Update () 
	{
		renderer.material.SetTextureOffset ("_MainTex",new Vector2(++textureOffset, 0));
			moveTile();
	}
	//the direction of force applied to the character. 
	private Point dir =  new Point(0,1);
	public override void onOver (TiledObj tile)
	{
		base.onOver (tile);
		if(tile.tileType==Character.TILE_TYPE)
		{
			tile.setVel(dir.x,dir.y);
		}
	}
	public void SetDir(int x, int y)
	{
		dir.x=x;
		dir.y=y;
	}
	
}


