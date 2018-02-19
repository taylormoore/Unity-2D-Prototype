using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static float movementHorizontal = 0f;
    public static float movementVertical = 0f;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        movementHorizontal = Input.GetAxis("Horizontal");
        movementVertical = Input.GetAxis("Vertical");
    }
}
