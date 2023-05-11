using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRecorder : MonoBehaviour
{
    float currentSecond;

    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentSecond = currentSecond + Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log( (currentSecond - JJCSoundGame.jjcSoundGameSO.waitPlaySecond).ToString());
        }
    }
}
