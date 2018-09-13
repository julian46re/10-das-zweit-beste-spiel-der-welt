using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour {


	public GameManager _GameManager;

	public Terrain WorldTerrain;
	public LayerMask TerrainLayer;
	public static float TerrainLeft, TerrainRight, TerrainBottom, TerrainWidth, TerrainLength, TerrainHeight, TerrainTop;

	public static ArrayList units = new ArrayList();
	public static ArrayList positions = new ArrayList();
	public static ArrayList rotations = new ArrayList();

	int scOld;

	public void Awake() {

		TerrainLeft = WorldTerrain.transform.position.x;
		TerrainBottom = WorldTerrain.transform.position.z;
		TerrainWidth = WorldTerrain.terrainData.size.x;
		TerrainLength = WorldTerrain.terrainData.size.z;
		TerrainHeight = WorldTerrain.terrainData.size.y;
		TerrainRight = TerrainLeft + TerrainWidth;
		TerrainTop = TerrainBottom + TerrainLength;

		InstantiateRandomPosition("Prefabs/Bad_Coconut", 700, 0.5f);
		InstantiateRandomPosition("Prefabs/Cactus_Tall", 2000, 0f);
		InstantiateRandomPosition("Prefabs/Good_Coconut", 500, 0.5f);
		InstantiateRandomPosition("Prefabs/Conifer_Desktop", 100, 0f);
		
	}

	public void Update() {

		int sc = _GameManager.GetComponent<GameManager>().score;

		if ((sc != scOld) && (sc > scOld)) {
			InstantiateRandomPosition("Prefabs/Cactus_Tall", 25, 0f);
			scOld = sc;
		}
	}

	public void InstantiateRandomPosition(string Resource, int Amount, float AddedHeight) {

		var i = 0;
		float terrainHeight = 0f;

		//Name = Resource.typeof(GameObject)

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

			if (hit.point.y < 1) {
				terrainHeight = -100;
			}

			randomPositionY = terrainHeight + AddedHeight;

			randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

			var NewCactus = (GameObject) Instantiate(Resources.Load (Resource, typeof(GameObject)), randomPosition, Quaternion.identity);
			NewCactus.name = Resource + i;

		} while (i < Amount);



	}
}
