using UnityEngine;

public class BallController : MonoBehaviour
{
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Activate()
	{
		rb.isKinematic = false;
	}

}
