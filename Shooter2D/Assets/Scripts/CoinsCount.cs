using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCount : MonoBehaviour
{
    [SerializeField] private Pickup pickup;
    [SerializeField] private TMP_Text countText;
    private int coinsCount;

    private void Start()
    {
        countText.text = 0.ToString();
        coinsCount = 0;
        pickup.OnPickupItem += Pickup_OnPickupItem;
    }

    private void Pickup_OnPickupItem(object sender, Pickup.OnPickupItemArgs e)
    {
            coinsCount++;
            countText.text=coinsCount.ToString();
    }
    private void OnDestroy()
    {
        pickup.OnPickupItem -= Pickup_OnPickupItem;
    }
}
