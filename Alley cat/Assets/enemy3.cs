using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] SpawnPos;
    private int spotNumber;
    private float waitTime;
    public float StartwaitTime;
    public float speed;

    Quaternion base_look;
    Quaternion opposite_look;

    private void Start()
    {
        waitTime = StartwaitTime;
        spotNumber = 0;

        base_look = this.transform.rotation;
        opposite_look = base_look;
        opposite_look.SetEulerAngles(opposite_look.eulerAngles.x, opposite_look.eulerAngles.y + 2.5f, opposite_look.eulerAngles.z);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, SpawnPos[spotNumber].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, SpawnPos[spotNumber].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = StartwaitTime;
                ++spotNumber;
                spotNumber %= SpawnPos.Length;

                if (spotNumber == 4)
                {
                    transform.rotation = opposite_look;
                }
                else if(spotNumber == 0)
                {
                    transform.rotation = base_look;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
