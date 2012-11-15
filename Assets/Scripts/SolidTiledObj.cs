using System;

namespace AssemblyCSharp
{
	public class SolidTiledObj : TiledObj
	{
		public SolidTiledObj ()
			: base()
		{
		}
		// Use this for initialization
	void Start () 
		{
		base._solid=true;
	}
	}
}

