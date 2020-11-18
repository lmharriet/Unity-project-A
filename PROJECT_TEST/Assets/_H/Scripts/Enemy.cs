using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//자동으로 원하는 컴포넌트를 추가한다
//반드시 필요한 컴포넌트를 실수로 삭제할 수 있기 때문에 강제로 붙어있게 만들어준다

public class Enemy : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform firePoint;
    public float count;
    public float delay = 1.0f;

    public bool isFind = false;
    //에너미의 역할?
    //위에서 아래로 떨어진다.
    //에너미가 플레이어를 향해서 총알을 발사한다
    //충돌처리 - Rigidbody 사용 (Rigidbody는 연산처리가 무겁다 그래서 FPS 게임에서는 사용 안할 예정)
    public float speed = 5.0f; //에너미 이동속도

    public GameObject explosion;

    //유니티 어트리뷰트 공부하기

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        //총알 생성
        if (count > delay)
        {
            count = 0;
            Instantiate(enemyBullet, firePoint.position, Quaternion.identity);
        }
        //아래로 이동해라
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //자기자신도 없애고
            //충돌된 오브젝트도 없앤다
            Destroy(gameObject);
            //Destroy(gameObject, 2.0f);
            Destroy(collision.gameObject);


            //이펙트 보여주기
            ShowEffect();

            //점수 추가
            ScoreManager.Instance.AddScore();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    
private void ShowEffect()
    {
        GameObject fx = Instantiate(explosion);
        fx.transform.position = transform.position;
    }
}
