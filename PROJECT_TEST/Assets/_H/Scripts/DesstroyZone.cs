using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesstroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // 이곳에서 트리거에 감지된 오브젝트 제거하기(총알,에너미)
        Destroy(other);
    }
}
