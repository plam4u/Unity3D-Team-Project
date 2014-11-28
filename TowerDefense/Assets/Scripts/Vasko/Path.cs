using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class Path : MonoBehaviour
{
    public float speed = 10;

    private List<GameObject> path = new List<GameObject>();
    private int count = 0; // count the array path

    void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Path"))
        {
            path.Add(item);
        }

        path = path.OrderBy(x => x.name).ToList(); // Sort them by name

        MoveFinalLast(); // Move Final items at the end of the array
    }

    void Update()
    {
        Transform nextPosition = path[this.count].transform;
        this.transform.LookAt(nextPosition);
        this.transform.Translate(nextPosition.forward * Time.deltaTime * this.speed);

        if (IsMyPosEqualNext(nextPosition))
        {
            if (NextPosIsFinal(nextPosition))
            {
                Destroy(this.gameObject);
                return;
            }

            string pathName = path[this.count].name;
            path.RemoveAll(x => x.name == pathName); // remove all Paths with equal name
            int equalPaths = FindEqualPaths(); // Find all equal paths and choose one of them, then others with this name are removed

            System.Random randomGenerator = new System.Random();

            this.count = randomGenerator.Next(this.count, this.count + equalPaths);

            if (this.path[this.count + 1].name.StartsWith("Final"))
            {
                FindMostShortWayToFinal();
            }
        }
    }

    private void FindMostShortWayToFinal()
    {
        float mostShortPos = float.MaxValue;
        for (int i = count; i < this.path.Count; i++)
        {
            float currPos = Vector3.Distance(this.transform.position, this.path[i].transform.position);
            if (currPos < mostShortPos)
            {
                mostShortPos = currPos;
                count = i;
            }
        }
    }

    private bool NextPosIsFinal(Transform nextPosition)
    {
        return nextPosition.name.StartsWith("Final");
    }

    private int FindEqualPaths()
    {
        int equalPaths = 1;

        for (int i = this.count; i < this.path.Count; i++)
        {
            if (this.path[i].name == this.path[i + 1].name)
            {
                equalPaths++;
            }
            else
            {
                break;
            }
        }

        return equalPaths;
    }

    private bool IsMyPosEqualNext(Transform nextPosition)
    {
        return Math.Round(this.transform.position.x) == Math.Round(nextPosition.position.x) && Math.Round(this.transform.position.z) == Math.Round(nextPosition.position.z);
    }

    private void MoveFinalLast()
    {
        for (int i = 0; i < this.path.Count; i++)
        {
            if (this.path[i].name.ToString().StartsWith("Final"))
            {
                this.path.Add(path[i]);
                this.path.RemoveAt(i);
                i--;
            }
            else
            {
                break;
            }
        }
    }
}
