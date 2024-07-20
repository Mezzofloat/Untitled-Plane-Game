using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemOnGround : MonoBehaviour
{
    [SerializeField] string itemNameAllLowercase;

    void TakeObject(Vector3 player) {
        if ((player - transform.position).sqrMagnitude <= PlayerInventory.reachDistance) {
            PlayerInventory.AddItem(itemNameAllLowercase);
            PlayerInventory.Pickup.RemoveListener(this.TakeObject);
            Destroy(gameObject);
        }
    }

    void OnEnable() => PlayerInventory.Pickup.AddListener(this.TakeObject);
    void OnDisable() => PlayerInventory.Pickup.RemoveListener(this.TakeObject);
}
