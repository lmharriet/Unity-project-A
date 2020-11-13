﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Material mat;          //Background 메테리얼
    public float scrollSpeed = 0.1f;       //스크롤 속도


    // Start is called before the first frame update
    void Start()
    {
        //메테리얼은 렌더러 컴포넌트 안에 속성으로 붙어 있다
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundScroll();
    }

    private void BackgroundScroll()
    {
        //메테리얼의 메인 텍스쳐 오프셋은 Vector2로 만들어져있다
        Vector2 offset = mat.mainTextureOffset;
        //offset.y 값만 보정해주면 된다
        offset.Set(0, offset.y + (scrollSpeed * Time.deltaTime));
        //다시 메터리얼 오프셋에 담는다.
        mat.mainTextureOffset = offset;
    }
}
