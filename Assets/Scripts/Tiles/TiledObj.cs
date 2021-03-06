using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Timers;

public class TiledObj : GDCObject {
	//TiledObj class represents any object that can be displayed and manipulated withing the grid structure of the game. 
	
	//grid index of the tiled object. Represents it's upper left corner. 
	private Point _pos = new Point(0,0);
	//grid value's representing dimensions.
	private Dimension _dim=new Dimension(1,1);
	public static int TILE_SIZE = 6;
	//used to determine whether this particular tiled object should be solid, not allowing objects to pass through or over it. 
	//READ ONLY
	protected bool _solid;
	protected bool isMoving=false;
	//represents the velocity of the tile through space. 
	private Point _vel;
	protected uint _tileType=0x00;
	// Use this for initialization
	public string hello= "hello";
	public int depth=0;
	protected GridController grid;
	//boolean value used to disable tile movement. Indicates to different systems that the tiel is cirrently animating, or is in some kind of transition. 
	protected bool _canMove=true;
	private float oldX;
	private float oldY;
	private float moveAngle;
	private float cos;
	private float sin;
	private float startMoveTime;
	protected float moveTime=30;
	private float moveDist;
	private float dx;
	private float dy;
	void Start () {
		//does start get called more than once? SOmething like that. Was breaking my stuff. So I needed to instantiate  _point up above. 
		//__pos=new Point(0,0);
		
		//_dim=
		
		grid=(GridController)GameObject.FindObjectOfType(typeof(GridController));
	}
	public void hit(TiledObj obj){
	}
	// Update is called once per frame
	void Update () {
		moveTile();
	}
	//return true if this method is meant to change velocity of the tile it is hitting. False if no change is intended. 
	public virtual void collide(TiledObj tile){
		
	}
	public virtual void onOver(TiledObj tile){
		
	}
	public virtual void onLeave(TiledObj tile){
		
	}
	protected void moveTile()
	{
		float timeDiff=Time.fixedTime*100-startMoveTime;
			if(timeDiff>=moveTime)
		{
			if(isMoving)
			{
				isMoving=false;
				movementComplete();
				Vector3 setPos = new Vector3(
				oldX+cos*moveDist,
				depth,
				oldY+sin*moveDist
				);
				this.transform.position=setPos;
			}
		}else{
			Vector3 setPos = new Vector3(
				oldX+cos*((timeDiff/moveTime)*moveDist),
				depth,
				oldY+sin*((timeDiff/moveTime)*moveDist)
				);
			this.transform.position=setPos;
		}
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
		//convert from seconds to milli
		startMoveTime=Time.fixedTime*100;
		isMoving=true;
		oldX=transform.position.x;
		oldY=transform.position.z;
		dx=(x*TILE_SIZE-oldX);
		dy=(y*TILE_SIZE-oldY);
		moveDist = Mathf.Sqrt(dx*dx+dy*dy);
		moveAngle=Mathf.Atan2(dy,dx);
		cos=Mathf.Cos(moveAngle);
		sin=Mathf.Sin(moveAngle);

		_pos.x=x;
		_pos.y=y;
}
		public void setVel(int x, int y)
	{
		if(_canMove)
		{
		_vel.x=x;
		_vel.y=y;
			if(!(x==0 &&y==0)){
				//TODO:
				//because of how untiy instantiated prefabs, sometimes the GridCOntroller is not available when this object instantiates. This fetches it whenver it is needed. 
				//Im assuming this in not very efficient. 
				grid=(GridController)GameObject.FindObjectOfType(typeof(GridController));
			grid.resolveMovement(this);
			}
		}
		
}
		public void stopVel()
	{
		_vel.x=0;
		_vel.y=0;
		
}
	public void completeMovement()
	{
		
	}
	//the physics engine does a collide the instant a tile wants to move into a space. 
	//some actions need to wait until the movement of said tile is complete before triggering. 
	//because of this, we have created another kind of collision that needs to be defined by the object animating. 
	public void movementComplete()
	{
			grid=(GridController)GameObject.FindObjectOfType(typeof(GridController));
			grid.doOverCollide(this);
	}public class Timer1
 {
 
     public static void Main()
     {
      
     }
 }
}
