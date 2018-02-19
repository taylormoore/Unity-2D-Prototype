using UnityEngine;

public class VendorDayNightCycle : MonoBehaviour
{
    public bool isOpen;
    public GameObject[] sprites;

    private void Start ()
    {
        DayNightCycle.dayNightListeners += ToggleAvailability;
    }

    public void ToggleAvailability(DayNightCycle.TimeOfDay timeOfDay)
    {
        isOpen = (timeOfDay == DayNightCycle.TimeOfDay.day);
        foreach(GameObject sprite in sprites)
        {
            sprite.SetActive(isOpen);
        }
    }
}
