﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour {

    /* Maps resource name to the amount the player has. */
    static Dictionary<string, int> resourceAmounts = new Dictionary<string, int>();

    public string[] gatherableResources;

    private void Start ()
    {
        foreach (string resource in gatherableResources)
        {
            resourceAmounts.Add ( resource, 0 );
        }
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
            Debug.LogError ( "Can't add resource *" + resource + "*. Add it in Start()" );
            return;
        }
        resourceAmounts[ resource ] += amount;
        Debug.Log ( "New amount of " + resource + ": " + resourceAmounts[ resource ] );
    }
}
