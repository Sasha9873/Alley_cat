using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] SpawnPos;
    private int randomSpot;
    private float waitTime;
    public float StartwaitTime;
    public float speed;

    private void Start()
    {
        waitTime = StartwaitTime;
        randomSpot = Random.Range(0, SpawnPos.Length);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, SpawnPos[randomSpot].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, SpawnPos[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = StartwaitTime;
                randomSpot = Random.Range(0, SpawnPos.Length);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
}
