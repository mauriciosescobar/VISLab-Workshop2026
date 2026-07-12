using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;

    void Update()
    {
        float xDirection = 0;
        float yDirection = 0;
        
        if (Keyboard.current.wKey.isPressed) {
            yDirection = 1;
        }
        if (Keyboard.current.sKey.isPressed) {
            yDirection = -1;
        }
        if (Keyboard.current.aKey.isPressed) {
            xDirection = -1;
        }
        if (Keyboard.current.dKey.isPressed) {
            xDirection = 1;
        }

        Vector3 movement = new Vector3(xDirection, yDirection, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
