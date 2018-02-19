using UnityEngine;

public class VendorInteraction : MonoBehaviour
{

    public float interactRange;

    public GameObject vendorWindow;
    public bool canInteract;
    bool interactPressed;

    private void Update()
    {
        if ( Input.GetButtonDown("Interact") )
        {

        }
    }

    public void OnTriggerStay2D( Collider2D collision )
    {
        if (  && collision.gameObject.tag == "Player" )
        {
           
        }
        Debug.Log("Swag");
    }

    private void FixedUpdate()
    {
        Debug.Log(" Not Swag");
    }
}
