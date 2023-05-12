using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSeekbarHiddenButton : MonoBehaviour
{
    GameObject onButton;
    GameObject offButton;
    GameObject seekBarObj;
    AudioSeekbar seekBar;
    bool isOn;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        onButton = transform.Find("OnButton").gameObject;
        offButton = transform.Find("OffButton").gameObject;
        seekBarObj = GameObject.Find("AudioSeekbar");
        seekBar = seekBarObj.GetComponent<AudioSeekbar>();
        isOn = false;
        RefreshButton();
        audioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        isOn = !isOn;
        RefreshButton();


        if (isOn)
        {
            audioManager.Pause();
        }
        else
        {
            audioManager.UnPause(seekBar.GetSeekbarRate());
        }
    }

    void RefreshButton()
    {
        onButton.SetActive(isOn);
        offButton.SetActive(!isOn);
        seekBarObj.SetActive(isOn);
        if (isOn)
        {
            seekBar.RefreshSeekbar();
        }
    }
}
