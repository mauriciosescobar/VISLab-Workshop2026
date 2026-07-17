using UnityEngine;

public class InfiniteRotator : MonoBehaviour
{
    private float rotationSpeed = 10;

    
    void Update()
    {


        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);


    }
}
