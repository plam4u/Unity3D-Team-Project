using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	public GameObject bullet;

	private GameObject player;
	private float speed;
	private float fireRate;
	private float nextFire;
	private float chaseDistance;
	private float fireDistance;
	private float closeupDistance;

	void Start()
	{
		nextFire = 0;
		fireRate = 0.75f;
		speed = 5;

		chaseDistance = 50;
		fireDistance = 15;
		closeupDistance = 7;

		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (player == null) return;

		float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

		transform.LookAt(player.transform);
		if (distanceToPlayer < closeupDistance)
		{
			rigidbody.velocity = -transform.forward * speed;
		}
		else if (distanceToPlayer < fireDistance)
		{
			rigidbody.velocity *= 0.99f;

			if(nextFire < Time.time)
			{
				GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
				Vector3 position = transform.position;
				position.x += Mathf.Sin(transform.rotation.eulerAngles.y / 180 * Mathf.PI) * 1;
				position.z += Mathf.Cos(transform.rotation.eulerAngles.y / 180 * Mathf.PI) * 1;
				bulletClone.transform.position = position;

				nextFire = Time.time + fireRate;
			}
		}
		else if (distanceToPlayer < chaseDistance)
		{
			rigidbody.velocity = transform.forward * speed;
		}
	}
}

