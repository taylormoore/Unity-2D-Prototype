using UnityEngine;

public class VendorInteraction : MonoBehaviour
{

    public float interactRange;

    public GameObject vendorWindow;
    bool shouldListen;
    bool showingWindow;

    private void Update()
    {
        if ( Input.GetButtonDown("Interact") && shouldListen)
        {
            ToggleVendorWindow(true);
        }
    }

    public void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.tag == "Player" )
        {
            shouldListen = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shouldListen = false;
            ToggleVendorWindow(false);
        }
    }

    public void ToggleVendorWindow(bool toggle)
    {
        vendorWindow.SetActive(toggle);
    }
}
