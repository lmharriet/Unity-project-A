using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bossBullet;
    public GameObject basicBullet;
    public GameObject Explosion;
    private static int hp = 20;

    public float spawnTime = 5.0f;
    private float curTime;   

    public float spawnTime0 = 3.0f;
    private float curTime0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="PlayerBullet")
        {
            hp -= 1;
            print(hp);
            showEffect();

            if (hp <= 0) Destroy(gameObject);

            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        curTime0 += Time.deltaTime;
        //if (transform.position.y > 2.0f)
        //{
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);
        //}
        if (curTime > spawnTime)
        {
            curTime = 0;
            for (int i = 0; i < 36; i+=3)
            {
                Instantiate(bossBullet, transform.position, Quaternion.Euler(0, 0, i * 10));
            }
        }

        //총알 생성
        if (curTime0 > spawnTime0)
        {
            curTime0 = 0;
            Instantiate(basicBullet, transform.position, Quaternion.identity);
        }
    }

    private void showEffect()
    {
       GameObject fx = Instantiate(Explosion);
        fx.transform.position = transform.position;
    }
}
