using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nasu : MonoBehaviour
{
    public GameObject pickE;

    public AudioClip audioClip;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(pickE, gameObject.transform.position, Quaternion.identity);

        RubyMove RubyRunDown1 = collision.GetComponent<RubyMove>();

        print("碰到的東西是:" + RubyRunDown1);

        RubyRunDown1.ChangeHealth(1);

        RubyRunDown1.PlaySound(audioClip);

        Destroy(gameObject);
    }
}
