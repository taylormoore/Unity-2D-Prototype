using UnityEngine;

public class DayNightCycle : MonoBehaviour
{	
	private float dayTimer;
    private bool isDaytime = true;
    private float dayLength = 600;
    public Light ambientLight;
    public static float lightIntensity;
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
        lightIntensity = dayTimer / dayLength;
        ambientLight.intensity = lightIntensity;


        if (isDaytime)
        {
            dayTimer--;    
        }
        else
        {
            dayTimer++;
        }

        if ( dayTimer >= dayLength )
        {
            isDaytime = !isDaytime;     
        }
        else if (dayTimer <= 0)
        {
            isDaytime = !isDaytime; 
        }

        if (lightIntensity >= .5f )
        {
            timeOfDay = TimeOfDay.day;
        }
        else
        {
            timeOfDay = TimeOfDay.night;
        }
    }
}
