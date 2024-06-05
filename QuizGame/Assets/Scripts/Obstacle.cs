using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(-GameManager.instance.Speed, 0);
        if (transform.position.x < -GameManager.instance.ScreenBounds.x)
        {
            Destroy(gameObject);
        }
    }
}
