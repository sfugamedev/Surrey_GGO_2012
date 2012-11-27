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
		
		levelDim = new Dimension(12,12);
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
		
		// build a wall around the entire map:
		// build the left and right:
		for(int pos = 0; pos<levelDim.width; pos++)
		{
				GameObject wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
			TiledObj wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
			wallTile.x=0;
			wallTile.y=pos;
				grid.insertTile(wallTile);
			
			    wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
			wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
			wallTile.x=levelDim.width-1;
			wallTile.y=pos;
				grid.insertTile(wallTile);
		}
		// build the top and bottom:
		for(int pos = 1; pos<levelDim.height-1; pos++)
		{
				GameObject wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
			TiledObj wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
			wallTile.x=pos;
			wallTile.y=0;
				grid.insertTile(wallTile);
			
			    wallResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Wall"));
			wallTile=wallResource.GetComponent(typeof(SolidTiledObj)) as TiledObj;
			wallTile.x=pos;
			wallTile.y=levelDim.height-1;
				grid.insertTile(wallTile);
		}
		
		// add in some push blocks:
		GameObject pushBlockResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/PushBlock"));
		TiledObj pushTile = pushBlockResource.GetComponent(typeof(PushBlock)) as TiledObj;
		pushTile.x=4;
		pushTile.y=5;
			grid.insertTile(pushTile);
		
		pushBlockResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/PushBlock"));
		pushTile = pushBlockResource.GetComponent(typeof(PushBlock)) as TiledObj;
		pushTile.x=3;
		pushTile.y=5;
			grid.insertTile(pushTile);
		
		pushBlockResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/PushBlock"));
		pushTile = pushBlockResource.GetComponent(typeof(PushBlock)) as TiledObj;
		pushTile.x=2;
		pushTile.y=5;
			grid.insertTile(pushTile);
		
		pushBlockResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/PushBlock"));
		pushTile = pushBlockResource.GetComponent(typeof(PushBlock)) as TiledObj;
		pushTile.x=2;
		pushTile.y=4;
			grid.insertTile(pushTile);
		
		// add the hero:
		GameObject heroResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Hero"));
		TiledObj heroTile=heroResource.GetComponent(typeof(Character)) as TiledObj;
		heroTile.x=2;
		heroTile.y=2;
			grid.insertTile(heroTile);
		
		// add a clone block:
		GameObject clonePadResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/ClonePad"));
		CloneBlock cloneTile=clonePadResource.GetComponent(typeof(CloneBlock)) as CloneBlock;
		cloneTile.x=3;
		cloneTile.y=1;
		cloneTile.setSpawnPoint(7, 7);
			grid.insertTile(cloneTile);
	}
	
	public Dimension getLevelDimensions()
	{
		return levelDim;
	}

}
