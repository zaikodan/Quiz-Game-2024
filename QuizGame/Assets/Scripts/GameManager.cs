using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float speed = 4;
    private int score;

    Vector2 screenBounds;

    public Vector2 ScreenBounds { get => screenBounds; }
    public float Speed { get => speed; set => speed = value; }
    public int Score { get => score; set => score = value; }

    private void Awake()
    {
        instance = this;

        // ?, ? = A() + B(C())
        // ?, ? = A() + B(10, 5, -10)
        // ?, ? = 1, 0, 0 + 10, 5, -10
        // 11, 5

        // C = 10, 5, -10
        // A = 1, 0, 0
        // B = 10, 5, -10
        screenBounds = new Vector3(1, 0, 0) + Camera.main.ScreenToWorldPoint(new Vector3
            (Screen.width, Screen.height, Camera.main.transform.position.z));
    }
}
