using System;
using UnityEngine;
using System.Collections.Generic;
	public class TriggerController:MonoBehaviour
	{
	public bool hasTriggered;
	private List<TriggerTile> triggerTiles = new List<TriggerTile>();
	private List<ReactiveTile> reactiveTiles = new List<ReactiveTile>();
		void Start () 
	{
	
	}
		void Update () 
	{
	bool active=true;
		for(int i=0;i<triggerTiles.Count;i++)
		{
			TriggerTile tile = triggerTiles[i];
			if(!tile.IsTriggered){
			
				active=false;
			}
		}
		if(active && !hasTriggered)
		{
			hasTriggered=true;
			for(int i=0;i<triggerTiles.Count;i++)
			{
					triggerTiles[i].SetTriggered(true);
			}
				for(int i=0;i<reactiveTiles.Count;i++)
			{
				reactiveTiles[i].SetActive(true);
			}
		}
		if(!active && hasTriggered){
			hasTriggered=false;
			for(int i=0;i<triggerTiles.Count;i++)
			{
				triggerTiles[i].SetTriggered(false);
			}
			for(int i=0;i<reactiveTiles.Count;i++){
				reactiveTiles[i].SetActive(false);
			}
		}
	}
	public void AddTrigger(TriggerTile trigger)
	{
		triggerTiles.Add(trigger);
	}
	public void AddReactive(ReactiveTile tile)
	{
		reactiveTiles.Add(tile);
	}
	public static TriggerController createController(){
		GameObject triggerResource =  (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/TriggerController"));
			return triggerResource.GetComponent(typeof(TriggerController)) as TriggerController;
	}
}


