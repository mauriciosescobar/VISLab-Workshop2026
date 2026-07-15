using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public event Action OnPlayerDied;
	public event Action<int> OnDamageTaken;

	[SerializeField] private int maxHealth = 100;
	private int currentHealth;
	public int Health => currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
		Debug.Log("Stgart");
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		currentHealth = Mathf.Max(currentHealth, 0);

		OnDamageTaken?.Invoke(amount);

		if (currentHealth <= 0)
		{
			OnPlayerDied?.Invoke();

			GameOver();			
		}
	}

	private void GameOver()
	{
		GetComponent<BasicWASDController>().enabled = false;

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.useGravity = true;
		rb.AddExplosionForce(800, transform.position + new Vector3(0.2f, 0, 0.1f), 5, 3);
	}
}
