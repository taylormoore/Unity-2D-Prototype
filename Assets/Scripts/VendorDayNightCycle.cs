using UnityEngine;

public class VendorDayNightCycle : MonoBehaviour
{
    public bool isOpen;
    public GameObject[] sprites;

    private void FixedUpdate()
    {
        if ( DayNightCycle.timeOfDay == DayNightCycle.TimeOfDay.day && !isOpen)
        {
            ToggleAvailability();
        }
        else if (DayNightCycle.timeOfDay == DayNightCycle.TimeOfDay.night && isOpen )
        {
            ToggleAvailability();
        }
    }

    public void ToggleAvailability()
    {
        isOpen = !isOpen;
        foreach(GameObject sprite in sprites)
        {
            sprite.SetActive(isOpen);
        }
    }
}
