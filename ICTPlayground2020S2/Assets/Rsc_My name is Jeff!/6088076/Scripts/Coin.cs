using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool destroySelfOnHit;
    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player"))
        {
            return;
        }
        // TODO: Logic on pickup the coin here
        // ++PlayerUnit.CoinsCollected; deprecated
        PlayerUnit theUnit = collider.gameObject.GetComponent<PlayerUnit>();
        if (theUnit != null)
        {
            theUnit.CollectCoin();
        }

        if (destroySelfOnHit)
        {
            Destroy(gameObject);
        }

    }
}
