using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer; // Reference to the Audio Mixer
    [SerializeField] string settingToMute;   // Name of the Audio Group to mute/unmute
    [SerializeField] Toggle toggle;
    private SaveManager saveManager;
    private bool isUserToggle = true;


    private void Awake()
    {
        saveManager = SaveManager.instance;
        SetMuteValues();
    }


    public void ToggleMute()
    {
        if (!isUserToggle) { return; }
        if (settingToMute == "MusicVolume")  saveManager.musicOn = !saveManager.musicOn;
        else saveManager.sfxOn = !saveManager.sfxOn;

        audioMixer.SetFloat(settingToMute, GetSaveManagerMuteData() ? 0f : -80f); // -80f is silence

        ///debug
        audioMixer.GetFloat(settingToMute, out float volume);
    }


    private void SetMuteValues()
    {
        bool isOn = GetSaveManagerMuteData();
        audioMixer.SetFloat(settingToMute, isOn ? 0f : -80f); // -80f is silence
        SetToggleState(isOn);
    }

    private bool GetSaveManagerMuteData()
    {
        return settingToMute == "MusicVolume" ? saveManager.musicOn : saveManager.sfxOn;
    }

    public bool IsGroupMuted()
    {
        float volume;
        audioMixer.GetFloat(settingToMute, out volume);
        return volume == -80f; // Check if volume is set to silence
    }

    // allow scripts to set the toggle state without triggering ToggleMute
    public void SetToggleState(bool state)
    {
        isUserToggle = false; // Mark this as a non-user-initiated change
        toggle.isOn = state;
        isUserToggle = true; // Reset the flag
    }
}
