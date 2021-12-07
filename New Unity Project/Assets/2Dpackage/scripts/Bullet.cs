using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletDis;

    public ParticleSystem hitEffect;
        
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletDis = transform.position.magnitude;
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        print("當子彈碰撞到:" + collision.gameObject);
        //[碰到敵人並改變狀態 1/1]
        EnemyGo enemyGo = collision.gameObject.GetComponent<EnemyGo>();
        if (enemyGo != null)
        {
            enemyGo.Fix();

            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
}
