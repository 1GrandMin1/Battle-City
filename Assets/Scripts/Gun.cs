using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float _bulletSpeed = 10f;
    public GameObject _bulletPrefab;
    private float _timeBtvShots;
    [SerializeField] private float _startTimeBtvShots;
    private Vector2 _movementDirection;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _movementDirection = new Vector2(moveHorizontal, moveVertical).normalized;      
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet(_movementDirection);
        }
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










