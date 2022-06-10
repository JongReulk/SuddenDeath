using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChanges : MonoBehaviour
{
    [Header ("BackgroundMusic")]
    private AudioSource audioSrc;
    public Text MusicVolumeText;
    public Slider MusicVolumeSlider;
    private float musicVolume;



    [Header("SoundEffect")]
    public AudioSource SoundEffectSrc1;
    public AudioSource SoundEffectSrc2;
    public Text SoundEffectVolumeText;
    public Slider SoundEffectVolumeSlider;
    private float soundEffectVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        SoundEffectVolumeSlider.value = PlayerPrefs.GetFloat("soundEffect", 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        soundEffectVolume = PlayerPrefs.GetFloat("soundEffect", 0.5f);
        audioSrc.volume = musicVolume;
        SoundEffectSrc1.volume = soundEffectVolume;
        SoundEffectSrc2.volume = soundEffectVolume;
        SetMusicVolumeText();
        SetSoundEffectVolumeText();
    }

    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("musicVolume", vol);
        //musicVolume = vol;
    }

    public void SoundEffectVolume(float vol)
    {
        PlayerPrefs.SetFloat("soundEffect", vol);
    }



    void SetMusicVolumeText()
    {
        MusicVolumeText.text = "Volume: " + (int)(musicVolume * 100) + "%";
    }

    void SetSoundEffectVolumeText()
    {
        SoundEffectVolumeText.text = "Volume: " + (int)(soundEffectVolume * 100) + "%";
    }
}
