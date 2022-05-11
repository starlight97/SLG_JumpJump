using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider backGroundVolumeSlider;
    [SerializeField]
    private Slider masterVolumeSlider;

    public void Setting()
    {
        float backGroundVolume = DataManager.instance.systemData.audioBackGroundVolume;
        float masterVolume = DataManager.instance.systemData.audioMasterVolume;

        backGroundVolumeSlider.value = backGroundVolume;
        masterVolumeSlider.value = masterVolume;

    }

    public void AudioControl()
    {
        float backGroundVolume = backGroundVolumeSlider.value;
        float masterVolume = masterVolumeSlider.value;

        if (backGroundVolume == -40f)
            backGroundVolume = -80;
        if (masterVolume == -40f)
            masterVolume = -80;

        audioMixer.SetFloat("BackGroundBGM", backGroundVolume);
        audioMixer.SetFloat("Master", masterVolume);

        DataManager.instance.systemData.audioBackGroundVolume = backGroundVolumeSlider.value;
        DataManager.instance.systemData.audioMasterVolume = masterVolumeSlider.value;
    }
}
