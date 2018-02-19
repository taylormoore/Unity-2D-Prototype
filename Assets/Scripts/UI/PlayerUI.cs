using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text ammo;
    [SerializeField]
    private Text wood;
    [SerializeField]
    private Text lead;

    [SerializeField]
    private Image dayNight;

    [SerializeField]
    private Sprite sunSprite;
    [SerializeField]
    private Sprite moonSprite;

    public static Sprite sun;
    public static Sprite moon;

    public static Text ammoText;
    public static Text woodText;
    public static Text leadText;
    public static Image dayNightCycleIcon;

    private void Awake()
    {
        sun = sunSprite;
        moon = moonSprite;
        ammoText = ammo;
        woodText = wood;
        leadText = lead;
        dayNightCycleIcon = dayNight;
        DayNightCycle.dayNightListeners += OnDayNightCycle;
    }

    public void OnDayNightCycle(DayNightCycle.TimeOfDay timeOfDay)
    {
        if (timeOfDay == DayNightCycle.TimeOfDay.day)
        {
            dayNightCycleIcon.sprite = sun;
        }
        else
        {
           dayNightCycleIcon.sprite = moon;
        }
    }
}
