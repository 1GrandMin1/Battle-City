using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthEnemy;
    [SerializeField] private Transform _base;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        _agent.SetDestination(_base.position);

    }
    public void TakeDamage(int damage)
    {
        _healthEnemy -= damage;

        if (_healthEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
