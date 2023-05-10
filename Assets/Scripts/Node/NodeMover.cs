using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        speed = JJCSoundGame.jjcSoundGameSO.nodeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < JJCSoundGame.jjcSoundGameSO.nodeMissLineZ)
        {
            Destroy(gameObject);
            JJCSoundGame.scoreBoard.AddScore(ScoreBoard.SCORE_TYPE.MISS);
        }
    }

    float speed;
}
