using UnityEngine;

public class DayNightCycle : MonoBehaviour
{	
	private float dayTimer;
    private bool isSunRising;
    private float dayLength =  600;
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

        if ( dayTimer == dayLength )
        {
            isSunRising = false;
        }
        else if (dayTimer == 0)
        {
            isSunRising = true;
        }

        if ( isSunRising )
        {
            dayTimer++;
        }
        else
        {
            dayTimer--;
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
