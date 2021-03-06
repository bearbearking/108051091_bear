using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RubyMove : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;


    public Animator rubyAnimator;
    public Rigidbody2D rb;

    public float Speed;

    [Header("最高血量")]
    public int maxHealth = 5;

    [Header("當前血量"), Range(0, 5)]
    public int currentHealth;

    public GameObject projectilePrefeb;

    //【發射子彈 1】
    public GameObject projectilePrefab;

    private AudioSource audioSource;

    public AudioClip hitSound;

    public AudioClip fireSound;
    // Start is called before the first frame update

    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


        currentHealth = maxHealth;
        print("Ruby當前血量為:" + currentHealth);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        rubyMove = new Vector2(horizontal, vertical);


        //print(Input.GetAxis("Horizontal"));
        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }
        //print(Input.GetAxis("Horizontal"));
        rubyAnimator.SetFloat("Look X", lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);


        rubyPosition = rubyPosition + Speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);

        if (currentHealth == 0)
        {
            Application.LoadLevel("108051091");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
            print("fire!發射了!");
            PlaySound(fireSound);
        }
    }

    public void ChangeHealth(int amout)
    {
        if (amout < 0)
        {
            PlaySound(hitSound);
        }
        if (amout < 0)
        {
            PlaySound(fireSound);
        }
        currentHealth = currentHealth + amout;
        print("Ruby 當前血量為:" + currentHealth);
    }
    private void Launch()
    {
        GameObject projectileOnject = Instantiate(projectilePrefeb,
            rb.position, Quaternion.identity);

        Bullet bull = projectileOnject.GetComponent<Bullet>();
        
        //bullet.Launch(lookDirection, 300);

        rubyAnimator.SetTrigger("Launch");
    }
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);

    }
}
