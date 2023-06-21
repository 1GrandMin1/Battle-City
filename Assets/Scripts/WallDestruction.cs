using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestruction : MonoBehaviour
{
    [SerializeField] private int _healthWall = 5;
    public void TakeDamage(int damage)
    {
        _healthWall -= damage;

        if (_healthWall <= 0)
        {
            Destroy(gameObject);
        }
    }
}

