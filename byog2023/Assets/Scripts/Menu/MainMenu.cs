using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private const string VOLUME_KEY = "Volume";

    [SerializeField] private Slider volumeSlider; 
    
    private void Start()
    {
        // Set volume.
        var volume = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);
        UpdateSound(volume);

        volumeSlider.value = volume;
    }

    public void Play()
    {
        // TODO: Write play scene functionality.
    }

    public void UpdateSound(float value)
    {
        AudioListener.volume = value;
        
        PlayerPrefs.SetFloat(VOLUME_KEY, value);
    }
}
