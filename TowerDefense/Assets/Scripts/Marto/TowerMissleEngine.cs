using UnityEngine;
using System.Collections;

/// <summary>
/// Script responsible for moving the tower projectile forward while looking at the enemy target.
/// It will continue to follow the target unless it hits something different then a tower.
/// </summary>
public class TowerMissleEngine : MonoBehaviour
{
    public static readonly int TowerCost = 500;
	private GameObject enemy;
	private float missileSpeed;
	private float missileDamage;

	public void SetEnemy (GameObject enemy)
	{
		this.enemy = enemy;
	}
	
	public GameObject GetEnemy ()
	{
		return enemy;
	}
	
	public void SetMissleSpeed (float missleSpeed)
	{
		this.missileSpeed = missleSpeed;
	}
	
	public float GetMissleSpeed ()
	{
		return this.missileSpeed;
	}
	
	public void SetMissleDamage (float missleDamage)
	{
		this.missileDamage = missleDamage;
	}
	
	public float GetMissleDamage ()
	{
		return missileDamage;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveTowerProjectile ();
	}
	
	/// <summary>
	/// Make the tower projectile chase the enemy.
	/// It is basically a hooming missle.
	/// </summary>
	private void MoveTowerProjectile ()
	{
		rigidbody.velocity = transform.forward * missileSpeed;
		
		Vector3 distancePos = enemy.transform.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation (distancePos);
		rigidbody.MoveRotation (Quaternion.RotateTowards (transform.rotation, targetRotation, 20));
	}

	void OnTriggerEnter (Collider other)
	{
		// TODO: Play explosion animation
		//Destroy rocket if it hits an enemy or something other than the tower that launched it.
		if (!other.gameObject.CompareTag ("Tower")) {
			Destroy (this.gameObject);
		}
		
		if (other.gameObject.CompareTag ("Enemy")) {
			DoDamageToEnemy (other.gameObject);
		}
	}
	
	//TODO: Implement method when enemy is ready.
	private void DoDamageToEnemy (GameObject enemy)
	{
		enemy.GetComponent<Enemy> ().TakeDamage (missileDamage);
	}
}
