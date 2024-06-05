using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float clock, cooldown = 2;
    [SerializeField]
    GameObject obstacle;

    // Update is called once per frame
    void Update()
    {
        if(clock <= 0)
        {
            Instantiate(obstacle, new Vector2(GameManager.instance.ScreenBounds.x, -4), Quaternion.identity);

            if(GameManager.instance.Speed < 10) 
            {
                GameManager.instance.Speed += 0.1f;
            }
            if(cooldown > 1)
            {
                cooldown -= 0.1f;
            }

            clock = cooldown;
        }
        else
        {
            clock -= Time.deltaTime;
        }
    }
}
