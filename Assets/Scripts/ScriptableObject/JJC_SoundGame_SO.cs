using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JJC_SoundGame_SO", menuName = "ScriptableObjects/JJCSoundGameScriptableObject", order = 1)]
public class JJC_SoundGame_SO : ScriptableObject
{
    [Header("ノードに関する情報")]
    [SerializeField]
    public GameObject nodePrefab;
    public float nodeSpeed;
    public int nodePosXMin;
    public int nodePosXMax;
    public int nodePosZInitialize;

    [Header("タップに関する情報")]
    public float nodeHitLineZ;
    public float nodeMissLineZ;
    public float offsetPerfect;
    public float offsetGood;
    public float offsetBad;

    [Header("音楽再生に関する情報")]
    public float waitPlaySecond = 3.0f;
}
