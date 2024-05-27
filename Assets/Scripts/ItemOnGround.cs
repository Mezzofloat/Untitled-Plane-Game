using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemOnGround : MonoBehaviour
{
    [SerializeField] string itemNameAllLowercase;

    void TakeObject(Vector3 player) {
        print("TakeObject invoked");
        if ((player - transform.position).sqrMagnitude <= PlayerInventory.reachDistance) {
            print("if statement breached successfully");
            PlayerInventory.AddOrIncreaseItemCount(itemNameAllLowercase);
            PlayerInventory.Pickup.RemoveListener(this.TakeObject);
            Destroy(gameObject);
        }
    }

    void OnEnable() {
        PlayerInventory.Pickup.AddListener(this.TakeObject);
    }

    void OnDisable() {
        PlayerInventory.Pickup.RemoveListener(this.TakeObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
