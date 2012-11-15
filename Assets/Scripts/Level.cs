using UnityEngine;
using System.Collections;

public class Level {
	private GridController grid;
		private Dimension levelDim;
	// Use this for initialization
	public Level(GridController grid)
	{
		this.grid=grid;
		levelDim = new Dimension(30,30);
			grid.initializeLevel(levelDim);
		initLevel ();
	}

	private Point newPos;
	protected void initLevel()
	{
		newPos=new Point(0,0);
		for(int x=0;x<levelDim.width;x++)
		{
			for(int y=0;y<levelDim.height;y++)
			{
				//HOW IN THE HELL DO YOU INITIALIZE PREFABS
				//Object obj=Resources.Load("Tile");
				
				//TiledObj tile=(TiledObj)GameObject.Instantiate(obj);
				//TiledObj tile =  (TiledObj)GameObject.Instantiate(Resources.Load("Tile"));
				//TiledObj tile =  (TiledObj)GameObject.Instantiate(obj);
				//AddComponent(tile);
				
				//After creating the tile, add it to the grid and set its location. 
			//	tile.x=x;
				//tile.y=y;
				//grid.insertTile(tile);
		}
		}
	}

}
