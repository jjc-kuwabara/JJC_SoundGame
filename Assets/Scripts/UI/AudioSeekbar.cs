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
    Text secondWriter;

    void Start()
    {
        audioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
        seekBarSlider = transform.Find("Slider").GetComponent<Slider>();
        secondWriter = transform.Find("Text").GetComponent<Text>();

        string writeString = "00:00/00:00";
        secondWriter.text = writeString;
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
        JJCSoundGame.audioManager.SetCurrentSeekRate(seekRate);

        JJCSoundGame.nodeRecorder.RefreshNodePosition(seekRate);

        {
            float fMaxSecond = audioManager.GetMaxTime();
            int nMaxSecond = (int)fMaxSecond;
            int nMaxSecond_minute = nMaxSecond / 60;
            int nMaxSecond_second = nMaxSecond % 60;
            string maxSecondString = nMaxSecond_minute.ToString("00") + ":" + nMaxSecond_second.ToString("00");

            float fCurrentSecond = seekRate * fMaxSecond;
            int nCurrentSecond = (int)fCurrentSecond;
            int nCurrentSecond_minute = nCurrentSecond / 60;
            int nCurrentSecond_second = nCurrentSecond % 60;
            string currintSecond = nCurrentSecond_minute.ToString("00") + ":" + nCurrentSecond_second.ToString("00");

            string writeString = currintSecond + "/" + maxSecondString;
            secondWriter.text = writeString;
        }
    }
}
