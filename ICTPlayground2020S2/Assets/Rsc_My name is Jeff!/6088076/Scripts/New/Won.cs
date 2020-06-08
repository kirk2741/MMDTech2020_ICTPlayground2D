using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MainMenu.isWon = true;
    }
}
