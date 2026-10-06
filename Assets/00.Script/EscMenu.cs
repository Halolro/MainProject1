using UnityEngine;
using UnityEngine.InputSystem;

public class EscMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject sound;
    private bool isEsc;
    private bool isSound = false;
    void Start()
    {
        menu.SetActive(false);
        isEsc = false;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isSound)
            {
                isSound = false;
                sound.SetActive(false);
                return;
            }

            
            if (isEsc)
            {
                isEsc = false;
                menu.SetActive(false);
                return;
            }

            
            isEsc = true;
            menu.SetActive(true);
        }
    }

    public void ClickSoundPanel()
    {
        isEsc = false;
        menu.SetActive(false);

        isSound = true;
        sound.SetActive(true);
    }
}
