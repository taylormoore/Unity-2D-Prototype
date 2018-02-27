using UnityEngine;

public class RotateEnemyProjectileSpawn : MonoBehaviour
{

    public static Vector2 currentArmLocation;

    Transform playerPosition;

    private void Start()
    {
        playerPosition = PlayerManagement.GetNearestPlayer(transform.position).transform;
    }

    private void FixedUpdate()
    {
        currentArmLocation = transform.position;
        float rotationAmount = Utility.RotationAmount(transform.position, playerPosition.position);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
    }
}
