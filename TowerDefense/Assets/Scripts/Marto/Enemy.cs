using UnityEngine;
using System.Collections;

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
