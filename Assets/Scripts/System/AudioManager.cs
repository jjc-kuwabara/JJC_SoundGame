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
    [Header("ポーズ中かどうか")]
    bool isPause;
    [Header("seekBarの位置（割合）")]
    float seekRate;


    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
        isWaitPlay = true;
        audioSource = GetComponent<AudioSource>();
        isPause = false;
        seekRate = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            currentSecond = currentSecond + Time.deltaTime;
        }

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

        if(audioSource.isPlaying && !isPause)
        {
            float currentTime = audioSource.time;
            float maxTime = audioSource.clip.length;
            seekRate = currentTime / maxTime;
        }

        /*
        if (isRecording && !isWaitPlay && !audioSource.isPlaying)
        {
            string filePath = Path.Combine(Application.persistentDataPath, JJCSoundGame.jjcSoundGameSO.nodeSpawnInfoFileName);
            string resultString = JJCSoundGame.nodeRecorder.GetRecordedNodeSpawnInfo();
            File.WriteAllText(filePath, resultString);
            Debug.Log(filePath);
        }
        */
    }

    public void Pause()
    {
        if (audioSource.isPlaying && !isPause)
        {
            audioSource.Pause();
        }
        isPause = true;
    }

    public void UnPause(float inputSeekRate)
    {
        if (isPause)
        {
            seekRate = inputSeekRate;
            float maxTime = audioSource.clip.length;
            float currentTime = seekRate * maxTime;
            audioSource.time = currentTime;
            audioSource.UnPause();
            isPause = false;

            currentSecond = JJCSoundGame.jjcSoundGameSO.waitPlaySecond + currentTime;
        }
    }

    public float GetSeekRate()
    {
        return seekRate;
    }
}
