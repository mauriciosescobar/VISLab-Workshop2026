using UnityEngine;

public class WalkInCycles : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
	[SerializeField] private float amplitude = 5f;
	
	private Vector3 initialPosition;
	
	private void Awake()
	{
		initialPosition = transform.position;
	}

	private void Update()
	{
		float offset = Mathf.Sin(Time.time * speed) * amplitude;

		transform.position = initialPosition + Vector3.right * offset;
	}
}
