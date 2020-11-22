using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMgr : MonoBehaviour
{
    private RectTransform rcTr;
    public Vector3 endPt;

    public bool btn = false;
    // Start is called before the first frame update
    void Start()
    {
        rcTr = GetComponent<RectTransform>();
    }

    public void TurnOn()
    {
        btn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //position = world 좌표
        //localPosition = Local 좌표

        if(btn)
        {
            rcTr.transform.localPosition = Vector3.Lerp(rcTr.transform.localPosition, endPt, 0.2f);
        }
    }
}
