using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int frameCount = Time.frameCount;

        if (frameCount % 100 == 0)
        {
            GameObject nodeInstance = Instantiate(JJCSoundGame.jjcSoundGameSO.nodePrefab);

            float nodePosX = 1.5f * Random.Range(JJCSoundGame.jjcSoundGameSO.nodePosXMin, JJCSoundGame.jjcSoundGameSO.nodePosXMax + 1);
            float nodePosZ = JJCSoundGame.jjcSoundGameSO.nodePosZInitialize;

            nodeInstance.transform.position = new Vector3(nodePosX, 0, nodePosZ);
        }
    }
}
