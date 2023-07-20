using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGunVisual : MonoBehaviour
{
    private IWeapon weapon;
    [SerializeField]
    private Color cooldownColor;
    private Color initialColor;

    private SpriteRenderer spriteRenderer;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        weapon =gameObject.GetComponentInParent<IWeapon>();
        weapon.OnShoot += Weapon_OnShoot;
        weapon.OnRecharged += Weapon_OnRecharged;
    }

    private void Weapon_OnRecharged(object sender, System.EventArgs e)
    {
        spriteRenderer.color = initialColor;
    }

    private void Weapon_OnShoot(object sender, System.EventArgs e)
    {
        spriteRenderer.color = cooldownColor;
    }
    private void OnDisable()
    {
        weapon.OnShoot -= Weapon_OnShoot;
        weapon.OnRecharged -= Weapon_OnRecharged;
    }
}
