using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesstroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        //print(other.gameObject.name);
        // 이곳에서 트리거에 감지된 오브젝트 제거하기(총알,에너미)
        //if (other.tag != "Airplane" && other.tag != "Player")
        //{

        //    //이곳에서 트리거에 감지된 오브젝트 제거하기 (총알, 에너미)
        //    //Destroy(other.gameObject);
        //    //Bullet(Clone)
        //    //if(other.gameObject.name.Contains("Bullet"))
        //    //{
        //    //    other.gameObject.SetActive(false);
        //    //}

        //    //레이어로 충돌체 찾기
        //    //if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        //    //{
        //    //    other.gameObject.SetActive(false);
        //    //    //플레이어 게임오브젝트의 플레이어파이어 컴포넌트에 bulletPool 속성을 가져와야 한다
        //    //    PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
        //    //    pf.bulletPool.Add(other.gameObject);
        //    //}

        //    //충돌된 오브젝트가 총알이라면 총알풀에 추가한다



        //}
    }
}
