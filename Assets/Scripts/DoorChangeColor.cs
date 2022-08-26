using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorChangeColor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        if (other.gameObject.tag == "Atm")
        {
            Destroy(gameObject);
        }
    }


}
