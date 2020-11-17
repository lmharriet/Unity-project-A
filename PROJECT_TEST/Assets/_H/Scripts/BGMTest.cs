using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            BGMMgr.Instance.PlayBGM("IngameBGM");
        }
        if(Input.GetKeyDown("2"))
        {
            BGMMgr.Instance.PlayBGM("PlayerRoom");
        }
        if(Input.GetKeyDown("3"))
        {
            BGMMgr.Instance.CrossFadeBGM("IngameBGM", 3.0f);
        }
        if (Input.GetKeyDown("4"))
        {
            BGMMgr.Instance.CrossFadeBGM("PlayerRoom", 3.0f);
        }

    }
}
