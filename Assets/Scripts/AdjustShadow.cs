using UnityEngine;

public class AdjustShadow : MonoBehaviour
{
    Color spriteColor;
    SpriteRenderer spriteRenderer;

	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
	}
	
	void FixedUpdate ()
    {
        spriteColor.a = Mathf.Min(DayNightCycle.lightIntensity, .5f);
        
        spriteRenderer.color = spriteColor;
	}
}
