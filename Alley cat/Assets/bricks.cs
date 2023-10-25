using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 0, 2);
        InvokeRepeating("Back", 1, 2);
    }

    void Attack()
    {
        for(int i = 0; i < 15; ++i)
        {
            var pos = this.transform.position;
            pos.y -= 1;
            transform.position = pos;
        }
        
    }
    void Back()
    {
        var pos = this.transform.position;
        pos.y += 15;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
