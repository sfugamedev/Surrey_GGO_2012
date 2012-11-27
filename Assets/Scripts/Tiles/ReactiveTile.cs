using System;
using UnityEngine;

	public class ReactiveTile: TiledObj
	{
	public bool IsActive;
	public virtual void SetActive(bool value)
	{
		IsActive=value;
	}
	}


