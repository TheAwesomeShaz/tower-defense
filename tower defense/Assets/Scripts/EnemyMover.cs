using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(followPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (var wp in waypoints) // wp for waypoint
        {
            path.Add(wp.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator followPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        //disable this particular object in the pool when reaching end of the path 
        //(i.e when there are no more waypoints in the path List)
        gameObject.SetActive(false);
        enemy.StealGold();
    }

}
