using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

	public int HealthPoints;
	public int ArmorPoints;
	private bool isAlive = true;
	
	// Update is called once per frame
	void Update ()
	{
		if (!isAlive) {
			Destroy (gameObject);
			//TODO: Add explosion here or some die effect.
		}
	}

	/// <summary>
	/// This method is called by the tower projectile and decreases the enemies health, based on the tower damage.
	/// </summary>
	/// <param name="missileDamage">Missile damage.</param>
	public void TakeDamage (float missileDamage)
	{
		double damageReduction = CalculateDamageReduction (ArmorPoints);
		HealthPoints -= CalculateHealthLoss (missileDamage, damageReduction);
		if (HealthPoints <= 0) {
			isAlive = false;
		}
	}

	private double CalculateDamageReduction (int armor)
	{
		return ((0.6 * ArmorPoints) % (1 + 0.6 * ArmorPoints));
	}

	private int CalculateHealthLoss (float missileDamage, double damageReduction)
	{
		int healthLoss = (int)(missileDamage - damageReduction);
		return healthLoss;
	}
}
