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

    [SerializeField] TMP_Text sandInventory;
    static TMP_Text _sandInventoryText;

    [SerializeField] GameObject shell, pearl, sand;

    public static float reachDistance { get; } = 3;
    public static UnityEvent<Vector3> Pickup = new();
    
    static int shellsInInventory;
    static int pearlsInInventory;
    static int sandInInventory;

    static string[] generalInventory = new string[20];

    void Awake() {
        TradesClick.OnTradesClick += Trade;

        _shellsInventoryText = shellsInventory;
        _pearlsInventoryText = pearlsInventory;
        _sandInventoryText = sandInventory;
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
        } else if (item == "sand") {
            sandInInventory++;
            _sandInventoryText.text = sandInInventory.ToString();
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
        } else if (sandInInventory > 0) {
            sandInInventory--;
            sandInventory.text = sandInInventory.ToString();

            GameObject newSand = Instantiate(sand, transform.position, transform.rotation);
            SpawnValuables.sands.Add(newSand.transform);
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
