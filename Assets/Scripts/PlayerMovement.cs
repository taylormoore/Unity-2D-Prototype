using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField]
    float movementSpeed;

    float upDown;
    float leftRight;

    void Update() {
        transform.Translate(Vector3.up * PlayerInput.movementVertical * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * PlayerInput.movementHorizontal * movementSpeed * Time.deltaTime);
    }
}
