using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private AudioClip pickupSound;
    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(pickupSound,Vector3.zero,1f);
        GameObject effect = Instantiate(pickupEffect, transform);
        effect.transform.parent = null;
    }
}
