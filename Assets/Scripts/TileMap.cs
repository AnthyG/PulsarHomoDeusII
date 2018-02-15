using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	public Transform[] tilePrefabs;

	// 333303333200000002200000002200000002200000002200000002200000002200000002333333333

	// 000000000000000020000000000000000000000000000000000000000000000000000010000000000

	// 333333333200000012200000002200000002200000002200000002200000002200000002333303333
	public string mapPreset;

	public Transform[, ] map;

	public int mapWidth = 5;
	public int mapHeight = 5;

	public float mapX = 0f;
	public float mapY = 0f;
	public float mapZ = 0f;

	public float tileSize = 1f;

	private Transform tilePrefab;

	void Start () {
		transform.position = new Vector3 (mapX, mapY, mapZ);
		Debug.Log ("Map Position: " + transform.position.x + " :: " + transform.position.y + " :: " + transform.position.z);

		// Debug.Log ("TilePrefabs: " + tilePrefabs.Length);

		// for (int i = 0; i < tilePrefabs.Length; i++)
		// Debug.Log ("tilePrefab: " + i + " :: " + tilePrefabs[i]);

		// Debug.Log (mapPreset + " :: " + mapPreset.Length);

		// for (int i = 0; i < mapPreset.Length; i++)
		// Debug.Log ("tileIndex: " + i + " :: tileType: " + mapPreset[i]);

		map = new Transform[mapWidth, mapHeight];

		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				// Debug.Log ("x, y: " + x + ", " + y + " :: " + mapWidth + " :: " + (y * mapWidth + x));

				int tileIndex = (y * mapWidth + x);
				int tileType = (int) char.GetNumericValue (mapPreset[tileIndex]);

				tilePrefab = tilePrefabs[tileType];

				// Debug.Log (tileIndex + " :: " + tileType + " :: " + mapPreset[tileIndex] + " :: " + tileType + " :: " + tilePrefab);

				if (!tilePrefab)
					Debug.LogWarning ("Unable to find TilePrefab in your Resources folder.");

				Transform tile = Instantiate (tilePrefab, new Vector3 (x * tileSize + transform.position.x + tileSize, y * tileSize + transform.position.y + tileSize, 0 + transform.position.z), Quaternion.identity) as Transform;

				tile.parent = transform;

				map[x, y] = tile;
			}
		}
	}

	void Update () {

	}
}