using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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

        recordingNodeList.Clear();
        int nodeNum = nodeParent.transform.childCount;
        for (int i = 0; i < nodeNum; i++)
        {
            recordingNodeList.Add(nodeParent.transform.GetChild(i).gameObject);
            Debug.Log(recordingNodeList[i].transform.position.x.ToString() + "," + recordingNodeList[i].transform.position.z.ToString());
        }

        
        /*       for (int i = 0; i < nodeRecordList.Count; i++)
               {
                   resultString = resultString + nodeRecordList[i].lineId.ToString() + "," + nodeRecordList[i].nodeTapTimingSecond.ToString() + "\n";
               }*/

        string saveString = "";
        for (int i = 0; i < recordingNodeList.Count; i++)
        {
            RecordingNode recordingNode = recordingNodeList[i].GetComponent<RecordingNode>();
            saveString = saveString + recordingNode.lineId.ToString() + "," + recordingNode.nodeTapTimingSecond.ToString() + "\n";
        }

        string filePath = Path.Combine(Application.persistentDataPath, JJCSoundGame.jjcSoundGameSO.nodeSpawnInfoFileName);
        File.WriteAllText(filePath, saveString);
        Debug.Log(filePath);
    }

}
