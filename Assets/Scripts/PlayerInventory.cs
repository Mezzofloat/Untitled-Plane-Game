using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] TMP_Text shellsInventory;
    [SerializeField] TMP_Text pearlsInventory;

    [SerializeField] GameObject shell, pearl;

    public static float reachDistance { get; } = 3;
    public static UnityEvent<Vector3> Pickup = new();
    
    int shellsInInventory;
    int pearlsInInventory;

    static Dictionary<string, int> generalInventory = new();

    void Awake() {
        TradesClick.OnTradesClick += Trade;
    }

    // Start is called before the first frame update
    void OnPickup()
    {
        Debug.Log("pickup initiated");
        Pickup?.Invoke(transform.position);
    }

    public static void AddOrIncreaseItemCount(string key) {
        print("function AddOrIncrease invoked");
        if (!generalInventory.TryAdd(key, 1)) {
            generalInventory[key]++;
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
