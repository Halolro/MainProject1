using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public enum SFXType
    {
        Button,
        Casting,
        Catch,
        EquipGear,
        ShipClick,
        FacilityClick,
        GearClick,
        ProductComplete,
        SellItem
    }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource ambientSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("BGM & Ambient Clips")]
    [SerializeField] private AudioClip mainBGM;
    [SerializeField] private AudioClip ambientSea;

    [Header("SFX")]
    [SerializeField] private AudioClip buttonSFX;
    [SerializeField] private AudioClip castingSFX;
    [SerializeField] private AudioClip catchSFX;
    [SerializeField] private AudioClip equipGearSFX;
    [SerializeField] private AudioClip shipClickSFX;
    [SerializeField] private AudioClip facilityClickSFX;
    [SerializeField] private AudioClip gearClickSFX;
    [SerializeField] private AudioClip productCompleteSFX;
    [SerializeField] private AudioClip sellItemSFX;

    private Dictionary<SFXType, float> lastPlayTimes = new Dictionary<SFXType, float>();
    private const float SFX_COOLDOWN = 0.04f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeCooldowns();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMainBGM();
        PlayAmbientSea();
    }

    private void InitializeCooldowns()
    {
        foreach (SFXType type in System.Enum.GetValues(typeof(SFXType)))
        {
            lastPlayTimes[type] = 0f;
        }
    }

    private void PlayMainBGM()
    {
        if (mainBGM == null || bgmSource == null) return;
        bgmSource.clip = mainBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    private void PlayAmbientSea()
    {
        if (ambientSea == null || ambientSource == null) return;
        ambientSource.clip = ambientSea;
        ambientSource.loop = true;
        ambientSource.Play();
    }

    public void StopBGM() => bgmSource?.Stop();
    public void StopAmbientSea() => ambientSource?.Stop();

    public void PlaySFX(SFXType type)
    {
        if (sfxSource == null) return;
        if (Time.unscaledTime - lastPlayTimes[type] < SFX_COOLDOWN) return;

        AudioClip clip = GetSFXClip(type);

        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
            lastPlayTimes[type] = Time.unscaledTime;
        }
    }

    private AudioClip GetSFXClip(SFXType type)
    {
        switch (type)
        {
            case SFXType.Button: return buttonSFX;
            case SFXType.Casting: return castingSFX;
            case SFXType.Catch: return catchSFX;
            case SFXType.EquipGear: return equipGearSFX;
            case SFXType.ShipClick: return shipClickSFX;
            case SFXType.FacilityClick: return facilityClickSFX;
            case SFXType.GearClick: return gearClickSFX;
            case SFXType.ProductComplete: return productCompleteSFX;
            case SFXType.SellItem: return sellItemSFX;
            default: return null;
        }
    }

    public void SetBGMVolume(float volume) => bgmSource.volume = Mathf.Clamp01(volume);
    public void SetAmbientVolume(float volume) => ambientSource.volume = Mathf.Clamp01(volume);
    public void SetSFXVolume(float volume) => sfxSource.volume = Mathf.Clamp01(volume);
}