using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Toggle musicToggle;
    public Slider sfxSlider;
    public Toggle sfxToggle;

    public void Start() {
        if(SaveManager.currentPlayer.getMusicVol() != null) {
            setMusicVolume(SaveManager.currentPlayer.getMusicVol());
        } else {
            setMusicVolume(1f);
        }

        if(SaveManager.currentPlayer.getSFXVol() != null) {
            setSFXVolume(SaveManager.currentPlayer.getSFXVol());
        } else {
            setSFXVolume(1f);
        }
    }

    public void setMusicVolume(float volume) {
        musicToggle.isOn = SaveManager.currentPlayer.isMusicMuted();
        musicSlider.interactable = !SaveManager.currentPlayer.isMusicMuted();
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        SaveManager.currentPlayer.setMusicVol(volume);
        SaveManager.SavePlayer(SaveManager.currentPlayer);
        musicSlider.value = volume;
        Debug.Log(SaveManager.currentPlayer.getMusicVol() + " " + SaveManager.currentPlayer.getTempMusicVol());
    }

    public void setSFXVolume(float volume) {
        sfxToggle.isOn = SaveManager.currentPlayer.isSFXMuted();
        sfxSlider.interactable = !SaveManager.currentPlayer.isSFXMuted();
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        SaveManager.currentPlayer.setSFXVol(volume);
        SaveManager.SavePlayer(SaveManager.currentPlayer);
        sfxSlider.value = volume;
        // Debug.Log(SaveManager.currentPlayer.getSFXVol() + " " + SaveManager.currentPlayer.getTempSFXVol());
    }

    public void musicMuteUnmute(bool muted) {
        SaveManager.currentPlayer.musicMuteUnmute(muted);
        musicSlider.interactable = !muted;
        if(muted) {
            // Debug.Log(SaveManager.currentPlayer.getMusicVol());
            // Debug.Log(SaveManager.currentPlayer.getTempMusicVol());
            
            // musicToggle.isOn = muted;
            // Debug.Log("argh " +SaveManager.currentPlayer.getMusicVol());
            if(SaveManager.currentPlayer.getMusicVol() != 0.0001f) {
                SaveManager.currentPlayer.setTempMusicVol(SaveManager.currentPlayer.getMusicVol());
            }
            // Debug.Log(SaveManager.currentPlayer.getTempMusicVol());
            setMusicVolume(0.0001f);
        } else {
            // Debug.Log("unmuted");
            // Debug.Log("temp " + SaveManager.currentPlayer.getTempMusicVol());
            // SaveManager.currentPlayer.muteUnmute(muted);
            
            setMusicVolume(SaveManager.currentPlayer.getTempMusicVol());
            
        }
        
    }

    public void sfxMuteUnmute(bool muted) {
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
