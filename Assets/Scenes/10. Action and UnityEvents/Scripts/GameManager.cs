using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PlayerController player;

	[SerializeField] private TextMeshProUGUI playerHealth;
	[SerializeField] private TextMeshProUGUI messageLog;

	private void Awake()
	{
		messageLog.text = "";
	}

	void OnEnable()
	{
		player.OnPlayerDied += HandlePlayerDied;
		player.OnDamageTaken += HandleDamageTaken;
	}

	private void Start()
	{
		UpdateUI();
	}

	void OnDisable()
	{
		player.OnPlayerDied -= HandlePlayerDied;
		player.OnDamageTaken -= HandleDamageTaken;
	}

	private void HandlePlayerDied()
	{
		playerHealth.text = "Game Over";
	}

	private void HandleDamageTaken(int amount)
	{
		messageLog.text = $"Jogador tomou {amount} de dano.";

		StartCoroutine(LogClear());

		UpdateUI();
	}
	
	private void UpdateUI()
	{
		playerHealth.text = "Health: " + player.Health;
	}

	private IEnumerator LogClear()
	{
		yield return new WaitForSeconds(3f);

		messageLog.text = "";
	}
}
