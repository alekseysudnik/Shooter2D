using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabilizeUI : MonoBehaviour
{
    private Transform[] UIelements;
    private Vector3[] initialPositions;
    [SerializeField]
    private Transform referenceObject;

    private void Start()
    {
        UIelements = new Transform[transform.childCount];

        for (int i = 0; i < UIelements.Length; ++i)
        {
            UIelements[i]= transform.GetChild(i);
        }
       
        initialPositions = new Vector3[UIelements.Length];

        for (int i = 0; i < UIelements.Length; ++i) 
        {
            initialPositions[i] = UIelements[i].localPosition;
        }

    }
    private void Update()
    {
        for (int i = 0; i < UIelements.Length; ++i)
        {
            UIelements[i].SetPositionAndRotation(referenceObject.position + initialPositions[i], Quaternion.identity);
        }
    }
}
