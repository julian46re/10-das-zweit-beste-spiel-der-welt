using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour {

	public Terrain WorldTerrain;
	public LayerMask TerrainLayer;
	public static float TerrainLeft, TerrainRight, TerrainBottom, TerrainWidth, TerrainLength, TerrainHeight, TerrainTop;

	public static ArrayList units = new ArrayList();
	public static ArrayList positions = new ArrayList();
	public static ArrayList rotations = new ArrayList();

	public void Awake() {

		TerrainLeft = WorldTerrain.transform.position.x;
		TerrainBottom = WorldTerrain.transform.position.z;
		TerrainWidth = WorldTerrain.terrainData.size.x;
		TerrainLength = WorldTerrain.terrainData.size.z;
		TerrainHeight = WorldTerrain.terrainData.size.y;
		TerrainRight = TerrainLeft + TerrainWidth;
		TerrainTop = TerrainBottom + TerrainLength;

		InstantiateRandomPosition("Prefabs/Palme", 700, 0f);
		InstantiateRandomPosition("Prefabs/Kaktus", 600, 0f);

		
	}


	public void InstantiateRandomPosition(string Resource, int Amount, float AddedHeight) {

		var i = 0;
		float terrainHeight = 0f;
		RaycastHit hit;
		float randomPositionX, randomPositionY, randomPositionZ;
		Vector3 randomPosition = Vector3.zero;

		do {
			i++;
			randomPositionX = Random.Range (TerrainLeft, TerrainRight);
			randomPositionZ = Random.Range (TerrainBottom, TerrainTop);

			if (Physics.Raycast(new Vector3(randomPositionX, 9999f, randomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer)) {
				terrainHeight = hit.point.y;
			}

			randomPositionY = terrainHeight + AddedHeight;

			randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

			Instantiate(Resources.Load (Resource, typeof(GameObject)), randomPosition, Quaternion.identity);


		} while (i < Amount);



	}
}
