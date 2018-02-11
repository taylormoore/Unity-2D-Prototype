using UnityEngine;

public class DayNightCycle : MonoBehaviour
{	
	private float dayTimer;
    private bool isDaytime = true;
    private float dayLength = 600;
    public Light ambientLight;
    float dayRatio;
    public enum TimeOfDay
    {
        day,
        night
    };

    public static TimeOfDay timeOfDay;

    private void Start()
    {
        dayTimer = dayLength;
    }

    void FixedUpdate ()
    {
        dayRatio = dayTimer / dayLength;

        if (isDaytime)
        {
            dayTimer--;

            ambientLight.intensity = (dayTimer / dayLength);        
        }
        else
        {
            dayTimer++;

            ambientLight.intensity = (dayTimer / dayLength);
        }

        if ( dayTimer >= dayLength )
        {
            isDaytime = !isDaytime;
            
        }
        else if (dayTimer <= 0)
        {
            isDaytime = !isDaytime;
            
        }

        if (dayRatio >= .5f )
        {
            timeOfDay = TimeOfDay.day;
            Debug.Log("day");
        }
        else
        {
            timeOfDay = TimeOfDay.night;
            Debug.Log("night");
        }

    }
}
