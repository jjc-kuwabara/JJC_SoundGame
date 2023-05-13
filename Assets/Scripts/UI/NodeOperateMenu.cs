using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOperateMenu : MonoBehaviour
{
    GameObject creteOn;
    GameObject creteOff;
    GameObject removeOn;
    GameObject removeOff;
    GameObject moveOn;
    GameObject moveOff;





    // Start is called before the first frame update
    void Awake()
    {
        creteOn = transform.Find("Background/NodeCreateOperateButton/OnButton").gameObject;
        creteOff = transform.Find("Background/NodeCreateOperateButton/OffButton").gameObject;
        removeOn = transform.Find("Background/NodeRemoveOperateButton/OnButton").gameObject;
        removeOff = transform.Find("Background/NodeRemoveOperateButton/OffButton").gameObject;
        moveOn = transform.Find("Background/NodeMoveOperateButton/OnButton").gameObject;
        moveOff = transform.Find("Background/NodeMoveOperateButton/OffButton").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClearAllButton()
    {
        creteOn.SetActive(false);
        creteOff.SetActive(false);
        removeOn.SetActive(false);
        removeOff.SetActive(false);
        moveOn.SetActive(false);
        moveOff.SetActive(false);
    }

    public void RefreshOperateMode(NodeRecorder.NODE_OPERATE_MODE nodeOperateMode)
    {
        ClearAllButton();
        switch (nodeOperateMode)
        {
            case NodeRecorder.NODE_OPERATE_MODE.CREATE:
                creteOn.SetActive(true);
                removeOff.SetActive(true);
                moveOff.SetActive(true);
                break;
            case NodeRecorder.NODE_OPERATE_MODE.REMOVE:
                creteOff.SetActive(true);
                removeOn.SetActive(true);
                moveOff.SetActive(true);
                break;
            case NodeRecorder.NODE_OPERATE_MODE.MOVE:
                creteOff.SetActive(true);
                removeOff.SetActive(true);
                moveOn.SetActive(true);
                break;
        }
    }

    public void OnClickCreate()
    {
        JJCSoundGame.nodeRecorder.ChangeNodeOperateMode(NodeRecorder.NODE_OPERATE_MODE.CREATE);
    }

    public void OnClickRemove()
    {
        JJCSoundGame.nodeRecorder.ChangeNodeOperateMode(NodeRecorder.NODE_OPERATE_MODE.REMOVE);
    }

    public void OnClickMove()
    {
        JJCSoundGame.nodeRecorder.ChangeNodeOperateMode(NodeRecorder.NODE_OPERATE_MODE.MOVE);
    }
}
