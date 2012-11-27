using System;
using UnityEngine;

	public class CloneBlock : TiledObj 
	{
		private int spawnX = 1;
		private int spawnY = 1;
		
		private SpawnPoint mySpawnPoint;
	
		public CloneBlock ()
			: base()
		{
		}
		// Use this for initialization
		void Start () 
		{
			base.depth=1;
			
			Game theGame = (Game)FindObjectOfType(typeof(Game));
			GridController grid = theGame.getGridController();
			
			GameObject spawnResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/SpawnPoint"));
			TiledObj spawnTile = spawnResource.GetComponent(typeof(SpawnPoint)) as TiledObj;
			spawnTile.x = spawnX;
			spawnTile.y = spawnY;
				grid.insertTile(spawnTile);
				mySpawnPoint = (SpawnPoint)spawnTile;
		}
	
		void OnTriggerEnter (Collider c)
		{	
			Game theGame = (Game)FindObjectOfType(typeof(Game));
			GridController grid = theGame.getGridController();
			// TODO: allow any moveable object to be cloned:
			
			TiledObj currentScript = c.gameObject.GetComponent(typeof(TiledObj)) as TiledObj;
			
			// check if spawn point is valid:
			if(mySpawnPoint.isPadClear())
			{
				// add the hero:
				GameObject heroResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/" + currentScript.prefabName));
				TiledObj cloneHeroTile=heroResource.GetComponent(typeof(TiledObj)) as TiledObj;
				cloneHeroTile.x = spawnX;
				cloneHeroTile.y = spawnY;
					grid.insertTile(cloneHeroTile);
			}
		}
	
		public void setSpawnPoint(int xVal, int yVal)
		{
			spawnX = xVal;
			spawnY = yVal;
		}
	}
