using UnityEngine;
using UnityEngine.UI;

public class GUI_HUD : MonoBehaviour
{
    [Header("PlayerUnit")]
    public PlayerUnit playerUnit;

    [Header("GUI Elements")]
    public Text hudLine_2;
    public Text hudLine_3b;
    public bool showCurrentCoins = false;



    // Use this for initialization
    void Start()
    {
        RefreshCurrentCoins();
    }

    //////////////////// Update is called once per frame
    ////////////////////void Update()
    ////////////////////{
    ////////////////////    RefreshCurrentCoins();
    ////////////////////}

    public void RefreshCurrentCoins()
    {
        if ( showCurrentCoins )
        {
            if(hudLine_2 != null && playerUnit != null)
            {
                hudLine_2.text = "Coin "
                + playerUnit.CoinsCollected
                + " / " + playerUnit.CoinsToCollected;
            }
            
        }
    }

    public void RefreshRemainingTime( float value )
    {
        if( hudLine_3b != null )
        {
            hudLine_3b.text = value.ToString();
        }
    }
} // End of Class
