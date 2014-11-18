using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion_asteroid;
	public GameObject explosion_player;

	private GameController gameController;
	private Health health;
	
	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		if(gameController == null)
		{
			Debug.LogWarning("Cannot find the game controller");
		}

		health = GetComponent<Health>();
		if(health == null)
		{
			//Debug.LogWarning("Cannot find Health component!");
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (other.tag == "Player")
		{
			//Debug.Log("Player hit!");
			Destroy(transform.gameObject);

			if (explosion_player != null)
			{
				Instantiate(explosion_player, transform.position, transform.rotation);
			}
			Application.LoadLevel("Scene_03_ExperimentingUI");
		}

		if(other.tag == "Bullet")
		{
			if(health != null)
			{
				health.health -= 15;

				if (health.health <= 0)
				{
					Destroy(transform.gameObject);

					if (explosion_player != null)
					{
						Instantiate(explosion_player, transform.position, transform.rotation);
					}
				}
			}
			else
			{
				Destroy(transform.gameObject);

				if (explosion_player != null)
				{
					Instantiate(explosion_player, transform.position, transform.rotation);
				}
			}

			if (explosion_asteroid != null)
			{
				Instantiate(explosion_asteroid, transform.position, transform.rotation);
			}
		}

		Destroy(other.gameObject);
	}
}
