using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamage : MonoBehaviour
{
    public static int DamageGet;
    public GameObject DamageText;
    public static bool Getdamage;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        DamageText.GetComponent<Text>().text = "";
    }
    void Update()
    {
        if (Getdamage)
        {
            DamageText.GetComponent<Text>().text = "-" + DamageGet;
            Invoke("GetdamageBool", 0.2f);
        }
    }

    void GetdamageBool()    
    {
        Getdamage = false;
        DamageText.GetComponent<Text>().text = "";
    }
}
