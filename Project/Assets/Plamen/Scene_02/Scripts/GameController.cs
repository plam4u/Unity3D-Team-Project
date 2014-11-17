using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public GameObject enemy;
	public GameObject asteroid;
	public GameObject playerCamera;
	
	private float nextAsteroid;
	private float nextEnemey;

	void Start()
	{
		nextAsteroid = 0;
	}

	void Update()
	{
		if(player == null)
		{
			return;
		}
		
		int boundaryHalfSize = 20;
		Vector3 p = player.transform.position;
		playerCamera.transform.position = new Vector3(p.x, 10, p.z);

		if(nextAsteroid < Time.time && player != null)
		{
			Vector3 position;
			float randomSide = Random.value;
			if(randomSide < 0.25f)
			{
				position = new Vector3(-boundaryHalfSize, 0.0f, Random.Range(-boundaryHalfSize, boundaryHalfSize));
			}
			else if (randomSide < 0.5)
			{
				position = new Vector3(boundaryHalfSize, 0.0f, Random.Range(-boundaryHalfSize, boundaryHalfSize));
			}
			else if (randomSide < 0.75)
			{
				position = new Vector3(Random.Range(-boundaryHalfSize, boundaryHalfSize), 0.0f, -boundaryHalfSize);
			}
			else 
			{
				position = new Vector3(Random.Range(-boundaryHalfSize, boundaryHalfSize), 0.0f, boundaryHalfSize);
			}
			
			GameObject asteroidClone = Instantiate(asteroid) as GameObject;
			asteroidClone.transform.position = position;
			asteroidClone.transform.LookAt(player.transform);
			float scale = Random.Range(0.5f, 2.0f);
			asteroidClone.transform.localScale = new Vector3(scale, scale, scale);

			Health asteroidHealth = asteroidClone.GetComponent<Health>();
			asteroidHealth.health *= scale;

			nextAsteroid = Time.time + 1.0f;
		}

		if(nextEnemey < Time.time && player != null)
		{
			Vector3 position = new Vector3(boundaryHalfSize, 0.0f, 0.0f);
			Instantiate(enemy, position, Quaternion.identity);

			nextEnemey += Time.time + 1.0f;
		}
	}
}
