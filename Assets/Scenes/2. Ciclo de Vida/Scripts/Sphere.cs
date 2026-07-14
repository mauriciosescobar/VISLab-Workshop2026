using UnityEngine;

public class Sphere : MonoBehaviour
{
	[SerializeField] private Transform target;


	void Awake()
	{
		/*
		 * Dependência de outro objeto...
		 */

		transform.position = target.position + (Vector3.up * 3);
	}

}
