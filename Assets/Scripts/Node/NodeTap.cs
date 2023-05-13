using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeTap : MonoBehaviour
{
    public enum TapScore
    {
        PERFECT,
        GOOD,
        BAD,
        MISS
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTap()
    {
        Destroy(gameObject);

        float nodePositionZ = transform.position.z;
        float hitLinePositionZ = JJCSoundGame.jjcSoundGameSO.nodeHitLineZ;
        float positionOffsetZ = hitLinePositionZ- nodePositionZ;

        float absPositionOffsetZ = Mathf.Abs(positionOffsetZ);
        if (absPositionOffsetZ < JJCSoundGame.jjcSoundGameSO.offsetPerfect)
        {
            JJCSoundGame.scoreBoard.AddScore(ScoreBoard.SCORE_TYPE.PERFECT);
            JJCSoundGame.seManager.PlaySe(SeManager.SE_ID.SE000);
            Debug.Log("Perfect");
        }else if (absPositionOffsetZ < JJCSoundGame.jjcSoundGameSO.offsetGood)
        {
            JJCSoundGame.scoreBoard.AddScore(ScoreBoard.SCORE_TYPE.GOOD);
            JJCSoundGame.seManager.PlaySe(SeManager.SE_ID.SE000);
            Debug.Log("Good");
        }else if (absPositionOffsetZ < JJCSoundGame.jjcSoundGameSO.offsetBad)
        {
            JJCSoundGame.scoreBoard.AddScore(ScoreBoard.SCORE_TYPE.BAD);
            JJCSoundGame.seManager.PlaySe(SeManager.SE_ID.SE000);
            Debug.Log("Bad");
        }
        else
        {
            JJCSoundGame.scoreBoard.AddScore(ScoreBoard.SCORE_TYPE.MISS);
            JJCSoundGame.seManager.PlaySe(SeManager.SE_ID.SE001);
            Debug.Log("Miss");
        }

    }
}
