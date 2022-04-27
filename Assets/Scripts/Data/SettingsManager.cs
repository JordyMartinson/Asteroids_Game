using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Toggle sfxToggle;

    private void Start() {
        setMusicVolume(SaveManager.currentPlayer.getMusicVol());
        setSFXVolume(SaveManager.currentPlayer.getSFXVol());
    }

    public void setMusicVolume(float volume) {
        musicToggle.isOn = SaveManager.currentPlayer.isMusicMuted();
        musicSlider.interactable = !SaveManager.currentPlayer.isMusicMuted();
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        SaveManager.currentPlayer.setMusicVol(volume);
        SaveManager.SavePlayer(SaveManager.currentPlayer);
        musicSlider.value = volume;
    }

    public void setSFXVolume(float volume) {
        sfxToggle.isOn = SaveManager.currentPlayer.isSFXMuted();
        sfxSlider.interactable = !SaveManager.currentPlayer.isSFXMuted();
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        SaveManager.currentPlayer.setSFXVol(volume);
        SaveManager.SavePlayer(SaveManager.currentPlayer);
        sfxSlider.value = volume;
    }

    private void musicMuteUnmute(bool muted) {
        SaveManager.currentPlayer.musicMuteUnmute(muted);
        musicSlider.interactable = !muted;
        if(muted) {
            if(SaveManager.currentPlayer.getMusicVol() != 0.0001f) {
                SaveManager.currentPlayer.setTempMusicVol(SaveManager.currentPlayer.getMusicVol());
            }
            setMusicVolume(0.0001f);
        } else {            
            setMusicVolume(SaveManager.currentPlayer.getTempMusicVol());
        }
    }

    private void sfxMuteUnmute(bool muted) {
        SaveManager.currentPlayer.sfxMuteUnmute(muted);
        sfxSlider.interactable = !muted;
        if(muted) {
            if(SaveManager.currentPlayer.getSFXVol() != 0.0001f) {
                SaveManager.currentPlayer.setTempSFXVol(SaveManager.currentPlayer.getSFXVol());
            }
            setSFXVolume(0.0001f);
        } else {
            setSFXVolume(SaveManager.currentPlayer.getTempSFXVol());
        }
    }
}
