using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetimeBullet;    
    [SerializeField] private int _damageBullet;
    

    private void Start()
    {
        Invoke("DestroyBullet", _lifetimeBullet);

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        WallDestruction wall = collision.GetComponent<WallDestruction>();
        if (wall != null)
        {          
            wall.TakeDamage(_damageBullet);

            DestroyBullet();
        }
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damageBullet);
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    
    }
   
    }
