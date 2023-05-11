using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    float currentSecond;
    [SerializeField]
    bool isWaitPlay;

    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
        isWaitPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentSecond = currentSecond + Time.deltaTime;

        if (isWaitPlay && currentSecond > JJCSoundGame.jjcSoundGameSO.waitPlaySecond)
        {
            isWaitPlay = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
