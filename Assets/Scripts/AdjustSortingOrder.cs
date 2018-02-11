using UnityEngine;

public class AdjustSortingOrder : MonoBehaviour
{
    public SpriteRenderer sr;

    private void Update()
    {
        sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100f);
    }
}
