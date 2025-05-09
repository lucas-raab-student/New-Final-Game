using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;

    private List<Transform> path;
    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        RandomPath();

     
        transform.position = path[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void RandomPath()
    {
        GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");
        int randomIndex = Random.Range(0, paths.Length);
        Transform PathTrasform = paths[randomIndex].transform;
        path = new List<Transform>();
        foreach (Transform child in PathTrasform)
        {
            path.Add(child.transform);
        }
    }
    void Move()
    {
        if (waypointIndex < path.Count)
        {
            Vector3 targetPos = path[waypointIndex].position;
            float delta = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                waypointIndex++;
            }
        }

    }
}

