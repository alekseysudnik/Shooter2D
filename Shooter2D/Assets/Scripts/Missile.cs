using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private MissileSO missileSO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            AudioSource.PlayClipAtPoint(missileSO.wallShootSound, Vector3.zero, 0.75f);
            SelfDestroy();
        }
        else if(collision.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(missileSO.woundSound, Vector3.zero, 1f);
            Health healthBar = collision.GetComponentInChildren<Health>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(missileSO.damage);
                SelfDestroy();
            }
        }
    }

    private void SelfDestroy()
    {
        GameObject explosion = Instantiate(missileSO.explosionPrefab, transform);
        explosion.transform.parent = null;

        Destroy(gameObject);
    }
}
