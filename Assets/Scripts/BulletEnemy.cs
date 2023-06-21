using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
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
       Character_Controller character = collision.GetComponent<Character_Controller>();
        if (character != null)
        {
            character.TakeDamage(_damageBullet);
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);

    }
}
