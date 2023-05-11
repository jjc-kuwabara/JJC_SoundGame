using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    [Header("譜面作製モードかどうか")]
    bool isRecording;
    [SerializeField]
    [Header("シーンを起動してから経過した時間（秒数）")]
    float currentSecond;
    [SerializeField]
    [Header("シーン起動直後の音楽再生待ち状態かどうか")]
    bool isWaitPlay;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
        isWaitPlay = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSecond = currentSecond + Time.deltaTime;

        if (isWaitPlay && currentSecond > JJCSoundGame.jjcSoundGameSO.waitPlaySecond)
        {
            isWaitPlay = false;
            audioSource.Play();
        }

        // 特定の秒数が経ったら、音楽を止める.
        if(currentSecond > (JJCSoundGame.jjcSoundGameSO.waitPlaySecond + JJCSoundGame.jjcSoundGameSO.musicPlayLimit))
        {
            audioSource.Stop();
        }

        if (Input.GetMouseButtonDown(1))
        {
            audioSource.Stop();
        }

        // 
        if (isRecording && !isWaitPlay && !audioSource.isPlaying)
        {
            string filePath = Path.Combine(Application.persistentDataPath, JJCSoundGame.jjcSoundGameSO.nodeSpawnInfoFileName);
            string resultString = JJCSoundGame.nodeRecorder.GetRecordedNodeSpawnInfo();
            File.WriteAllText(filePath, resultString);
            Debug.Log(filePath);
        }
    }
}
