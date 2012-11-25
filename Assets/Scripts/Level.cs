using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	private GridController grid;
	private Dimension levelDim;
	
	// Method 1
	// Look at Game Script on Plane object
	public GameObject tileObject;
	
	// Use this for initialization
	public Level(GridController grid, GameObject tileObject)
	{
		this.grid = grid;
		
		// Receive passed tile object
		this.tileObject = tileObject;
		
		levelDim = new Dimension(10,10);
		grid.initializeLevel(levelDim);
		
		initLevel ();
	}

	private Point newPos;
	protected void initLevel()
	{
		// Method 1
		// Via member variable
		//GameObject.Instantiate(tileObject, Vector3.zero, Quaternion.identity);
		
		// Method 2
		// Via Resources.Load and Instantiate
		//GameObject tilePrefab = Resources.Load("Prefabs/Tile") as GameObject;
		//GameObject.Instantiate(tilePrefab, Vector3.one, Quaternion.identity);
		
		newPos=new Point(0,0);
		for(int x=0;x<levelDim.width;x++)
		{
			for(int y=0;y<levelDim.height;y++)
			{
				//TiledObj tile =  GameObject.Instantiate(Resources.Load("Tile"));
				GameObject tileResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Tile"));
				//TiledObj newTile = (TiledObj)tile.GetComponent<TiledObj>();
			//tile.GetComponent(TiledObj).hello;
				//Debug.Log("Hello");
				TiledObj tile=tileResource.GetComponent(typeof(TiledObj)) as TiledObj;
				//string s=tile.GetComponent("TiledObj").hello;
				//After creating the tile, add it to the grid and set its location. 
				tile.setVel(x,y);
				grid.insertTile(tile);
		}
		}
			GameObject wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
		TiledObj wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
		wallTile.x=5;
		//wallTile.y=5;
		//grid.insertTile(wallTile);
		
			wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
		wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
		wallTile.x=4;
		wallTile.y=5;
			grid.insertTile(wallTile);
		
			wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
		wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
		wallTile.x=3;
		wallTile.y=5;
			grid.insertTile(wallTile);
		
			wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
		wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
		wallTile.x=2;
		wallTile.y=5;
			grid.insertTile(wallTile);
		
			wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
		wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
		wallTile.x=2;
		wallTile.y=4;
			grid.insertTile(wallTile);
		
		GameObject heroResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Hero"));
		TiledObj heroTile=heroResource.GetComponent(typeof(Character)) as TiledObj;
		heroTile.x=9;
		heroTile.y=9;
		
		grid.insertTile(heroTile);
		
	}
	
	public Dimension getLevelDimensions()
	{
		return levelDim;
	}

}
