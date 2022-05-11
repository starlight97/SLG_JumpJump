using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioClip[] audioBackGroundBgm;
    private AudioSource audioSource;
    private int audioIndex = 0;
    private int backGroundBgmCount;
    private int currentIndex;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backGroundBgmCount = audioBackGroundBgm.Length;
        currentIndex = 0;
        StartCoroutine("Playlist");
        //PlaySound();
    }

    public void PlaySound()
    {
        audioSource.clip = audioBackGroundBgm[currentIndex];

        audioSource.Play();
    }

    public void StopSound()
    {
        StopCoroutine("Playlist");
        audioSource.Stop();
    }

    IEnumerator Playlist()
    {
        while (true)
        {
            if(currentIndex == backGroundBgmCount)
            {
                currentIndex = 0;
            }
            yield return new WaitForSeconds(0.5f);
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioBackGroundBgm[currentIndex];
                audioSource.Play();
                currentIndex++;
            }
        }
    }


}
