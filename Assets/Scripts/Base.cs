using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int _healthBase = 5;
    


    public void TakeDamage(int damage)
    {
        _healthBase -= damage;

        if (_healthBase <= 0)
        {
            Destroy(gameObject);
        }
    }
}
