using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject PickupEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if(PickupEffect)
            {
                Instantiate(PickupEffect,transform.position,Quaternion.identity);
            }
            GameManager.Instance.Collect();

            Destroy(gameObject);
        }
    }
}
