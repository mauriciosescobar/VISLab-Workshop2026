using UnityEngine;

public class BasicWASDController : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private float rotationSpeed = 100f;

	void Update()
	{
		float verticalMovement = Input.GetAxis("Vertical");  
		float horizontalMovement = Input.GetAxis("Horizontal");

		transform.Translate(Vector3.forward * verticalMovement * speed * Time.deltaTime);
		transform.Rotate(Vector3.up * horizontalMovement * rotationSpeed * Time.deltaTime);
	}
}
