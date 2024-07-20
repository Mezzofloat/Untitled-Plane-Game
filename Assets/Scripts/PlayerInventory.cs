using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] TMP_Text shellsInventory;
    static TMP_Text _shellsInventoryText;

    [SerializeField] TMP_Text pearlsInventory;
    static TMP_Text _pearlsInventoryText;

    [SerializeField] GameObject shell, pearl;

    public static float reachDistance { get; } = 3;
    public static UnityEvent<Vector3> Pickup = new();
    
    static int shellsInInventory;
    static int pearlsInInventory;

    static string[] generalInventory = new string[21];

    void Awake() {
        TradesClick.OnTradesClick += Trade;

        _shellsInventoryText = shellsInventory;
        _pearlsInventoryText = pearlsInventory;
    }

    // Start is called before the first frame update
    void OnPickup()
    {
        Pickup?.Invoke(transform.position);
    }

    public static void AddItem(string item) {
        if (item == "shell") {
            shellsInInventory++;
            _shellsInventoryText.text = shellsInInventory.ToString();
            return;
        } else if (item == "pearl") {
            pearlsInInventory++;
            _pearlsInventoryText.text = pearlsInInventory.ToString();
            return;
        }

        for (int i = 0; i < generalInventory.Length; i++) {
            if (generalInventory[i] is null) {
                generalInventory[i] = item;
                return;
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
