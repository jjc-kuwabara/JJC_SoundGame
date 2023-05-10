using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clickedGameObject = null; // マウスでクリックしたゲームオブジェクト.

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;

                NodeTap nodeTapComponent = clickedGameObject.GetComponent<NodeTap>();
                if (nodeTapComponent != null)
                {
                    nodeTapComponent.OnTap();
                }
            }
        }
    }
}
