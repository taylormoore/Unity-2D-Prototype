using UnityEngine;

public class AdjustSortingOrder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100f);
    }
}
