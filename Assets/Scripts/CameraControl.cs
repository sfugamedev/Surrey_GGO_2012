using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	private Dimension worldSize;
	private Dimension centerPoint;
	private int tileSize;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Game theGame = (Game)FindObjectOfType(typeof(Game));
		Level theLevel = theGame.getLevel();

		worldSize = theLevel.getLevelDimensions();
		tileSize = TiledObj.TILE_SIZE;
		centerPoint = new Dimension(0, 0);
		centerPoint.height = worldSize.height/2;
		centerPoint.width = worldSize.width/2;
		
		transform.position = new Vector3((centerPoint.width * tileSize)-3, transform.position.y, (centerPoint.height * tileSize)-3);
	
		// now to determine how much to zoom out, we need to look at what value (height or width) is larger
		// and then we need to zoom out that much
		
		// for now, we'll just fit it to the height of the game world and we can figure out if we want to make wider worlds later.
		Camera theCamera = gameObject.GetComponent<Camera>();
		theCamera.orthographicSize = 3*worldSize.height;
	}
}
