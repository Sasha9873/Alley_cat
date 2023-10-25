using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_cat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 0, 6);
        InvokeRepeating("Back", 1, 6);
    }

    void Attack()
    {
        var pos = this.transform.position;
        pos.y +=2;
        transform.position = pos;
    }
    void Back()
    {
        var pos = this.transform.position;
        pos.y -=2;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
