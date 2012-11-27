using UnityEngine;
using System.Collections;

public class Character : TiledObj 
{
	public static uint TILE_TYPE=0x01;
	
	// Use this for initialization
	void Start () {
	depth=2;
		_solid=true;
		this._tileType=TILE_TYPE;
	}
	private bool right=false;
	private bool left=false;
	private bool up=false;
	private bool down=false;
	// Update is called once per frame
	void Update () 
	{
	//Colin-Rewrite this code. I do not intend for it to be used. Only here for testing my Grid Code
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if(h>0)
		{
		if(!right)
			{
				right=true;
				setVel (1,0);
			}
		}else if(h<0)
		{
				if(!left){
				left=true;
					setVel (-1,0);
			}
		}else{
			right=false;
			left=false;
		}
		if(v>0)
		{
			
			if(!up)
			{
				up=true;
					setVel (0,1);
			}
		}else if(v<0){
				if(!down)
			{
				down=true;
					setVel (0,-1);
			}
		}else{
			up=false;
			down=false;
		}
		moveTile ();
	}
	public override void collide(TiledObj tile){
	    if(tile.solid && tile.canMove){
			tile.setVel(tile.x-x, tile.y-y);
		}
		base.collide(tile);
	}
}
