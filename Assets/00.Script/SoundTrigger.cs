using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private SoundManager.SFXType sfxType;

    public void TriggerSFX()
    {
        SoundManager.Instance.PlaySFX(sfxType);
    }
}