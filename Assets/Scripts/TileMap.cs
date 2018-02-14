using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {
	//Place a gameobject with a sprite renderer attached and the grass tile in that. 
	//Create it into a prefab and place it into your "Resources" folder.
	public Transform tilePrefab;

	//Tilemap width and height
	public int mapWidth = 5;
	public int mapHeight = 5;
	public float mapX = 0f;
	public float mapY = 0f;
	public float mapZ = 0f;

	//Size you want your tile in unity units
	public float tileSize = 1f;

	//2D array to hold all tiles, which makes it easier to reference adjacent tiles etc.
	public Transform[, ] map;

	void Start () {
		transform.position = new Vector3(mapX, mapY, mapZ);
		Debug.Log("Map Position: " + transform.position.x + " :: " + transform.position.y + " :: " + transform.position.z);

		//Load prefab "Grass" from "Resources/Prefabs/" folder.
		tilePrefab = Resources.Load<Transform> ("Prefabs/Floor0");

		//If we can't find the prefab then log a warning.
		if (!tilePrefab)
			Debug.LogWarning ("Unable to find TilePrefab in your Resources folder.");

		//Initialize our 2D Transform array with the width and height
		map = new Transform[mapWidth, mapHeight];

		//Iterate over each future tile positions for x and y
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				//Instantiate tile prefab at the desired position as a Transform object
				Transform tile = Instantiate (tilePrefab, new Vector3 (x * tileSize + transform.position.x + tileSize, y * tileSize + transform.position.y + tileSize, 0 + transform.position.z), Quaternion.identity) as Transform;
				//Set the tiles parent to the GameObject this script is attached to
				tile.parent = transform;
				//Set the 2D map array element to the current tile that we just created.
				map[x, y] = tile;
			}
		}
	}

	//Returns a tile from the map array at x and y
	public Transform GetTileAt (int x, int y) {
		if (x < 0 || y < 0 || x > mapWidth || y > mapHeight) {
			Debug.LogWarning ("X or Y coordinate is out of bounds!");
			return null;
		}
		return map[x, y];
	}

	void Update () {

	}
}