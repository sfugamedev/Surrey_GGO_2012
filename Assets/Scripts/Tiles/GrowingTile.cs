using System;
using UnityEngine;
	public class GrowingTile:TiledObj
	{
		/*
	 C=pattern
	 
	 Growth pattern around object. 
	 
	 XXCXX
	 XC.CX
	 XXCXX
	 
	 */
	private Point[] growthPattern = {
		new Point(1,0),
		new Point(-1,0),
		new Point(0,1),
		new Point(0,-1)
		};
	//the rate at which the entity spreads in seconds. Every 1 second, the entity will grow. 
	private int GrowSpeed =3;
	private float lastUpdate=Time.fixedTime;
		void Start ()
	{
		GrowSpeed=3;
		base.depth = 2;
		base._solid = true;
		base._canMove = false;
	}
		void Update ()
	{
		moveTile();
		
		//if this is true, then it is time to grow. 
		if(Time.fixedTime-lastUpdate>=GrowSpeed)
		{
				grid=(GridController)GameObject.FindObjectOfType(typeof(GridController));

			lastUpdate=Time.fixedTime;
				TiledObj[] nativeList;
			for(int i=0;i<growthPattern.Length;i++)
			{
				bool spawn=true;
				Point spawnPoint=new Point(x+growthPattern[i].x,y+growthPattern[i].y);
			nativeList = grid.getTilesAt(spawnPoint);
				for(int j=0;j<nativeList.Length;j++)
				{
					//do not grow into solid space. 
					if(nativeList[j].solid)
					{
						spawn=false;
					}else
						//do not spawn same kind of growing tile in the same tile space. 
						//Should not be checking against hard type like this, but there were issues. 
						if(nativeList[j] is GasTile)
					{
						
						spawn=false;
					}
				}
				if(spawn)
				{
						GameObject gasResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Gas"));
			GasTile gasTile=gasResource.GetComponent(typeof(GasTile)) as GasTile;
					Vector3 setPos = new Vector3(
				x*TILE_SIZE,
				depth,
				y*TILE_SIZE
				);
			gasTile.transform.position=setPos;
			gasTile.x=spawnPoint.x;
			gasTile.y=spawnPoint.y;
				grid.insertTile(gasTile);
					
						
				}
			}
		}
	}
	}


