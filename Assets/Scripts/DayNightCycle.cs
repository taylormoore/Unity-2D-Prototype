﻿using UnityEngine;

public class DayNightCycle : MonoBehaviour
{	
	private float dayTimer;
    private bool isSunRising;
    public float dayLength =  600;
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
            PlayerUI.dayNightCycleIcon.sprite = PlayerUI.sun;
        }
        else
        {
            timeOfDay = TimeOfDay.night;
            PlayerUI.dayNightCycleIcon.sprite = PlayerUI.moon;
        }
    }
}
