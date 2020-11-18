using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    //플레이어는 사용자가 조작한다
    //따라서 입력을 받아야 한다
    //키보드, 마우스 등등 입력은 Input매니져가 담당한다


    //이동속력
    //public-> 인스펙터 창에 변수가 노출된다
    // 기본은 private ->인스펙터 창에 변수가 노출되지 않는다.
    private int hp = 50;
    public float speed = 5.0f;
    public Rigidbody rigid; 
    public float jumpForce;

    public Vector2 margin; // viewport 좌표는 0,0 ~ 1,1 사이의 값을 사용하므로 vector2 사용



    float camWidth;
    float camHeight;
    float playerHalfWidth;
    float playerHalfHeight;

    private void OnTriggerEnter(Collider other)
    {
        hp -= 1;
        print(hp);
        if(other.tag!="Boss")  Destroy(other.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();


        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Screen.width / Screen.height;

        Vector3 colHalfSize = GetComponent<Collider>().bounds.extents;
        playerHalfWidth = colHalfSize.x;
        playerHalfHeight = colHalfSize.z;


    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis 사용하는 이유?
        //멀티플랫폼 사용때문에 (윈도우, 안드로이드)
        //GetAxis : 1 ~ -1사이의 값
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

        //이동처리
        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime,0);

        //아래의 방법도 가능 (덧셈일때는 크게 상관없지만 뺄셈을 써야 할 경우 아래 방법이 더 좋다.)
        //Vector3 dir = Vector3.right * h + Vector3.forward * v; //3D



        //Vector3 dir = Vector3.right * h + Vector3.up * v; //2D

        //벡터의 정규화
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);
        


        //중요
        //P = P0 + vt;  : 위치 = 현재 위치 + (vector:방향 * time:시간)
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;


        //플레이어를 화면밖으로 나가지 못하게 막기
        //1.화면 밖 공간에 큐브 4개를 만들어서 배치하면 충돌체 때문에 밖으로 벗어나지 못한다.
        //- Rigidbody가 포함되어야 충돌처리가 가능함
        //2.플레이어 트렌스폼 포지션 x,y 값을 고정시킨다.
        //3.메인카메라의 뷰포트를 가져와서 처리한다.

        //1.
        //float xInput = h * speed + Time.deltaTime;
        //float zInput = v * speed + Time.deltaTime;

        //rigid.velocity = new Vector3(xInput, 0, zInput);

        //2.


        //if (Input.GetKey(KeyCode.A))
        //{
        //    if (transform.position.x >= -4.5f)
        //        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    if (transform.position.x <= 4.5f)
        //        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    if (transform.position.z <= 4.5f)
        //        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    if (transform.position.z >= -4.5f)
        //        transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rigid.AddForce(0, jumpForce, 0);
        //}

        ////3.
        //Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        //if (worldpos.x < 0f) worldpos.x = 0f;
        //if (worldpos.y < 0f) worldpos.y = 0f;
        //if (worldpos.x > 1f) worldpos.x = 1f;
        //if (worldpos.y > 1f) worldpos.y = 1f;

        //this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);



        //2.의 다른 방법
        //  MoveControl();



        /////// 10 NOV ////////
        


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);

        transform.Translate(dir * speed * Time.deltaTime);

        
        MoveInScreen();
        Death();
    }

    private void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneMgr.Instance.LoadScene("StartScene"); 
        }
    }

    //void MoveControl()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    Vector3 dir = Vector3.right * h + Vector3.forward * v;
    //    dir = dir.normalized;

    //    Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;
    //    movePosition.Set(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth),
    //                     transform.position.y,
    //                     Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));

    //    transform.position = movePosition;

    //}


    //10 NOV 20 과제 review
    void MoveInScreen()
    {
        //플레이어를 화면밖으로 나가지 못하게 막기
        //1.화면 밖 공간에 큐브 4개를 만들어서 배치하면 충돌체 때문에 밖으로 벗어나지 못한다.
        //- Rigidbody가 포함되어야 충돌처리가 가능함
        //2.플레이어 트렌스폼 포지션 x,y 값을 고정시킨다.

        //아래와 같이 Vector3 번수를 만들어서 트렌스폼의 포지션 벡터값을 대입 후
        //연산해서 다시 트렌스폼에 넣어주는 것을 캐싱이라고 한다.
        // Vector3 position = transform.position;
        //if (position.x > 2.5f) position.x = 2.5f;
        //transform.position = position;

        //Mathf.Clamp 가 성능이 훨씬 뛰어나다
        //position.x = Mathf.Clamp(position.x, -2.3f, 2.3f);
        //position.y = Mathf.Clamp(position.y, -4.5f, 4.5f);
        //transform.position = position;


        //3.메인카메라의 뷰포트를 가져와서 처리한다.
        //스크린좌표 : 모니터해상도 픽셀단위
        //뷰포트좌표 : 카메라의 사각뿔 끝에 있는 사각형 왼쪽하단(0,0) , 우측상단(1,1)
        //UV 좌표  : 화면 텍스트, 2D 이미지를 표시하기 위한 좌표계로 텍스쳐 좌표계라고도 한다.
        //좌측상단(0,0) , 우측하단(1,1)

        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f +margin.x ,1.0f -margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f +margin.y ,1.0f -margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);


       

        /*
         
        메인 카메라의 중요함수
        메인 카메라또한 자주 사용하기 때문에 어디에서든 접근할 수 있도록
        Camera.main으로 사용가능하다

       

        스크린의 화면을 마우스로 클릭했을 때 3D 공간의 클릭지점으로 오브젝트를 움직일때 사용할 함수?
        답 : Camera.main.ScreenToWorldPoint

         */
    }
}
