using UnityEngine;
using System.Collections;

public class Character : TiledObj {

	// Use this for initialization
	void Start () {
	depth=2;
	}
	private bool right=false;
	private bool left=false;
	private bool up=false;
	private bool down=false;
	// Update is called once per frame
	void Update () {
	//Colin-Rewrite this code. I do not intend for it to be used. Only here for testing my Grid Code
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if(h>0)
		{
		if(!right)
			{
				right=true;
				x=1;
			}
		}else if(h<0)
		{
				if(!left){
				left=true;
				x=-1;
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
				y=1;
			}
		}else if(v<0){
				if(!down)
			{
				down=true;
				y=-1;
			}
		}else{
			up=false;
			down=false;
		}
		moveTile ();
	}
}
