using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    // 총알 공장(프리팹)
    //public GameObject firePoint;        // 총알 발사위치
    public Transform firePoint;        // 총알 발사위치


    //레이져를 발사하기 위해서는 라인렌더러가 필요하다
    //레이져와 충돌은 Raycast를 사용해서 판별한다
    //라인렌더러는 라인만 그려주는 컴포넌트
    //선은 최소 2개의 점이 필요하다(시작점, 끝점)
    LineRenderer lr;
    //일정시간동안 레이져 보여주기
    public float rayShowTime = 0.3f;
    float timer = 0.0f;

    //오브젝트 풀링
    //오브젝트 풀링에 사용할 최대 총알갯수
    int poolSize = 5;
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

        //라인렌더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();

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
        if (lr.enabled) ShowRay();
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
            bullet.SetActive(true);
            bullet.transform.position = firePoint.position;
            bullet.transform.up = firePoint.up;
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

    //파이어 버튼 클릭시
    public void OnFireButtonClick()
    {
        //라인렌더러 컴포넌트 활성화
        lr.enabled = true;
        //라인 시작점,끝점 세팅
        lr.SetPosition(0, firePoint.position);
        //  lr.SetPosition(1,firePoint.position +Vector3.up *10);

        //Ray로 충돌처리
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hitInfo; // Ray와 충돌된 오브젝트의 정보를 받는다.

        if (Physics.Raycast(ray, out hitInfo))
        {
            //레이져의 끝점 지정
            lr.SetPosition(1, hitInfo.point);
            //충돌된 오브젝트 모두 지우기
            //Destroy(hitInfo.collider.gameObject);
            //디스트로이존의 탑과는 충돌처리가 되지 않도록 해야 한다

            //if(hitInfo.collider.name!="Top")
            //{
            //    Destroy(hitInfo.collider.gameObject);
            //}

            //충돌된 에너미 오브젝트 삭제
            //프리팹으로 만든 오브젝트는 생성될때 클론으로 생성된다
            //Contains("Enemy")=>Enemy(clone)

            if (hitInfo.collider.name.Contains("Enemy"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
    private void ShowRay()
    {
        timer += Time.deltaTime;
        if (timer > rayShowTime)
        {
            lr.enabled = false;
        }
    }

}
