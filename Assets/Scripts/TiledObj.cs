using UnityEngine;
using System.Collections;

public class TiledObj : GDCObject {
	//TiledObj class represents any object that can be displayed and manipulated withing the grid structure of the game. 
	
	//grid index of the tiled object. Represents it's upper left corner. 
	private Point _pos;
	//grid value's representing dimensions.
	private Dimension _dim;
	//used to determine whether this particular tiled object should be solid, not allowing objects to pass through or over it. 
	//READ ONLY
	protected bool _solid;
	//represents the velocity of the tile through space. 
	private Point _vel;
	protected uint _tileType;
	// Use this for initialization
	void Start () {
		pos=new Point(0,0);
		dim=new Dimension(0,0);
		tileType=0x00;
	}
	public void hit(TiledObj obj){
	}
	// Update is called once per frame
	void Update () {
	
	}
		public Point vel{
		get {return _vel;}
	}
	public Point pos{
		get {return _pos;}
	}
	public Dimension dim{
		get {return _dim;}
	}
	public int width{
		get {return _dim.width;}
		set { _dim.width=value;}
	}
	public int height{
		get {return _dim.height;}
		set { _dim.height=value;}
	}
	public bool solid{
		get {return _solid;}
	}
	public uint tileType{
		get {return _tileType;}
	}
}
