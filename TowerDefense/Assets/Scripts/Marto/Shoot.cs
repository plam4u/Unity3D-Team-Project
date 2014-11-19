using UnityEngine;
using System.Collections;

/// <summary>
/// <para>This script is responsible for detecting enemies in range and instantiate rockets.</para> <br />
/// <para>It doesn't do the actual moving of the rocket, instead it attaches another script (<see cref="TowerMissleEngine.cs"/>) to the rocket itself
/// and the attached script is responsible for moving.</para><br />
/// <para>The Shoot.cs script also handles the fire interval of the tower, which can be set through Unity.
/// It holds some public variables that are connected to the fired rocket but they are passed to the other script (TowerMissleEngine.cs)
/// which then makes use of them.</para>
/// </summary>
public class Shoot : MonoBehaviour
{
	/// <summary>
	/// The object that the tower is shooting.
	/// </summary>
	public GameObject TowerBlast;

	/// <summary>
	/// How much time the tower has to wait to attack again - attack speed.
	/// </summary>
	public float ReloadTime;

	/// <summary>
	/// The movement of the tower projectile. Used in the engine script.
	/// </summary>
	public float MissleSpeed = 5;

	/// <summary>
	/// The damage that the tower will deal to enemies. Used in the engine script.
	/// </summary>
	public float MissleDamage = 5;
	private GameObject enemy;
	private float nextFireTime = 0;
	
	/// <summary>
	/// Raises the trigger enter event.
	/// When something enteres the collider of the object this method is called.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter (Collider other)
	{
		bool hasEnemy = enemy == null ? false : true;
		if (!hasEnemy) {
			enemy = ReturnEnemyInRange (other);
		}
	}

	/// <summary>
	/// If there is an object currently in the trigger range.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay (Collider other)
	{
		bool isAllowedToFire = enemy != null && Time.time >= nextFireTime;
		if (isAllowedToFire) {
			FireProjectile (enemy);
			nextFireTime = Time.time + (ReloadTime * .5f);
		} 
	}
	
	/// <summary>
	/// Called when something leaves the trigger.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit (Component other)
	{
		if (other.CompareTag ("Enemy")) {
			enemy = null;
		}
	}
	
	/// <summary>
	/// Calculates when the next attack should happen and calls InitializeTowerMissle.
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	void FireProjectile (GameObject enemy)
	{
		// Play audio here if any.
		//audio.Play();
		nextFireTime = CalculateNextFire (nextFireTime);
		InitializeTowerMissle ();
	}
	
	/// <summary>
	/// Returns the object in range if it is enemy.
	/// </summary>
	/// <returns>The enemy in range.</returns>
	/// <param name="other">Other.</param>
	private GameObject ReturnEnemyInRange (Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			return other.gameObject;
		} else {
			return null;
		}
	}
	
	/// <summary>
	/// Calculates the next fire.
	/// </summary>
	/// <returns>The time when the tower can fire again..</returns>
	/// <param name="nextFire">Next fire.</param>
	private float CalculateNextFire (float nextFire)
	{
		nextFire = Time.time + ReloadTime;
		return nextFire;
	}
	
	/// <summary>
	/// Creates a clone from the Rocket Prefab, attaches a script for moving and directing the rocket and passes some variables to be used by the script.
	/// </summary>
	private void InitializeTowerMissle ()
	{
		// Initialize the missle at towers position and rotation.
		GameObject towerBlastClone = (GameObject)Instantiate (TowerBlast, transform.position, Quaternion.Euler (transform.rotation.x, transform.rotation.y, transform.rotation.z));
		//When the missle is initialized add a script to it to handle it's movement.
		TowerMissleEngine missleEngine = towerBlastClone.AddComponent<TowerMissleEngine> ();
		
		// Because the script is set at runtime we need to pass parameters to it at runtime. We can't do it from Unity because the rocket doesn't have
		// any script attach to it yet.
		// This basically sets the parameteres to the newly attached script.
		missleEngine.SetEnemy (enemy);
		missleEngine.SetMissleSpeed (MissleSpeed);
		missleEngine.SetMissleDamage (MissleDamage);
	}
}
