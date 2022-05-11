using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAudioManager : MonoBehaviour
{
    [SerializeField]
    AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        audioController.Setting();
    }

}
