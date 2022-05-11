using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameOption : MonoBehaviour
{
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
        DataManager.instance.systemData.audioBackGroundVolume = backGroundVolumeSlider.value;
        DataManager.instance.systemData.audioMasterVolume = masterVolumeSlider.value;
    }
}
