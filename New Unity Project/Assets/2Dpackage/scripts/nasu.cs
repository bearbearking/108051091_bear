using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nasu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyMove RubyRunDown1 = collision.GetComponent<RubyMove>();
        print("�I�쪺�F��O:" + RubyRunDown1);
        RubyRunDown1.ChangeHealth(1);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
