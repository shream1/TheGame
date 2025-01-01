using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_HP : MonoBehaviour
{
    public int HP ;
    private void Start()
    {
        HP = 5;
    }
    private void Update()
    {
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HP--;
        }
    }
}
