using UnityEngine;
using UnityEngine.Events;

public class PlayerUnit : MonoBehaviour
{
    [Header("Player Property")]
    public int CoinsCollected = 0;
    public int CoinsToCollected = 0;
    [Header("Event Callbacks")]
    public UnityEvent onPlayerCollectingCoin;

    [Header("End game special VFX")]
    public GameObject[] fireworks;

    void Awake()
    {
        CoinsToCollected =
            GameObject.FindGameObjectsWithTag("Coins").Length;
    }
    // Update is called once per frame
    void Update()
    {
        // Check coins collect
        if (CoinsCollected >= CoinsToCollected)
        {
            foreach (GameObject o in fireworks)
            {
                if (!o.activeSelf)
                { o.SetActive(true); }
            }
        }
    }

    public void CollectCoin()
    {
        CoinsCollected++;
        onPlayerCollectingCoin.Invoke();
    }
} // End of class
