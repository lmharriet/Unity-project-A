using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{

    private GameObject target;
    Vector3 dir;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        dir = target.transform.position - transform.position;
        //dir = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        //dir = target.transform.position - transform.position;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
       // Destroy(collision.gameObject);

    }
}
