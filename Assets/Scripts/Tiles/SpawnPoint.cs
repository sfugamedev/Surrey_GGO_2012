using System;
using UnityEngine;

public class SpawnPoint : TiledObj {
	
	private Boolean onPad = false;
	
	public SpawnPoint ()
		: base()
	{
	}
	
	// Use this for initialization
	void Start () 
	{
		base.depth=1;
	}
	
	void OnTriggerEnter (Collider c)
	{
		onPad = true;
		Debug.Log("boop");
	}
	
	void OnTriggerExit (Collider c)
	{
		onPad = false;
	}
	
	public Boolean isPadClear() 
	{
		return !onPad;
	}
}
