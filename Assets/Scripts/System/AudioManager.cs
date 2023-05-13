using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    [Header("ポーズ中かどうか")]
    bool isPause;
    [SerializeField]
    [Header("seekBarの位置（割合）")]
    float seekRate;
    [SerializeField]
    [Header("譜面作製モードかどうか")]
    bool isRecording;
    [SerializeField]
    [Header("シーンを起動してから経過した時間（秒数）")]
    float currentSecond;
    [SerializeField]
    [Header("シーン起動直後の音楽再生待ち状態かどうか")]
    bool isWaitPlay;
    [SerializeField]
    [Header("時間経過後に音楽を停止した状態かどうか")]
    bool isAfterStop;


    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
        isWaitPlay = true;
        isAfterStop = false;
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
        else
        {

        }

        if (isWaitPlay && currentSecond > JJCSoundGame.jjcSoundGameSO.waitPlaySecond)
        {
            isWaitPlay = false;
            isAfterStop = false;
            audioSource.Play();
        }

        // 特定の秒数が経ったら、音楽を止める.
        if(currentSecond > (JJCSoundGame.jjcSoundGameSO.waitPlaySecond + JJCSoundGame.jjcSoundGameSO.musicPlayLimit))
        {
            isAfterStop = true;
            audioSource.Stop();
        }

        if (Input.GetMouseButtonDown(1))
        {
            isAfterStop = true;
            audioSource.Stop();
        }

        if (isRecording)
        {
            if ( audioSource.isPlaying && !isPause )
            {
                float currentTime = audioSource.time;
                float maxTime = audioSource.clip.length;
                seekRate = currentTime / maxTime;
                JJCSoundGame.nodeRecorder.RefreshNodePosition(seekRate);
            }

            if ( isWaitPlay && !isPause )
            {
                JJCSoundGame.nodeRecorder.RefreshNodePosition(0.0f);
            }
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
        seekRate = inputSeekRate;
        float maxTime = audioSource.clip.length;
        float currentTime = seekRate * maxTime;

        if (!isAfterStop && !isWaitPlay)
        {
            audioSource.time = currentTime;
            audioSource.UnPause();
            isPause = false;
            isWaitPlay = false;
            isAfterStop = false;
        }
        else
        {
            audioSource.time = currentTime;
            audioSource.Play();
            isPause = false;
            isWaitPlay = false;
            isAfterStop = false;

        }
        currentSecond = JJCSoundGame.jjcSoundGameSO.waitPlaySecond + currentTime;
    }

    public float GetSeekRate()
    {
        return seekRate;
    }

    public float GetMaxTime()
    {
        return audioSource.clip.length;
    }

    public float GetCurrentSecond()
    {
        return currentSecond;
    }
    public void SetCurrentSeekRate(float inputSeekRate)
    {
        seekRate = inputSeekRate;
        currentSecond = seekRate * GetMaxTime() + JJCSoundGame.jjcSoundGameSO.waitPlaySecond;
    }
}
