using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioSeekbar : MonoBehaviour
{
    public float seekRate = 0.0f;
    AudioManager audioManager;
    Slider seekBarSlider;

    void Start()
    {

    }

    public void RefreshSeekbar()
    {
        audioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
        seekBarSlider = transform.Find("Slider").GetComponent<Slider>();

        seekRate = audioManager.GetSeekRate();
        if (seekBarSlider != null)
        {
            seekBarSlider.value = seekRate;
        }
    }

    public float GetSeekbarRate()
    {
        return seekBarSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        seekRate = seekBarSlider.value;
    }
}
