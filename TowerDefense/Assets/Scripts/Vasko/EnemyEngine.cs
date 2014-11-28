using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading;

    class EnemyEngine : MonoBehaviour
    {
        public GameObject enemy;
        public GameObject startPos;
        public List<GameObject> path;
        public int enemies = 10;
        public float time = 10;

        void Start()
        {
        }

        void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {

            }
        }

        public bool MeasureTime(float time)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
