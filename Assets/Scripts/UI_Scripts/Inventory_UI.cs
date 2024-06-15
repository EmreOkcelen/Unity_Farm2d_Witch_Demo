using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    public ImageRotation imageRotation; // ImageRotation bileþenini tutacak referans

    void Start()
    {
        imageRotation = GetComponentInChildren<ImageRotation>(); // ÝmageRotation bileþenini al
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
            ToggleImageRotation(); // ÝmageRotation kodunu çalýþtýr
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++) 
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItembyName(
            player.inventory.slots[slotID].itemName);

        if(itemToDrop != null) 
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
    }

    public void ToggleImageRotation()
    {
        imageRotation.ToggleRotation(); // ÝmageRotation kodundaki dönme iþlemini tetikle
    }
}