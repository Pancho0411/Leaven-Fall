using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;

    private float patrolTimer;

    private float patrolDuration = 5;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("The Fish Awakens");
        Patrol();

        enemy.Move();

        if (enemy.Target != null && enemy.InThrowRange)
        {
            enemy.ChangeState(new RangedState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }

    private void Patrol()
    {

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
