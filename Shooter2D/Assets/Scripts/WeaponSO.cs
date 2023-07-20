using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponSO : ScriptableObject 
{
    public GameObject weaponPrefab;
    public MissileSO missileSO;
    public AudioClip shootSound;
    public float cooldownTime;
    public string weaponName;

}
