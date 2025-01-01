using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class enemy_LOS : VersionedMonoBehaviour
    {
        public Transform target;
        IAstarAI ai;
        private GameObject player;
        private bool HasLOS = false;
        double Distanation;
        private float[] LPFP = new float[2];
        private double time;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            LPFP[0] = transform.position.x;
            LPFP[1] = transform.position.y;
        }
        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        void Update()
        {
            

            Distanation = Vector2.Distance(transform.position, player.transform.position);
            if (Distanation < 5)
            {
                RaycastHit2D R = Physics2D.Raycast(transform.position, player.transform.position - transform.position);

                if (R.collider != null)
                {
                    HasLOS = R.collider.CompareTag("Player");


                    if (HasLOS)
                    {
                        if (target != null && ai != null) ai.destination = target.position;
                        LPFP[0] = player.transform.position.x;
                        LPFP[1] = player.transform.position.y;
                        time = 0;
                        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);

                    }
                    else
                    {
                        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                    }
                }
            }
            else
            {

            }
            if ((LPFP[0] >= this.transform.position.x - 0.61f&& LPFP[0] <= this.transform.position.x + 0.61f) && (LPFP[1] >= this.transform.position.y - 0.61f && LPFP[1] <= this.transform.position.y + 0.61f)) time += Time.deltaTime;
            if (time > 2) { LPFP[0] = 4.98f; LPFP[1] = 2.93f; }
            if (target != null && ai != null) ai.destination = new Vector2(LPFP[0], LPFP[1]);
            print(LPFP[0] + " " + LPFP[1]);
            
        }
    }
}

