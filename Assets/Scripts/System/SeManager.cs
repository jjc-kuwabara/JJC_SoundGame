using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour
{
    public List<AudioClip> seAudioClips;
    AudioSource seAudioSource;

    public enum SE_ID
    {
        SE000,
        SE001,
        NUM
    }

    // Start is called before the first frame update
    void Start()
    {
        seAudioSource = GetComponent<AudioSource>();
        seAudioClips = new List<AudioClip>();
        for (int i = 0; i < (int)SE_ID.NUM; i++)
        {
            seAudioClips.Add(Resources.Load<AudioClip>("Audio/Se" + i.ToString("000")));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySe(SE_ID seId)
    {
        seAudioSource.PlayOneShot(seAudioClips[(int)seId]);
    }
}
