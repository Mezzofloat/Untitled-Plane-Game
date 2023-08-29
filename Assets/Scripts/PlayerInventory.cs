using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] TMP_Text inventory;
    [SerializeField] float reachDistance;
    [SerializeField] GameObject shell;
    
    int shellsInInventory;

    // Start is called before the first frame update
    void OnPickup()
    {
        for (int i = 0; i < ShellSpawn.shells.Count; i++) {
            float sqrDistance = (transform.position - ShellSpawn.shells[i].position).sqrMagnitude;
            if (sqrDistance <= reachDistance * reachDistance) {
                shellsInInventory++;
                inventory.text = shellsInInventory.ToString();

                Destroy(ShellSpawn.shells[i].gameObject);
                ShellSpawn.shells.RemoveAt(i);
            }
        }         
    }

    void OnDrop() {
        if (shellsInInventory > 0) {
            shellsInInventory--;
            inventory.text = shellsInInventory.ToString();

            GameObject newShell = Instantiate(shell, transform.position, transform.rotation);
            ShellSpawn.shells.Add(newShell.transform);
        }
    }
}
