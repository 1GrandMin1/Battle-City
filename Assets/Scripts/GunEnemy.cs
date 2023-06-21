using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunEnemy : MonoBehaviour
{
    public float _bulletSpeed = 10f;
    public GameObject _bulletPrefab;
    private float _timeBtvShots;
    [SerializeField] private float _startTimeBtvShots;
    private Vector2 _movementDirection;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        Vector2 moveDirection = _navMeshAgent.velocity.normalized;
        FireBullet(moveDirection);
        FireBullet(_movementDirection);

    }


    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = _movementDirection;
    }

    private void FireBullet(Vector2 direction)
    {

        if (_timeBtvShots <= 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * _bulletSpeed;
            _timeBtvShots = _startTimeBtvShots;
        }
        else
        {
            _timeBtvShots -= Time.deltaTime;
        }
    }

}