using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour{
	

	private GridController grid;
	private Level level;
	
	// A Tile Object field now appears in the Inspector view 
	public GameObject tileObject;
	
	// Use this for initialization
	void Start () {
		GameObject levelResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Level"));
		level=levelResource.GetComponent(typeof(Level)) as Level;
	
	//grid = new GridController();
	
	// Pass tile object to level
	//level = new Level(grid, tileObject);
	
	}
	
	
	public Level getLevel()
	{
		return level;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Restart"))
		{
			Application.LoadLevel(0);
		}
	//grid.updateGrid();
	}
}

