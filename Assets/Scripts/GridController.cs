using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;

[XmlRoot("GridController")]
public class GridController : MonoBehaviour
{
	//Why are there so many lists lol
	[XmlArray("objList"),XmlArrayItem("TiledObj")]
	private  List<TiledObj> objList;
	[XmlArray("tmpResolveTileList"),XmlArrayItem("TiledObj")]
	private  List<TiledObj> tmpResolveTileList;
	[XmlArray("objList"),XmlArrayItem("TiledObj")]
	private  List<TiledObj> resolveTileList;
	
	//depth represents the depth of the tiled map. how many tiles can occupy a single space. 
	private int depth = 3;
	/*a 3D array that represents the current state of the level as it sits in the grid. 
	will allow game to quickly and efficiently look up the current state of the grid for collision and interaction. 
	changes are made to the array only when object move withint the space. */
	[XmlArray("grid"),XmlArrayItem("TiledObj")]
	private TiledObj[,,] grid;
	

	// Use this for initialization
	void Start ()
	{
		//objList = new List<TiledObj> ();
	}
	
	// Save grid with given filename
 	public void Save(string path)
 	{
 		var serializer = new XmlSerializer(typeof(GridController));
 		using(var stream = new FileStream(Path.Combine(Application.dataPath, path+".xml"), FileMode.Create))
 		{
 			serializer.Serialize(stream, this);
 		}
 	}	
	
