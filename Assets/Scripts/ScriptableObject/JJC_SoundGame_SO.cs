using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JJC_SoundGame_SO", menuName = "ScriptableObjects/JJCSoundGameScriptableObject", order = 1)]
public class JJC_SoundGame_SO : ScriptableObject
{
    [Header("ノードに関する情報")]
    [SerializeField]
    public GameObject nodePrefab;
    public float nodeSpeed = 10.0f;
    public int nodePosXMin = -3;
    public int nodePosXMax = 3;
    public int nodePosZInitialize = 10;

    [Header("タップに関する情報")]
    public float nodeHitLineZ = -8.5f;
    public float nodeMissLineZ = -11.0f;
    public float offsetPerfect = 1;
    public float offsetGood = 2;
    public float offsetBad = 3;
    public float staticLineMargin = 1.5f;

    [Header("音楽再生に関する情報")]
    public float waitPlaySecond = 3.0f;
    public float musicPlayLimit = 60.0f;
    public string nodeSpawnInfoFileName = "NodeSpawnInfo000.csv";
}
