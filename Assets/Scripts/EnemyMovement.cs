using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform traget;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start ()
    {
        enemy = GetComponent<Enemy>();

        traget = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = traget.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, traget.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    enemy.speed = enemy.startSpeed;

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        traget = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
