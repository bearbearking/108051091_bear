using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 rubyMove = new Vector2();
            rubyMove = transform.position;
            rubyMove.x = rubyMove.x + 0.01f;
            transform.position = rubyMove;

        }
}
