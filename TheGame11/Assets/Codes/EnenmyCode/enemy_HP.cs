using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_HP : MonoBehaviour
{
    public int HP ;
    private AIPath AIP;
    private void Start()
    {
        AIP = GetComponent<AIPath>();
        HP = 5;
    }
    private void Update()
    {
        if (HP < 1)
        {
            Destroy(gameObject);
        }
        AIP.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            HP--;
        }
    }
    
}
