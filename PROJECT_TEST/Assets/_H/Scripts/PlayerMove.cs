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
    public float speed = 5.0f;
    public Rigidbody rigid; //1번 숙제용
    public float jumpForce;



    float camWidth;
    float camHeight;
    float playerHalfWidth;
    float playerHalfHeight;


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(0, jumpForce, 0);
        }

        ////3.
        //Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        //if (worldpos.x < 0f) worldpos.x = 0f;
        //if (worldpos.y < 0f) worldpos.y = 0f;
        //if (worldpos.x > 1f) worldpos.x = 1f;
        //if (worldpos.y > 1f) worldpos.y = 1f;

        //this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);



        //3.의 다른 방법
        MoveControl();


    }
    void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = dir.normalized;

        Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;
        movePosition.Set(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth),
                         transform.position.y,
                         Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));

        transform.position = movePosition;

    }
}
