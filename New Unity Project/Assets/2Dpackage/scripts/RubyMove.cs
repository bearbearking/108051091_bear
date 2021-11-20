using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyPosition = transform.position;

        rubyPosition.x = rubyPosition.x + moveSpeed * Input.GetAxis("Horizontal")  ;
        //print(Input.GetAxis("Horizontal"));
        transform.position = rubyPosition;
        rubyPosition.y = rubyPosition.y + moveSpeed * Input.GetAxis("Vertical");
        //print(Input.GetAxis("Horizontal"));
        transform.position = rubyPosition;
        rb.MovePosition(rubyPosition);
    }
}
