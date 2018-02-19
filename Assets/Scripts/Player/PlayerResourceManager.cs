using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour {

    /* Maps resource name to the amount the player has. */
    private static Dictionary<string, int> resourceAmounts = new Dictionary<string, int>();

    public string[] gatherableResources;

    private void Start ()
    {
        foreach (string resource in gatherableResources)
        {
            resourceAmounts.Add ( resource, 10 );
        }

        UpdatePlayerUI();
    }

    public static void AddResource(string resource, int amount)
    {
        int cloneStart = resource.IndexOf ( '(' );
        if (cloneStart != -1)
        {
            resource = resource.Remove ( cloneStart );
        }
        
        if (!resourceAmounts.ContainsKey( resource ) )
        {
            Debug.LogError ( "Can't add resource *" + resource + "*. Add it in PlayerResourceManager.Start()" );
            return;
        }
        resourceAmounts[ resource ] += amount;
        Debug.Log ( "New amount of " + resource + ": " + resourceAmounts[ resource ] );

        UpdatePlayerUI();
    }

    public static int GetResourceCount(string resource)
    {
        return resourceAmounts[ resource ];
    }

    public static int DecreaseResourceCount(string resource, int amount)
    {
        resourceAmounts[resource] = resourceAmounts[ resource ] - amount;
        UpdatePlayerUI();
        return resourceAmounts[resource];
    }

    public static void UpdatePlayerUI()
    {
        PlayerUI.ammoText.text = "Ammo: " + resourceAmounts[StringConstants.LightAmmo].ToString();
        PlayerUI.woodText.text = "Wood: " + resourceAmounts[StringConstants.WoodMaterial].ToString();
        PlayerUI.leadText.text = "Lead: " + resourceAmounts[StringConstants.LeadMaterial].ToString();
    }
}
