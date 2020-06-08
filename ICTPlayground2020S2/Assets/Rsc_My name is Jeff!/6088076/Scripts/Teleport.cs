using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject targetPlayer;
    public static Transform teleportTargetStatic;
    public static GameObject Player;
    public bool isWarp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (teleportTarget)
        {
            teleportTargetStatic = teleportTarget;
        }
        else
        {
            teleportTargetStatic = GameObject.FindGameObjectWithTag("CheckPoint").transform;
        }
        if (targetPlayer)
        {
            Player = targetPlayer;
        }
        else
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        

        if (isWarp)
        {
            TeleportPlayer();
        }



    }

    public static void TeleportPlayer()
    {
        if (teleportTargetStatic)
        {
            if (Player)
            {
                Player.transform.position = teleportTargetStatic.transform.position;
            }
            else
            {
                Player = GameObject.FindGameObjectWithTag("Player");
                Player.transform.position = teleportTargetStatic.transform.position;
            }
        }
        else
        {
            teleportTargetStatic = GameObject.FindGameObjectWithTag("CheckPoint").transform;
            if (Player)
            {
                Player.transform.position = teleportTargetStatic.transform.position;
            }
            else
            {
                Player = GameObject.FindGameObjectWithTag("Player");
                Player.transform.position = teleportTargetStatic.transform.position;
            }
        }


            
    }



}
