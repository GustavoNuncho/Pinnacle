using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("SFX Settings:")]
    public AudioClip[] sfxClips;
    public AudioSource sfxAudioSource;
    [Range(0, 1)] public float sfxVolume = 1f;
    private int sfxClipTestNumber = 0;


    [Header("BGM Settings:")]
    public AudioClip[] bgmClips;
    public AudioSource bgmAudioSource;
    [Range(0, 1)] public float bgmVolume = 0.3f;
    private int bgmClipTestNumber = 0;

    private void Awake()
    {
        instance = this;

        AudioSettings.LoadSettings(out sfxVolume, out bgmVolume);
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        sfxAudioSource.volume = sfxVolume;
        bgmAudioSource.volume = bgmVolume;
    }

    public void PlaySFX(int clip)
    {
        sfxAudioSource.PlayOneShot(sfxClips[clip]);
    }
    public void PlaySFX(InputField currentInput)
    {
        if (currentInput.text == "")
        {
            currentInput.text = "0";
        }
        
        int clip = int.Parse(currentInput.text);
        sfxAudioSource.PlayOneShot(sfxClips[clip]);
    }

    public void PlayBGM(int clip)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmClips[clip];
        bgmAudioSource.Play();
    }
    public void PlayBGM(InputField currentInput)
    {
        if (currentInput.text == "")
        {
            currentInput.text = "0";
        }

        int clip = int.Parse(currentInput.text);
        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmClips[clip];
        bgmAudioSource.Play();
    }

    // SFX Test Selection Functions****************************************************//
    public void IncrementSFXTestClip(InputField currentInput)
    {
        if (currentInput.text == "")
        {
            currentInput.text = "0";
        }
        else
        {
            sfxClipTestNumber++;

            if (sfxClipTestNumber > sfxClips.Length - 1)
            {
                sfxClipTestNumber = 0;
            }

            currentInput.text = sfxClipTestNumber.ToString();
        }
    }

    public void DecrementSFXTestClip(InputField currentInput)
    {
        if (currentInput.text == "")
        {
            currentInput.text = "0";
        }
        else
        {
            sfxClipTestNumber--;
            
            if (sfxClipTestNumber < 0)
            {
                sfxClipTestNumber = sfxClips.Length - 1;
            }

            currentInput.text = sfxClipTestNumber.ToString();
        }
    }
    //*********************************************************************************//

    // BGM Test Selection Functions****************************************************//
    public void IncrementBGMTestClip(InputField currentInput)
    {
        if (currentInput.text == "")
        {
            currentInput.text = "0";
        }
        else
        {
            bgmClipTestNumber++;

            if (bgmClipTestNumber > bgmClips.Length - 1)
            {
                bgmClipTestNumber = 0;
            }

            currentInput.text = bgmClipTestNumber.ToString();
        }
    }

    public void DecrementBGMTestClip(InputField currentInput)
    {
        if (currentInput.text == "")
        {
            currentInput.text = "0";
        }
        else
        {
            bgmClipTestNumber--;
            
            if (bgmClipTestNumber < 0)
            {
                bgmClipTestNumber = bgmClips.Length - 1;
            }

            currentInput.text = bgmClipTestNumber.ToString();
        }
    }
    //*********************************************************************************//

    public void ChangeSFXVolumeSettings(Slider sfxVolume)
    {
        this.sfxVolume = sfxVolume.value;
    }
    public void ChangeBGMVolumeSettings(Slider bgmVolume)
    {
        this.bgmVolume = bgmVolume.value;
    }

    public void SaveSettings()
    {
        AudioSettings.SaveSettings(sfxVolume, bgmVolume);
    }

    public void RestoreDefaultSettings()
    {
        AudioSettings.RestoreDefaultSettings(out sfxVolume, out bgmVolume);
    }
    public void RestoreDefaultSFXSlider(Slider sfxVolume)
    {
        sfxVolume.value = 1.0f;
    }
    public void RestoreDefaultBGMSlider(Slider bgmVolume)
    {
        bgmVolume.value = 0.3f;
    }

}

public static class AudioSettings
{
    // Default values
    public static float savedSFXVolume = 1.0f;
    public static float savedBGMVolume = 0.3f;
    
    public static void SaveSettings(float sfxVolume, float bgmVolume)
    {
        savedSFXVolume = sfxVolume;
        savedBGMVolume = bgmVolume;

        //Debug.Log("savedSFXVolume: " + savedSFXVolume);
        //Debug.Log("savedBGMVolume: " + savedBGMVolume);
    }

    public static void LoadSettings(out float sfxVolume, out float bgmVolume)
    {
        sfxVolume = savedSFXVolume;
        bgmVolume = savedBGMVolume;
    }

    public static void RestoreDefaultSettings(out float sfxVolume, out float bgmVolume)
    {
        sfxVolume = 1.0f;
        bgmVolume = 0.3f;
    }
}