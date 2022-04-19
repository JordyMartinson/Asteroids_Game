using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Toggle musicToggle;

    public void Start() {
        if(SaveManager.currentPlayer.getMusicVol() != null && !SaveManager.currentPlayer.isMuted()) {
            setVolume(SaveManager.currentPlayer.getMusicVol());
        } else if(SaveManager.currentPlayer.getMusicVol() != null && SaveManager.currentPlayer.isMuted()) {
            setVolume(SaveManager.currentPlayer.getTempMusicVol());
        } else {
            setVolume(1f);
        }
    }

    public void setVolume(float volume) {
        musicToggle.isOn = SaveManager.currentPlayer.isMuted();
        musicSlider.interactable = !SaveManager.currentPlayer.isMuted();

        // Debug.Log(SaveManager.currentPlayer.getMusicVol());
        // Debug.Log(SaveManager.currentPlayer.getTempMusicVol());


<<<<<<< Updated upstream

        // if(SaveManager.currentPlayer.isMuted()) {
        //     musicSlider.value = SaveManager.currentPlayer.getTempMusicVol();
        // } else {
        //     musicSlider.value = SaveManager.currentPlayer.getMusicVol();
        // }
=======
        if(SaveManager.currentPlayer.getSFXVol() != null && !SaveManager.currentPlayer.isSFXMuted()) {
            setSFXVolume(SaveManager.currentPlayer.getSFXVol());
        } else if(SaveManager.currentPlayer.getSFXVol() != null && SaveManager.currentPlayer.isSFXMuted()) {
            setSFXVolume(SaveManager.currentPlayer.getTempSFXVol());
        } else {
            setSFXVolume(1f);
        }
    }
>>>>>>> Stashed changes

        // musicSlider.value = SaveManager.currentPlayer.getMusicVol();
        // musicSlider.value = volume;
        audioMixer.SetFloat("MixerVolume", Mathf.Log10(volume) * 20);
        SaveManager.currentPlayer.setMusicVol(volume);
        SaveManager.SavePlayer(SaveManager.currentPlayer);
        musicSlider.value = volume;
        // Debug.Log(SaveManager.currentPlayer.getMusicVol() + " " + SaveManager.currentPlayer.getTempMusicVol());
    }

<<<<<<< Updated upstream
    public void muteUnmute(bool muted) {
        // musicSlider.interactable = !muted;
        SaveManager.currentPlayer.muteUnmute(muted);
=======
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
>>>>>>> Stashed changes
        musicSlider.interactable = !muted;
        if(muted) {
            // Debug.Log(SaveManager.currentPlayer.getMusicVol());
            // Debug.Log(SaveManager.currentPlayer.getTempMusicVol());
            
            // musicToggle.isOn = muted;
            Debug.Log("argh " +SaveManager.currentPlayer.getMusicVol());
            if(SaveManager.currentPlayer.getMusicVol() != 0.0001f) {
                SaveManager.currentPlayer.setTempMusicVol(SaveManager.currentPlayer.getMusicVol());
            }
            // Debug.Log(SaveManager.currentPlayer.getTempMusicVol());
            setVolume(0.0001f);
        } else {
            // Debug.Log("unmuted");
            Debug.Log("temp " + SaveManager.currentPlayer.getTempMusicVol());
            // SaveManager.currentPlayer.muteUnmute(muted);
            
            setVolume(SaveManager.currentPlayer.getTempMusicVol());
            
        }
        
    }
<<<<<<< Updated upstream
=======

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
>>>>>>> Stashed changes
}
