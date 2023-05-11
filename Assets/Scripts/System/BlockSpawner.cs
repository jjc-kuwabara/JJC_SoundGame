using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    float currentSecond;

    public struct NodeSpawnInfo
    {
        public int lineId;                     // どのラインに生成するノードか.
        public float nodeTapTimingSecond;      // ノードのタップが発生する時間.
    }

    List<BlockSpawner.NodeSpawnInfo> nodeSpawnList = new List<NodeSpawnInfo>();
    List<bool> spawned = new List<bool>();

    [SerializeField]
    bool isSpawnRandomNode;

    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
        LoadSpawnList();
    }

    // Update is called once per frame
    void Update()
    {
        currentSecond = currentSecond + Time.deltaTime;

        if (isSpawnRandomNode)
        {
            UpdateSpawnRandomNode();
        }
        else
        {
            UpdateSpawn();
        }

    }

    void UpdateSpawnRandomNode()
    {
        int frameCount = Time.frameCount;
        if (frameCount % 100 == 0)
        {
            GameObject nodeInstance = Instantiate(JJCSoundGame.jjcSoundGameSO.nodePrefab);

            float nodePosX = JJCSoundGame.jjcSoundGameSO.staticLineMargin * UnityEngine.Random.Range(JJCSoundGame.jjcSoundGameSO.nodePosXMin, JJCSoundGame.jjcSoundGameSO.nodePosXMax + 1);
            float nodePosZ = JJCSoundGame.jjcSoundGameSO.nodePosZInitialize;

            nodeInstance.transform.position = new Vector3(nodePosX, 0, nodePosZ);
        }
    }

    void UpdateSpawn()
    {
        // タップ場所 -8.5
        // 生成場所 10
        // ノードのスピード,1秒で進む距離 10
        // 何秒前に生成する必要があるか.
        float nodeSpawnOffsetSecond = (JJCSoundGame.jjcSoundGameSO.nodePosZInitialize - JJCSoundGame.jjcSoundGameSO.nodeHitLineZ) / JJCSoundGame.jjcSoundGameSO.nodeSpeed;

        for (int i = 0; i < nodeSpawnList.Count; i++)
        {
            if (spawned[i])
            {
                continue;
            }

            float nodeSpawnTimingSecond = nodeSpawnList[i].nodeTapTimingSecond - nodeSpawnOffsetSecond + JJCSoundGame.jjcSoundGameSO.waitPlaySecond;

            if (nodeSpawnTimingSecond <= currentSecond)
            {
                GameObject nodeInstance = Instantiate(JJCSoundGame.jjcSoundGameSO.nodePrefab);

                float nodePosX = JJCSoundGame.jjcSoundGameSO.staticLineMargin * nodeSpawnList[i].lineId;
                float nodePosZ = JJCSoundGame.jjcSoundGameSO.nodePosZInitialize;

                nodeInstance.transform.position = new Vector3(nodePosX, 0, nodePosZ);
                spawned[i] = true;

            }
        }
    }

    void LoadSpawnList()
    {
        string filePath = Path.Combine(Application.persistentDataPath, JJCSoundGame.jjcSoundGameSO.nodeSpawnInfoFileName);

        if (File.Exists(filePath))
        {
            // ファイルがあるなら、それを読み取る.
            string spawnListAllString = File.ReadAllText(filePath);
            string[] spawnListLineString = spawnListAllString.Split('\n');

            for (int lineIndex = 0; lineIndex < spawnListLineString.Length; lineIndex++)
            {
                string[] spawnListElementString = spawnListLineString[lineIndex].Split(',');
                // ファイル形式が想定と違う部分（空行とか）は、無視して終わる.
                if(spawnListElementString.Length != 2)
                {
                    break;
                }
                NodeSpawnInfo newNodeSpawnInfo = new NodeSpawnInfo();
                newNodeSpawnInfo.lineId = int.Parse(spawnListElementString[0]);
                newNodeSpawnInfo.nodeTapTimingSecond = float.Parse(spawnListElementString[1]);
                nodeSpawnList.Add(newNodeSpawnInfo);
                spawned.Add(false);
            }

            isSpawnRandomNode = false;
        }
        else
        {
            // ファイルが無いなら、適当生成モードにする.
            isSpawnRandomNode = true;
        }


    }
}
