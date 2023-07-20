using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour, IWeapon
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private WeaponSO weaponSO;
    [SerializeField]
    private GameObject fireEffect;

    private float cooldonwTimer;
    private bool onCooldown;

    public event EventHandler OnShoot;
    public event EventHandler OnRecharged;

    private void Start()
    {
        onCooldown = false;
        cooldonwTimer = weaponSO.cooldownTime;
    }

    public void Shoot()
    {
        if (!onCooldown)
        {
            AudioSource.PlayClipAtPoint(weaponSO.shootSound, Vector3.zero, 1f);
            GameObject fireFX = Instantiate(fireEffect, firePoint);

            GameObject missile = Instantiate(weaponSO.missileSO.missilePrefab, firePoint);
            missile.transform.parent = null;
            Rigidbody2D missileRB = missile.GetComponent<Rigidbody2D>();

            Vector3 velocityVector3 = transform.up * weaponSO.missileSO.missileSpeed;
            Vector2 velocityVector2 = new Vector2(velocityVector3.x, velocityVector3.y);
            missileRB.velocity = velocityVector2;

            OnShoot(this, EventArgs.Empty);
            cooldonwTimer = 0;
        }

    }
    private void FixedUpdate()
    {
        if (cooldonwTimer < weaponSO.cooldownTime)
        {
            onCooldown = true;
            cooldonwTimer += Time.fixedDeltaTime;
        }
        else
        {
            onCooldown = false;
            OnRecharged(this, EventArgs.Empty);
        }
    }



}
