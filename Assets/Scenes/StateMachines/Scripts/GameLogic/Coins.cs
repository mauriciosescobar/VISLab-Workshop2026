using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }
}
