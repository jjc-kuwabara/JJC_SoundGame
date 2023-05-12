using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSeekbarHiddenButton : MonoBehaviour
{
    GameObject onButton;
    GameObject offButton;
    GameObject seekBar;
    bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        onButton = transform.Find("OnButton").gameObject;
        offButton = transform.Find("OffButton").gameObject;
        seekBar = GameObject.Find("AudioSeekbar");
        isOn = false;
        RefreshButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        isOn = !isOn;
        RefreshButton();
    }

    void RefreshButton()
    {
        onButton.SetActive(isOn);
        offButton.SetActive(!isOn);
        seekBar.SetActive(isOn);
    }
}
