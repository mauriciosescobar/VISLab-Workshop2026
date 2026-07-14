using TMPro;
using UnityEngine;

public class SimpleForce : MonoBehaviour
{
	[SerializeField] private TextMeshPro status;

	private Rigidbody body;
	[SerializeField] private float force = 20f;

	private void Awake()
	{
		// Edit -> Project Settings -> Time

		/*
		 * Teste 1: 10  FixedUpdate
		 * Teste 2: 200 FixedUpdate
		 * Teste 3: 10  Update
		 * Teste 4: 200 Update
		 */
		// testar com 10 depois 200, alternando entre FixedUpdate e Update
		Application.targetFrameRate = 10; 
		QualitySettings.vSyncCount = 0;

		body = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		body.AddForce(Vector3.right * force);
	}


}
