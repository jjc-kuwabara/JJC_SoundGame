﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJCSoundGame : MonoBehaviour
{


    private void Awake()
    {
        S = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //あ.
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ---------------- Static Section ---------------- //

    static private JJCSoundGame _S;
    static private JJCSoundGame S
    {
        get
        {
            if (_S == null)
            {
                return null;
            }
            return _S;
        }
        set
        {
            if (_S != null)
            {
                Debug.LogError("_Sは既に設定されています.");
            }
            _S = value;
        }
    }

    [Header("インスペクターで指定")]
    [Tooltip("ゲーム定義を指定するためのオブジェクト.")]
    public JJC_SoundGame_SO _jjcSoundGameSO;
    static public JJC_SoundGame_SO jjcSoundGameSO
    {
        get
        {
            if (S != null)
            {
                return S._jjcSoundGameSO;
            }
            return null;
        }
    }

    private ScoreBoard _scoreBoard;
    static public ScoreBoard scoreBoard
    {
        get
        {
            if (S != null)
            {
                if (S._scoreBoard == null)
                {
                    S._scoreBoard = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
                }
                return S._scoreBoard;
            }
            return null;
        }
    }
}
