using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Inventory 
{
[System.Serializable]
  public class Slot
    {
        public string itemName;
        public int count;
        public int maxAllowed;

        public Sprite icon;
        public Slot() {  //slot constructor everytinhng starts with 0
            itemName = ""; 
            count = 0;
            maxAllowed = 99;
        }

        public bool canAddItem()  //dolu mudur?
        {
            if (count < maxAllowed) { return true; }
            else { return false; }
        }
        
        public void addItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;   //resim aktarimi!!!
            count++;
        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if (count == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }
    }
    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)   //CONSTRUCTOR!!!
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();  //inventory icin slot ekleme
            slots.Add(slot);
        }
    }
    public void Add(Item item)
    {
        foreach (Slot slot in slots)
        {
            if(slot.itemName == item.data.itemName && slot.canAddItem())
            {
                slot.addItem(item);
                return;

            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.addItem(item);
                return;
            }
        }
    }
    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
}
