using UnityEngine;

public class GatherableResource : MonoBehaviour
{
    public int minAmount;
    public int maxAmount;
    int finalAmount;

    private void OnEnable ()
    {
        finalAmount = Random.Range ( minAmount, maxAmount );
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.gameObject.tag.Equals ( "Player Interaction Collider" ) )
        {
            PlayerResourceManager.AddResource ( gameObject.name, finalAmount );
            Destroy ( gameObject );
        }
    }
}
