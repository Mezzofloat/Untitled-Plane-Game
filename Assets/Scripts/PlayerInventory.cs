using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] TMP_Text shellsInventory;
    [SerializeField] TMP_Text pearlsInventory;

    [SerializeField] float reachDistance;
    [SerializeField] GameObject shell, pearl;
    
    int shellsInInventory;
    int pearlsInInventory;

    void Awake() {
        TradesClick.OnTradesClick += Trade;
    }

    // Start is called before the first frame update
    void OnPickup()
    {
        for (int i = 0; i < SpawnValuables.shells.Count; i++) {
            float sqrDistance = (transform.position - SpawnValuables.shells[i].position).sqrMagnitude;
            if (sqrDistance <= reachDistance * reachDistance) {
                shellsInInventory++;
                shellsInventory.text = shellsInInventory.ToString();

                Destroy(SpawnValuables.shells[i].gameObject);
                SpawnValuables.shells.RemoveAt(i);
            }
        }
        
        for (int i = 0; i < SpawnValuables.pearls.Count; i++) {
            float sqrDistance = (transform.position - SpawnValuables.pearls[i].position).sqrMagnitude;
            if (sqrDistance <= reachDistance * reachDistance) {
                pearlsInInventory++;
                pearlsInventory.text = pearlsInInventory.ToString();

                Destroy(SpawnValuables.pearls[i].gameObject);
                SpawnValuables.pearls.RemoveAt(i);
            }
        }
    }

    void OnDrop() {
        if (shellsInInventory > 0) {
            shellsInInventory--;
            shellsInventory.text = shellsInInventory.ToString();

            GameObject newShell = Instantiate(shell, transform.position, transform.rotation);
            SpawnValuables.shells.Add(newShell.transform);
        } else if (pearlsInInventory > 0) {
            pearlsInInventory--;
            pearlsInventory.text = pearlsInInventory.ToString();

            GameObject newPearl = Instantiate(pearl, transform.position, transform.rotation);
            SpawnValuables.pearls.Add(newPearl.transform);
        }
    }

    void Trade(TradesClick tc) {
        if (int.TryParse(tc.GetComponentsInChildren<TextMeshProUGUI>()[0].text.Split(' ')[0], out var result)) {
            if (shellsInInventory >= result) { 
                shellsInInventory -= result;
                shellsInventory.text = shellsInInventory.ToString();

                pearlsInInventory += int.Parse(tc.GetComponentsInChildren<TextMeshProUGUI>()[1].text.Split(' ')[0]);
                pearlsInventory.text = pearlsInInventory.ToString();
            }
        }
    }
}
