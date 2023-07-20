using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField]
    private float moveAmplitude, moveFrequency;
    private void Update()
    {
        Vector3 displacement = Vector3.zero;
        displacement.y = moveAmplitude * Mathf.Sin(moveFrequency*Time.time);
        transform.position += displacement;
    }
}
