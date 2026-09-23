using UnityEngine;
using UnityEngine.InputSystem;

public class EscMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject Sound;
    private bool isEsc;
    void Start()
    {
        menu.SetActive(false);
        isEsc = false;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            isEsc = !isEsc;
            menu.SetActive(isEsc);
        }
    }

    public void ClickSoundPanel()
    {
        Sound.SetActive(true);
        isEsc = !isEsc;
        menu.SetActive(isEsc);
    }
}
