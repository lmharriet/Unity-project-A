using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //    12NOV20 과제 리뷰
    //에너미매니저
    //공장에서 찍어내듯 prefab을 불러온다
    //스폰타임 -> random처리
    //스폰위치 화면위에 배치

    public GameObject enemyFactory; //에너미공장(프리팹)
    public GameObject[] spawnPoints; //스폰위치 여러개
    float spawnTime = 1.0f; //스폰시간 몇초에 한 번씩 찍어낼건지?
    float curTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }


    private void SpawnEnemy()
    {
        //몇초에 한 번씩 이벤트 발동
        //누적시간으로 계산을 한다
        //게임에서 정말 자주 사용됨

        curTime += Time.deltaTime;
        if (curTime > spawnTime)
        {
            //누적된 현재시간을0초로 초기화(반드시해줘야함)
            curTime = 0.0f;

            //스폰시간을 랜덤으로 하자
            spawnTime = Random.Range(0.5f, 2.0f);

            //에너미생성
            GameObject enemy = Instantiate(enemyFactory);
            int index = Random.Range(0, spawnPoints.Length);
            //enemy.transform.position = spawnPoints[index].transform.position;
            enemy.transform.position = transform.GetChild(index).position;
        }
    }

}
