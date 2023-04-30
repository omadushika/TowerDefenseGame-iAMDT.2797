using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 10f;

    private Transform traget;
    private int wavepointIndex = 0;

    private void Start ()
    {
        traget = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = traget.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, traget.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        traget = Waypoints.points[wavepointIndex];
    }
}
