using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    // 총알 공장(프리팹)
    //public GameObject firePoint;        // 총알 발사위치
    public Transform firePoint;        // 총알 발사위치


    //오브젝트 풀링
    //오브젝트 풀링에 사용할 최대 총알갯수
    int poolSize = 20;
    // int fireIndex = 0;

    //1. 배열
    //GameObject[] bulletPool;
    //2. 리스트
    //public List<GameObject> bulletPool;
    //3. 큐
    public Queue<GameObject> bulletPool;

    //사운드 재생
    //오디오 소스 컴포넌트가 반드시 필요하다
    //오디오 리스너는 게임세상에 단 1개만 존재해야 하고
    //기본적으로 카메라에 부착되어 있다.(필요해 의해 플레이어에 부착시켜 놓아도 된다.)
    //가능하면 손대지말고 그대로 두자.

    AudioSource audio; //MP3플레이어라고 생각하자
    public AudioClip[] clips; //오디오 파일이 여러개 일 때
    private void Start()
    {
        audio = GetComponent<AudioSource>();

        //오브젝트 풀링 초기화
        InitObjectPooling();

    }

    private void InitObjectPooling()
    {
        //1. 배열
        //bulletPool = new GameObject[poolSize];
        //for(int i = 0;i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool[i] = bullet;
        //}

        //2. 리스트
        //bulletPool = new List<GameObject>();
        //for(int i = 0;i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool.Add(bullet);
        //}

        //3. 큐
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        //if (lr.enabled) ShowRay();
    }


    public void Fire()
    {
        //마우스 왼쪽버튼 or 왼쪽컨트롤 키
        //if (Input.GetButtonDown("Fire1")) // inputManager안에 이미 setting 되어있음
        //  {//1. 배열 오브젝트풀링으로 총알발사
        //bulletPool[fireIndex].SetActive(true);
        //bulletPool[fireIndex].transform.position = firePoint.position;
        //bulletPool[fireIndex].transform.up = firePoint.up;
        //fireIndex++;
        //if (fireIndex >= poolSize) fireIndex = 0;

        //2. 리스트 오브젝트풀링으로 총알발사
        //bulletPool[fireIndex].SetActive(true);
        //bulletPool[fireIndex].transform.position = firePoint.position;
        //bulletPool[fireIndex].transform.up = firePoint.up;
        //fireIndex++;
        //if (fireIndex >= poolSize) fireIndex = 0;

        //3. 리스트 오브젝트풀링으로 총알발사 (진짜 오브젝트 풀링)
        //if(bulletPool.Count > 0)
        //{
        //    GameObject bullet = bulletPool[0];
        //    bullet.SetActive(true);
        //    bullet.transform.position = firePoint.position;
        //    bullet.transform.up = firePoint.up;
        //    //오브젝트 풀에서 빼준다
        //    bulletPool.Remove(bullet);
        //}
        //else//오브젝트풀이 비어서 오브젝트가 하나도 없으니 풀크기를 늘려준다
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    //오브젝트 풀에 추가한다
        //    bulletPool.Add(bullet);
        //}


        //4. 큐 오브젝트풀링으로 총알발사 (큐가 리스트보다 성능이 좋다)
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.transform.position = firePoint.position;
            bullet.transform.up = firePoint.up;
            bullet.SetActive(true);
        }
        else//오브젝트풀이 비어서 오브젝트가 하나도 없으니 풀크기를 늘려준다
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            //오브젝트 풀에 추가한다
            bulletPool.Enqueue(bullet);

            GameObject _bullet = bulletPool.Dequeue();
            _bullet.SetActive(true);
            _bullet.transform.position = firePoint.position;
            _bullet.transform.up = firePoint.up;
        }


        //발사하자마자 사운드 재생
        //사운드 파일이 여러개 일 때는 원하는 사운드 파일을 선택 후 재생한다.
        audio.clip = clips[0];
        //audio.Play();
        audio.PlayOneShot(audio.clip);

        //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다
        //Instantiate()함수로 프리팹 파일을 게임오브젝트로 만든다

        //총알 게임오브젝트 생성

        // GameObject bullet = Instantiate(bulletFactory);

        //총알 오브젝트의 위치 지정
        // bullet.transform.position = transform.position;
        // bullet.transform.position = firePoint.transform.position;
        // bullet.transform.position = firePoint.position;
        // }

        //or
        //Input.GetMouseButtonDown(0); 마우스 왼쪽버튼
        //Input.GetMouseButtonDown(1); 마우스 오른쪽버튼
        //Input.GetMouseButtonDown(2); 마우스 미들버튼(휠버튼)
        //if (Input.GetMouseButtonDown(0))
        //{

        //}

    }


}