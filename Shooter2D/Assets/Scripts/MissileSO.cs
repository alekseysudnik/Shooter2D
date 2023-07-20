using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MissileSO : ScriptableObject
{
    public GameObject missilePrefab;
    public GameObject explosionPrefab;
    public AudioClip woundSound;
    public AudioClip wallShootSound;
    public int damage;
    public float missileSpeed;

}
