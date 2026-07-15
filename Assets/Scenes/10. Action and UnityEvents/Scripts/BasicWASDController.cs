using UnityEngine;

public class BasicWASDController : MonoBehaviour
{
	[SerializeField] private float velocidade = 5f;
	[SerializeField] private float velocidadeRotacao = 100f;

	void Update()
	{
		float mover = Input.GetAxis("Vertical");  
		float rotacionar = Input.GetAxis("Horizontal");

		transform.Translate(Vector3.forward * mover * velocidade * Time.deltaTime);
		transform.Rotate(Vector3.up * rotacionar * velocidadeRotacao * Time.deltaTime);
	}
}
