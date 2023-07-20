using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pickup;

public class Pickup : MonoBehaviour

{
    public class OnPickupItemArgs : EventArgs
    {
        public GameObject collectedObject { get; set; }
    }
    public event EventHandler<OnPickupItemArgs> OnPickupItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            OnPickupItem(this, new OnPickupItemArgs { collectedObject = collision.gameObject });
            Destroy(collision.gameObject);
        }
    }
}
