using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour{
	

	private GridController grid;
	private Level level;
	// Use this for initialization
	void Start () {
		
	grid = new GridController();
	level = new Level(grid);
	//	level=(Level)GameObject.Instantiate(Resources.Load("Level"));
		//UnityEngine.GameObject:AddComponent();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
