using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour{
	

	private GridController grid;
	private Level level;
	
	// A Tile Object field now appears in the Inspector view 
	public GameObject tileObject;
	
	// Use this for initialization
	void Start () {
		
		grid = new GridController();
		
		// Pass tile object to level
		level = new Level(grid, tileObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	grid.updateGrid();
	}
	
	public Level getLevel()
	{
		return level;
	}
	
	public GridController getGridController()
	{
		return grid;
	}
}
