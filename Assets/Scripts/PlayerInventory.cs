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
    [Space] [SerializeField] GameObject inventoryScreen;

    public static float reachDistance { get; } = 3;
    public static UnityEvent<Vector3> Pickup = new();

    static int inventorySize;
    
    static int shellsInInventory;
    static int pearlsInInventory;
    static int sandInInventory;

    static List<string> generalInventory = new();
    public Transform generalInventoryUI;

    string itemToDecrease;
    int amountToDecreaseBy;
    bool? increaseItems;

    void Awake() {
        TradesClick.OnTradesClick += Trade;

        _shellsInventoryText = shellsInventory;
        _pearlsInventoryText = pearlsInventory;
        _sandInventoryText = sandInventory;
    }

    void OnPickup()
    {
        Pickup?.Invoke(transform.position);
    }

    void UpdateGeneralInventoryUI() {
        for (int i = 0; i < generalInventory.Count; i++) {
            var item = generalInventory[i];

            generalInventoryUI.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = (Sprite)Resources.Load($"Assets//Sprites//{item}");
        }
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

        for (int i = 0; i < generalInventory.Count; i++) {
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

    bool Trade(Trade t) {
        return DecreaseItem(t.inputItem.ToLower(), t.inputAmount) && IncreaseItem(t.outputItem.ToLower(), t.outputAmount);
    }

    bool DecreaseItem(string item, int amount) {
        if (amount == 0 || item == "") {
            return true;
        }

        if (item == "shell" && shellsInInventory >= amount) {
            itemToDecrease = item;
            amountToDecreaseBy = amount;
            StartCoroutine("DecreaseItemInLockstep");
            return true;
        }

        if (item == "pearl" && pearlsInInventory >= amount) {
            itemToDecrease = item;
            amountToDecreaseBy = amount;
            StartCoroutine("DecreaseItemInLockstep");
            return true;
        }

        if (item == "sand" && sandInInventory >= amount) {
            itemToDecrease = item;
            amountToDecreaseBy = amount;
            StartCoroutine("DecreaseItemInLockstep");
            return true;
        }

        int runningTally = 0;
        foreach (string inventoryItem in generalInventory) {
            if (inventoryItem.Equals(item)) {
                runningTally++;
            }
        }

        if (runningTally >= amount) {
            itemToDecrease = item;
            amountToDecreaseBy = amount;
            StartCoroutine("DecreaseItemInLockstep");
            return true;
        }

        print("Trade failed to assign decrement of input item.");
        return false;
    }

    IEnumerator DecreaseItemInLockstep()
    {
        while (true) {
            if (increaseItems is null) yield return null;
            else break;
        }

        if (!(bool)increaseItems)
            yield break;

        if (itemToDecrease is null || amountToDecreaseBy == 0) {
            yield break;
        }

        if (itemToDecrease == "shell") {
            shellsInInventory -= amountToDecreaseBy;
            _shellsInventoryText.text = shellsInInventory.ToString();
            yield break;
        }

        if (itemToDecrease == "pearl") {
            pearlsInInventory -= amountToDecreaseBy;
            _pearlsInventoryText.text = pearlsInInventory.ToString();
            yield break;
        }        

        if (itemToDecrease == "sand") {
            sandInInventory -= amountToDecreaseBy;
            _sandInventoryText.text = sandInInventory.ToString();
            yield break;
        }

        int count = 0;
        for (int i = 0; i < generalInventory.Count; i++) {
            if (generalInventory[i].Equals(itemToDecrease)) {
                generalInventory.RemoveAt(i);
                count++;
                if (count == amountToDecreaseBy) {
                    break;
                }
            }
        }
        
        UpdateGeneralInventoryUI();
    }

    bool IncreaseItem(string item, int amount) {
        if (item is null || item == "" || amount == 0) {
            increaseItems = true;
            return true;
        }

        if (item == "shell") {
            shellsInInventory += amount;
            _shellsInventoryText.text = shellsInInventory.ToString();
            increaseItems = true;
            return true;
        }

        if (item == "pearl") {
            pearlsInInventory += amount;
            _pearlsInventoryText.text = pearlsInInventory.ToString();
            increaseItems = true;
            return true;
        }
        
        if (item == "sand") {
            sandInInventory += amount;
            _sandInventoryText.text = sandInInventory.ToString();
            increaseItems = true;
            return true;
        }

        if (generalInventory.Count + amount < inventorySize) {
            increaseItems = true;
            for (int i = 0; i < amount; i++) {
                generalInventory.Add(item);
                UpdateGeneralInventoryUI();
            }
        }

        print("Trade failed to increase output item.");
        increaseItems = false;
        return false;  
    }

    void OnInventory() {
        inventoryScreen.SetActive(!inventoryScreen.activeSelf);
    }
}
