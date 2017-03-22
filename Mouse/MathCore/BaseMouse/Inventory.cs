using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    class Inventory
    {
        List<ItemInventory> Items;
        Dictionary<Slot,IEquipment> Doll;
        public Inventory()
        {
            Doll = new Dictionary<Slot, IEquipment>();
            Doll.Add(Slot.Body, null);
            Doll.Add(Slot.Head, null);
            Doll.Add(Slot.Shoes, null);

        }
        public void PutInSlot(IEquipment thing)
        {
           if(Doll[thing.EquipSlot] != null)
            {
                RemoveFromSlot(thing.EquipSlot);
            }
            Doll[thing.EquipSlot] = thing;
        }
        public void RemoveFromSlot(Slot slot)
        {
           if (Doll[slot] is ItemInventory)
            {
              var RemovedItem = Doll[slot] as ItemInventory;
              PutInHeapItems(RemovedItem);
            };
            Doll[slot] = null;   
        }
        public void PutInHeapItems(ItemInventory item )
        {
            Items.Add(item);
        }
        public void RemoveHeapItem(ItemInventory item)
        {
            Items.Remove(item);
        }
        public float CalcEquipmentBonus()
        {
            float outValue = 1;//коэффециент по умолчанию
            foreach (var item in Doll.Keys)
            {
                if(Doll[item] != null)
                    outValue += Doll[item].bonus;
            }
            return outValue;
        }
    }
}
