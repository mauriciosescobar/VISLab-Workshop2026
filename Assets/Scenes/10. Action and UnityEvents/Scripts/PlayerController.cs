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
		Destroy(GetComponent<BasicWASDController>());

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.isKinematic = false;
		rb.useGravity = true;
		rb.AddExplosionForce(800, transform.position + new Vector3(0.2f, 0, 0.1f), 5, 3);
	}
}
