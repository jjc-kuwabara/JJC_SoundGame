using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    List<GameObject> recordingNodeList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        GameObject nodeParent = GameObject.Find("NodeParent");

        int nodeNum = nodeParent.transform.childCount;
        for (int i = 0; i < nodeNum; i++)
        {
            recordingNodeList.Add(nodeParent.transform.GetChild(i).gameObject);
            Debug.Log(recordingNodeList[i].transform.position.x.ToString() + "," + recordingNodeList[i].transform.position.z.ToString());
        }
    }

}
