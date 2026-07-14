using UnityEngine;

public class SimpleObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

	void Update()
    {
        float yOffset = 1f;

        transform.position = target.position + (Vector3.up * yOffset);
        
    }
}
