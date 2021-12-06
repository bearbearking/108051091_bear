using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyMove RubyRunDown1 = collision.GetComponent<RubyMove>();
        print("碰到的東西是:" + RubyRunDown1);
        RubyRunDown1.ChangeHealth(-1);
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
