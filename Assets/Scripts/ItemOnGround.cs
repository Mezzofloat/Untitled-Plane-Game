using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemOnGround : MonoBehaviour
{
    [SerializeField] PlayerInventory pi;
    [SerializeField] string itemNameAllLowercase;

    void TakeObject(Vector3 player) {
        if ((player - transform.position).sqrMagnitude <= pi.reachDistance) {
            pi.AddOrIncreaseItemCount(itemNameAllLowercase);
            pi.Pickup.RemoveListener(this.TakeObject);
            Destroy(this);
        }
    }

    void OnEnable() {
        pi.Pickup.AddListener(this.TakeObject);
    }

    void OnDisable() {
        pi.Pickup.RemoveListener(this.TakeObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