	// Load grid with given filename
	public static GridController Load(string path){
 		var serializer = new XmlSerializer(typeof(GridController));
 		using(var stream = new FileStream(path, FileMode.Open))
 		{
 			return serializer.Deserialize(stream) as GridController;
 		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		updateGrid();
	}
	
	public void updateGrid(){
		//resolveTiles(objList);
		resolveTiles(objList, true);
	}

	private void resolveTiles (List<TiledObj> list, bool doCollisions)
	{
		TiledObj[] depthList;
	TiledObj tile;
		TiledObj nativeTile;
	 Point vel;
		Dimension dim;
		 Point newPos = new Point(0,0);
	
		
		bool resolve;
	List<TiledObj> unresolved = new List<TiledObj> ();
		List<TiledObj> nativeTiles = new List<TiledObj> ();
		
		//itterate over all of the tiled object we current have. Only modify the ones that seem to have changed position, eg have velocity. 
		for (int i=0; i<list.Count; i++)
		{
			tile = list [i];
			vel = tile.vel;
			//if the tile has velocity. 
			if (vel.x != 0 || vel.y != 0)
			{
				dim = tile.dim;
				resolve = true;//true until proven otherwise with collision detection.
				
				//first, iterate over all the possible tiles that the object can occupy, given its dimensions. 
				//then,iterrate over all the possible tiles that can be found in the location we want to move into. 
				for (int x=tile.x+vel.x;
				x<tile.x+dim.width+vel.x;
				x++) {
					for (int y=tile.y+vel.y;
					y<tile.y+dim.height+vel.y;
					y++)
					//TODO: right now, assumes that we are always checking within the bounds of the level. We need to make an efficient check for this beforehand. 
						
					for (int j=0; j<depth; j++)
					{

						nativeTile = grid [x,y,j];
						
						//if nativeTile is null, then nothing occupies that particular depth. Skip it. 
						if (nativeTile != null) 
						{
							nativeTiles.Add(nativeTile);
							//if one of the collision has caused a change of velocity in one of said items, then we need to reolve that new velocity. 
							if(doCollisions){
							tile.collide(nativeTile);
								nativeTile.collide(tile);
							}
							//if the tile occupying my desired location is solid, then my motion has not yet been resolved. 
							if (nativeTile.solid)
							{
								resolve = false;
							}
						} else {
							//if it is null, then break. We will not allow gaps in depth to make things runs faster. 
							break;
						}
					}
				}
				if (resolve) {
					//if resolved is true, then resolve the tile movement.
					newPos.x=tile.pos.x+tile.vel.x;
					newPos.y=tile.pos.y+tile.vel.y;
					moveTile(tile,newPos);
				} else {
					//if resolve is false, do not resolve motion. 
					//add to list of unresolved tiles. 
					unresolved.Add (tile);
				}
				//TODO: If we hit something, velocity will have been set to 0 within the if statement. 
				//so here, just move the object according to its remaining velocity. 
			}
			
		}
		if(unresolved.Count==0 || unresolved.Count==list.Count)
		{
			
			//if unresolved count is 0, then all items have been resolved and we can finish all collision code. 
			//if the input list is the same length as we have unresolved tiles, then it is impossible to resolve any more than what we have. We are done. 
			for(int i=0;i<unresolved.Count;i++)
			{
				unresolved[i].stopVel();
			}
		}else{
			//else, continue to resolve tiles. 
			//
			//check all of the tiles that were collided with. Some velocities may have changed. 
			for(int i=0;i<nativeTiles.Count;i++)
			{
				tile = nativeTiles [i];
			vel = tile.vel;
				//if the veslocity did in fact change, then add it to the list of unresolved objects to be resolved next pass. 
			if (vel.x != 0 || vel.y != 0) 
				{
					//if said tile is not already in the list. Innifficient, because the tile may be included in the nativeTiles list more than once. 
					if(unresolved.IndexOf(tile)<0){
					unresolved.Add(tile);
					}
				}
			}
			resolveTiles (unresolved, false);
		}
	//	resolveTileList.Clear();
	}
	public void insertTile(TiledObj tile){
		objList.Add(tile);
		
		moveTile (tile, tile.vel);
	}
	private void moveTile (TiledObj tile, Point newPos)
	{
		TiledObj nativeTile;
	Dimension dim=tile.dim;
			//REMOVE TILE FROM OLD POSITION
		for (int x=tile.x;
				x<tile.x+dim.width;
				x++) {
			for (int y=tile.y;
					y<tile.y+dim.height;
					y++) {
				
				for (int j=0; j<depth; j++) {
					
					nativeTile = grid [x,y,j];
					//add to the end of the depth list.  
					if (nativeTile == tile) 
					{
						//if I found the location of where the current tile sits in the depth, then remove it.
						//we are just shifting the list one space to the left. will overrite the current tile, and keep the list from becoming staggard. 
						for(int i=j;i<depth-1;i++)
						{
							grid[x,y,i]=grid[x,y,i+1];
						}
					}else if (nativeTile!=null)
					{
						nativeTile.onLeave(tile);
						tile.onLeave(nativeTile);
					}else{
						break;
					}
				}
			}
		}
		//ADD TO NEW POSITION
		for (int x=newPos.x;
				x<newPos.x+dim.width;
				x++)
		{
			for (int y=newPos.y;
					y<newPos.y+dim.height;
					y++) 
			{
				
				for (int j=0; j<depth; j++) {
					nativeTile = grid [x,y,j];
					//add to the end of the depth list.  
					if (nativeTile == null)
					{
						//if there is no tile occupying that particular depth, then occupy it. 
					grid[x,y,j]=tile;
						//break, we only want to occupy 1 space of depth. 
						break;
					}
				}
			}
		}
		tile.setPos(newPos.x, newPos.y);
		tile.stopVel();
	}
	
	public void initializeLevel (Dimension dim)
	{
		/*take the width and height of the level, and the fact that we are going to allow 3 tiles to sit in the same location, hense the 3D space. 
		we may even use this depth as our means of layering elements such as items over top of other tiles. 
	each tile would have a desired depth, 0, 1, or 2. We would render them as best we could. */
		grid = new TiledObj[dim.width, dim.height, depth];
			objList = new List<TiledObj> ();
		resolveTileList = new List<TiledObj> ();
	}
	public void resolveMovement(TiledObj tile)
	{
		if(resolveTileList.IndexOf(tile)<0){
		//resolveTileList.Add(tile);
		}
	}
	public void doOverCollide(TiledObj tile)
	{
			TiledObj nativeTile;
			Dimension dim=tile.dim;
			for (int x=tile.x;
				x<tile.x+dim.width;
				x++) 
		{
			for (int y=tile.y;
					y<tile.y+dim.height;
					y++) 
			{
				
				for (int j=0; j<depth; j++) 
				{
					nativeTile = grid [x,y,j];
				if (nativeTile != tile && nativeTile!=null) 
					{
						nativeTile.onOver(tile);
						tile.onOver(nativeTile);
					}
				}
			}
		}
	}
}


