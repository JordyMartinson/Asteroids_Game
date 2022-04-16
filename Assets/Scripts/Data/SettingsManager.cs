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



        // if(SaveManager.currentPlayer.isMuted()) {
        //     musicSlider.value = SaveManager.currentPlayer.getTempMusicVol();
        // } else {
        //     musicSlider.value = SaveManager.currentPlayer.getMusicVol();
        // }

        // musicSlider.value = SaveManager.currentPlayer.getMusicVol();
        // musicSlider.value = volume;
        audioMixer.SetFloat("MixerVolume", Mathf.Log10(volume) * 20);
        SaveManager.currentPlayer.setMusicVol(volume);
        SaveManager.SavePlayer(SaveManager.currentPlayer);
        musicSlider.value = volume;
    }

    public void muteUnmute(bool muted) {
        // musicSlider.interactable = !muted;
        SaveManager.currentPlayer.muteUnmute(muted);
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
}
