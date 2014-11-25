using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public int HealthPoints;
	public int MaxHealth = 100;
	public float HealthBarLength;
	public int ArmorPoints;
	private int height;
	private bool isAlive = true;
    private string direction = "first";
	
	void Start ()
	{
		HealthPoints = MaxHealth;
		height = -100;
	}

	// Update is called once per frame
	void Update ()
	{
		if (!isAlive) {
			Destroy (gameObject);
			//TODO: Add explosion here or some die effect.
		}

        MoveEnemy();
	}

    private void MoveEnemy()
    {
        if (direction == "first")
        {
            this.transform.Translate(-1 * Time.deltaTime, 0, 0);
            if (this.transform.position.x <= 27)
            {
                direction = "second";
            }
        }
        else if (direction == "second")
        {
            this.transform.Translate(0, 0, 1 * Time.deltaTime);
            if (this.transform.position.z >= 21)
            {
                direction = "third";
            }
        }
        else if(direction == "third")
        {
            this.transform.Translate(-1 * Time.deltaTime, 0, 0);
            if (this.transform.position.x <= 5)
            {
                Destroy(this.gameObject);
            }
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
		HealthBarLength = (Screen.width / 6) * (HealthPoints / (float)MaxHealth);
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
	
//	void OnGUI ()
//	{
//		GUI.Box (new Rect (700, 10, HealthBarLength, 20), HealthPoints + "/" + MaxHealth);
//	}

	void OnGUI ()
	{
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		//TODO: Extract the hardcoded variables - 60 and 20 because longer text appear out of the bar.
		GUI.Box (new Rect (targetPos.x, Screen.height - targetPos.y + height, 60, 20), HealthPoints + "/" + MaxHealth);
	}
}
