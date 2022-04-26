using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a testing script that can be removed later.
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    private float timer = 4;

    // Shoot a bullet.
    private void Start()
    {
        bullet.SetActive(transform.position, new Vector2(0, -1), 2, 1, 3);
    }

    // After x amount of time, shoot a bullet.
    void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 4;

            bullet.ResetBullet(transform.position, 3);
        }
    }
}