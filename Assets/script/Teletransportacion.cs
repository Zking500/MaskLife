using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teletransportacion : MonoBehaviour
{
    public Transform target;
    public GameObject ThePlayer;

       private void OnTriggerEnter(Collider other)
    { 
        ThePlayer.transform.position = target.transform.position;
    }
}
