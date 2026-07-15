using UnityEngine;

public class TrapController : MonoBehaviour
{
	[SerializeField] private int damage = 30;

	public int Damage => damage;

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<PlayerController>(out PlayerController player))
		{
			player.TakeDamage(damage);

			Destroy(gameObject);
		}
	}
}
