using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("Player")){
        PickUp();
      }
    }

    void PickUp(){
      Debug.Log("Picked up object");
      gameObject.SetActive(false);
    }
}
