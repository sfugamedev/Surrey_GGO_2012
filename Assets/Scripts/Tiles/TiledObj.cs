using UnityEngine;
using System.Collections;

public class TiledObj : GDCObject {
	//TiledObj class represents any object that can be displayed and manipulated withing the grid structure of the game. 
	
	//grid index of the tiled object. Represents it's upper left corner. 
	private Point _pos = new Point(0,0);
	//grid value's representing dimensions.
	private Dimension _dim=new Dimension(1,1);
	public static int TILE_SIZE = 16;
	//used to determine whether this particular tiled object should be solid, not allowing objects to pass through or over it. 
	//READ ONLY
	protected bool _solid;
	protected bool _canMove;
	//represents the velocity of the tile through space. 
	private Point _vel;
	protected uint _tileType;
	// Use this for initialization
	public string prefabName= "Tile";
	public int depth=0;
	void Start () {
		//does start get called more than once? SOmething like that. Was breaking my stuff. So I needed to instantiate  _point up above. 
		//__pos=new Point(0,0);
		
		//_dim=
		_tileType=0x00;
	}
	public void hit(TiledObj obj){
	}
	// Update is called once per frame
	void Update () {
		moveTile();
	}
	public virtual void collide(TiledObj tile){
	}
	protected void moveTile(){
		int tileSize= TILE_SIZE;
		Vector3 setPos = new Vector3(transform.position.x+(_pos.x*tileSize-transform.position.x)/40, transform.position.y+(_pos.y*tileSize-transform.position.y)/40, depth*-1);
		//Simply calling position.Set() did not change the positon. Need to set it to a new Vector3 object. 
		this.transform.position=setPos;
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
	public bool canMove{
		get {return _canMove;}
	}
	public uint tileType{
		get {return _tileType;}
	}
	public int x{
		get {return _pos.x;}
		set {_vel.x=value;}
	}
		public int y{
		get {return _pos.y;}
		set {_vel.y=value;}
	}
	public void setPos(int x, int y)
	{
		_pos.x=x;
		_pos.y=y;	
	}
	public void setVel(int x, int y)
	{
		_vel.x=x;
		_vel.y=y;
	}
	public void stopVel()
	{
		_vel.x=0;
		_vel.y=0;
	}
}
