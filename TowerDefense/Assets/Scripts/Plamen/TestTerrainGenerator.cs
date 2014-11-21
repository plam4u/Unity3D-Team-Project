using UnityEngine;
using System.Collections;

public class TestTerrainGenerator : MonoBehaviour {

	public Material materialGrass;
	public Material materialPath;

	private Material[] materials;
	private int[][] map;

	void Start () 
	{
		map = new int[19][];
		map[18] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[17] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[16] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[15] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[14] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[13] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[12] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[11] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[10] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[9] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[8] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[7] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[6] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[5] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[4] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[3] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[2] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[1] = new int[] { 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		map[0] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		
		materials = new Material[] { materialGrass, materialPath };
		GeneratePath();
	}

	void GeneratePath()
	{
		GameObject container = new GameObject();

		for(int y = 0; y < map.Length; y++)
		{
			for(int x = 0; x < map[0].Length; x++)
			{
				GameObject q = CreateQuadAt(x, y, materials[map[y][x]]);
				q.transform.parent = container.transform;
			}
		}

		container.transform.position = new Vector3(-Mathf.Round(map[0].Length / 2), 0f, -Mathf.Round(map.Length / 2));
	}

	GameObject CreateQuadAt(float x, float y, Material material)
	{
		GameObject q = GameObject.CreatePrimitive(PrimitiveType.Quad);
		q.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
		q.transform.position = new Vector3(x, 0f, y);
		q.renderer.material = material;
		return q;
	}
}
