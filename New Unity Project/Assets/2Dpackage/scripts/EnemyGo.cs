using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGo : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D rb;
    public bool isVertical;
    public int direction = 1;

    public float walkTime = 3;
    private float timer;

    public Animator enemyAnimator;

    public bool broken = true;

    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        timer = walkTime;

        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }
        timer = timer - Time.deltaTime;

        if(timer <= 0)
        {
            direction = -direction;
            timer = walkTime;
        }
        Vector2 enemyPosition = transform.position;

        if (isVertical)
        {
            enemyPosition.y = enemyPosition.y + speed * Time.deltaTime * direction;
        }
        else
        {
            enemyPosition.x = enemyPosition.x + speed * Time.deltaTime * direction;
        }
        rb.MovePosition(enemyPosition);

        PlayMoveAnimation();
    }
    private void PlayMoveAnimation()
    {
        if (isVertical)
        {
            enemyAnimator.SetFloat("MoveX", 0);
            enemyAnimator.SetFloat("MoveY", direction);
        }
        else
        {
            enemyAnimator.SetFloat("MoveX", direction);
            enemyAnimator.SetFloat("MoveY", 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyMove rubymove = collision.gameObject.GetComponent<RubyMove>();
        if (rubymove != null)
        {
            print("¸I¨ì¼Ä¤H¤F¡A¦©¦å(-1)");
            rubymove.ChangeHealth(-1);
        }
    }
    public void Fix()
    {
        broken = false;
        rb.simulated = false;

        enemyAnimator.SetTrigger("Fixed");

        smokeEffect.Stop();
    }
}
