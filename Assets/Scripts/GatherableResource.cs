using System.Collections;
using System.Collections.Generic;
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
        if ( collision.gameObject.tag.Equals ( "Player" ) )
        {
            PlayerResourceManager.AddResource ( gameObject.name, finalAmount );
            Destroy ( gameObject );
        }
    }
}
