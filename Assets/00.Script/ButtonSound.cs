using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundTrigger : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(PlayButtonSound);
    }

    private void PlayButtonSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFXType.Button);
        }
    }
}