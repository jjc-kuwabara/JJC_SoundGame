using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRecorder : MonoBehaviour
{
    float currentSecond;

//    List<BlockSpawner.NodeSpawnInfo> nodeRecordList;
    AudioManager audioManager;

    bool isEnableTapNodeCreate; // タップしたらノードを作成して良い状態.
    NodeOperateMenu nodeOperateMenu;

    public enum NODE_OPERATE_MODE
    {
        CREATE,
        REMOVE,
        MOVE
    };
    NODE_OPERATE_MODE _nodeOperateMode;


    // Start is called before the first frame update
    void Start()
    {
        currentSecond = 0.0f;
//        nodeRecordList = new List<BlockSpawner.NodeSpawnInfo>();
        audioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
        isEnableTapNodeCreate = false;
        _nodeOperateMode = NODE_OPERATE_MODE.CREATE;
        nodeOperateMenu = GameObject.Find("NodeOperateMenu").GetComponent<NodeOperateMenu>();
        nodeOperateMenu.RefreshOperateMode(_nodeOperateMode);
    }

    // Update is called once per frame
    void Update()
    {
        currentSecond = audioManager.GetCurrentSecond();

        if ( Input.GetMouseButtonDown(0) )
        {
            if (isEnableTapNodeCreate && _nodeOperateMode == NODE_OPERATE_MODE.CREATE)
            {
                Vector3 mouseWorldPos = Vector3.zero; // マウスのワールド座標を格納する.

                // レイキャストによって、カメラからマウス座標に対して飛ばしたレイと、地面との衝突を検知する.
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    mouseWorldPos = hit.point;
                }
                int lineId = NearStaticLineId(mouseWorldPos); // マウスのワールド座標に一番近い、ラインを確認する.
                float elapsedTime = currentSecond - JJCSoundGame.jjcSoundGameSO.waitPlaySecond; // 音楽が流れてから経過した秒数.

                bool isValid = true;
                if (elapsedTime < 0.0f)
                {
                    isValid = false;
                }

                if (isValid)
                {
                    /*                BlockSpawner.NodeSpawnInfo nodeSpawnInfo = new BlockSpawner.NodeSpawnInfo();
                                    nodeSpawnInfo.lineId = lineId;
                                    nodeSpawnInfo.nodeTapTimingSecond = elapsedTime;
                                    odeRecordList.Add(nodeSpawnInfo);*/

                    GameObject instanceObj = Instantiate(JJCSoundGame.jjcSoundGameSO.recordingNodePrefab);
                    RecordingNode instanceRecordingNode = instanceObj.GetComponent<RecordingNode>();
                    instanceRecordingNode.lineId = lineId;
                    instanceRecordingNode.nodeTapTimingSecond = elapsedTime;
                    instanceRecordingNode.transform.SetParent(GameObject.Find("NodeParent").transform);

                    Debug.Log("nearLineId:" + lineId.ToString() + ", elapsedTime:" + elapsedTime.ToString()); // パラメータをデバッグ表示する.
                }
            }
            else if (_nodeOperateMode == NODE_OPERATE_MODE.REMOVE)
            {
                // レイキャストによって、カメラからマウス座標に対して飛ばしたレイと、地面との衝突を検知する.
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    if (hit.transform.gameObject.name == "BackgroundPlane")
                    {

                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                    }

                }
            }
        }

        // マウス座標を可視化するデバッグ.
        {
            Vector3 mouseWorldPos = Vector3.zero; // マウスのワールド座標を格納する.

            // レイキャストによって、カメラからマウス座標に対して飛ばしたレイと、地面との衝突を検知する.
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                mouseWorldPos = hit.point;
            }

            // マウス座標を可視化するデバッグ.
            GameObject mousePosObj = GameObject.Find("DebugMousePos");
            mousePosObj.transform.position = mouseWorldPos;
        }
    }

    // 入力した座標に一番近いラインのIDを調べる.
    int NearStaticLineId(Vector3 position)
    {
        float inputX = position.x;
        int resultLineId = 0;

        float minDiffX = 99999.0f;     // 最も差が小さい値.
        float currentDiffX = 0.0f;     // 現在調査中のラインとの差.
        for (int lineId = JJCSoundGame.jjcSoundGameSO.nodePosXMin; lineId <= JJCSoundGame.jjcSoundGameSO.nodePosXMax; lineId++)
        {
            float checkLinePosX = lineId * JJCSoundGame.jjcSoundGameSO.staticLineMargin;

            currentDiffX = checkLinePosX - position.x;  // 入力した座標と、該当のラインの座標との差を調査.
            currentDiffX = Mathf.Abs(currentDiffX);     // 絶対値に変換.

            if (currentDiffX < minDiffX)
            {
                resultLineId = lineId;
                minDiffX = currentDiffX;
            }
        }
        
        return resultLineId;
    }

    public string GetRecordedNodeSpawnInfo()
    {
        string resultString = "";
 /*       for (int i = 0; i < nodeRecordList.Count; i++)
        {
            resultString = resultString + nodeRecordList[i].lineId.ToString() + "," + nodeRecordList[i].nodeTapTimingSecond.ToString() + "\n";
        }*/
        return resultString;
    }

    public void RefreshNodePosition(float seekRate)
    {
        float currentSecond = seekRate * audioManager.GetMaxTime();
        
        GameObject nodeParent = GameObject.Find("NodeParent");

        int nodeNum = nodeParent.transform.childCount;
        for (int i = 0; i < nodeNum; i++)
        {
            GameObject nodeObj = nodeParent.transform.GetChild(i).gameObject;
            RecordingNode recordingNode = nodeObj.GetComponent<RecordingNode>();

            int lineId = recordingNode.lineId;
            float tapTimingSec = recordingNode.nodeTapTimingSecond;

            float elapsedSecondOffsetZ = -currentSecond * JJCSoundGame.jjcSoundGameSO.nodeSpeed; // 経過時間によるZ座標の差分.
            float tapSecondOffsetZ = tapTimingSec * JJCSoundGame.jjcSoundGameSO.nodeSpeed; // タップ発生時間によるZ座標の差分.

            nodeObj.transform.position = new Vector3(
                lineId * JJCSoundGame.jjcSoundGameSO.staticLineMargin,
                0.0f,
                JJCSoundGame.jjcSoundGameSO.nodeHitLineZ + tapSecondOffsetZ + elapsedSecondOffsetZ
                );
        }

    }

    public void EnableTapNodeCreate(bool isEnable)
    {
        isEnableTapNodeCreate = isEnable;
    }

    public void ChangeNodeOperateMode(NODE_OPERATE_MODE nodeOperateMode)
    {
        _nodeOperateMode = nodeOperateMode;
        nodeOperateMenu.RefreshOperateMode(_nodeOperateMode);
    }
}
