using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    static LinkedList<GameObject> players = new LinkedList<GameObject>();

    public static void AddPlayer( GameObject playerToAdd )
    {
        players.AddFirst ( playerToAdd );
    }

    public static GameObject GetNearestPlayer ( Vector2 seeker )
    {
        GameObject nearestPlayer = null;
        float distanceToNearestPlayer = float.PositiveInfinity;

        float currentDistance = 0f;
        foreach (GameObject player in players)
        {
            currentDistance = Vector2.Distance ( seeker, player.transform.position );
            if ( currentDistance < distanceToNearestPlayer )
            {
                distanceToNearestPlayer = currentDistance;
                nearestPlayer = player;
            }
        }
        return nearestPlayer;
    }
}
