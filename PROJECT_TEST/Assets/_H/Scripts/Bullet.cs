using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //10 NOV 20
    //총알클래스 하는 일? 
    //플레이어가 발사버튼을 누르면 
    //총알이 생성된 후 발사하고 싶은 방향(위)으로 움직인다

    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);   
    }

    //나중에는 디스트로이존을 만들어서
    //그곳과 충돌되면 사라지도록 만들 예정임



    //카메라 화면밖으로 나가서 보이지 않게 되면
    //호출되는 이벤트 함수
    //유니티 내부에는 On으로 시작되는 함수는 전부 이벤트 함수들이다


    private void OnBecameInvisible()
    {
        if(gameObject.name.Contains("MainBullet"))
        {
            //총알 오브젝트는 비활성화 시킨다
            gameObject.SetActive(false);
            //오브젝트 풀에 추가만 해준다
            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf.bulletPool.Enqueue(gameObject);
            //Destroy(gameObject);
            //gameObject-> 이 아이도 자주 사용하는 거라 소문자로 만들어져 있다.
        }

        else
        {
            Destroy(gameObject);
        }
    }


}

