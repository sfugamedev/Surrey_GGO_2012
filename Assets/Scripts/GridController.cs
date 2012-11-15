using System;
using System.Collections.Generic;
using UnityEngine;

	public class GridController : MonoBehaviour
	{
	private  List<TiledObj> objList;
	//depth represents the depth of the tiled map. how many tiles can occupy a single space. 
	private int depth=3;
	/*a 3D array that represents the current state of the level as it sits in the grid. 
	will allow game to quickly and efficiently look up the current state of the grid for collision and interaction. 
	changes are made to the array only when object move withint the space. */
	private TiledObj[,,] grid;
		public GridController ()
		: base()
		{
		}
		// Use this for initialization
	void Start () 
	{
	objList =new List<TiledObj>();
	}
	
	// Update is called once per frame
	void Update () {
		TiledObj tile;
		TiledObj nativeTile;
		PointEditor vel;
		PointEditor dim;
		TileObj[] depthList;
		//itterate over all of the tiled object we current have. Only modify the ones that seem to have changed position, eg have velocity. 
	for (int i=0;i<objList.Count;i++){
			tile=objList[i];
			vel=tile.vel;
			//if the tile has velocity. 
			if(vel.x!=0 || vel.y!=0)
			{
				dim=tile.dim;
				//first, iterate over all the possible tiles that the object can occupy, given its dimensions. 
				//then,iterrate over all the possible tiles that can be found in the location we want to move into. 
				for(int x=tile.x+vel.x;
					x<tile.x+dim.x+vel.x;
					x++)
				{
					
						for(int y=tile.y+vel.y;
					y<tile.y+dim.y+vel.y;
					y++)
						//TODO: right now, assumes that we are always checking within the bounds of the level. We need to make an efficient check for this beforehand. 
				depthList = grid[x, y];
						for(int j=0;j<depth;j++)
						{
						nativeTile = depthList[j];
						//if nativeTile is null, then nothing occupies that particular depth. Skip it. 
						if(nativeTile!=null)
						{
							//TODO: hit detection, blah blah blah. 
						}else{
							//if it is null, then break. We will not allow gaps in depth to make things runs faster. 
							break;
						}
						//TODO: If we hit something, velocity will have been set to 0 within the if statement. 
						//so here, just move the object according to its remaining velocity. 
					
				}
				}
				}
				
			}
		}
	}
	protected void initializeLevel(Dimension dim)
	{
/*take the width and height of the level, and the fact that we are going to allow 3 tiles to sit in the same location, hense the 3D space. 
		we may even use this depth as our means of layering elements such as items over top of other tiles. 
	each tile would have a desired depth, 0, 1, or 2. We would render them as best we could. */
		grid = new TiledObj[dim.width, dim.height, 3];
	}
	}

