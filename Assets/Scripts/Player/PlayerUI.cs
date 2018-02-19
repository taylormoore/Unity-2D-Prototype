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

    public static Text ammoText;
    public static Text woodText;
    public static Text leadText;

    private void Awake()
    {
        ammoText = ammo;
        woodText = wood;
        leadText = lead;
    }
}
