using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRecordRect : MonoBehaviour
{
    public void OnEnter()
    {
        JJCSoundGame.nodeRecorder.EnableTapNodeCreate(true);
    }

    public void OnExit()
    {
        JJCSoundGame.nodeRecorder.EnableTapNodeCreate(false);
    }
}
