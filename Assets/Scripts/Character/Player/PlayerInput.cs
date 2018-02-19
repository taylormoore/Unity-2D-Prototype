using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static float movementHorizontal = 0f;
    public static float movementVertical = 0f;
    public static Vector3 mousePosition;

    Camera mainCamera;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start ()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        movementHorizontal = Input.GetAxis("Horizontal");
        movementVertical = Input.GetAxis("Vertical");
        mousePosition = mainCamera.ScreenToWorldPoint ( Input.mousePosition );
    }
}
