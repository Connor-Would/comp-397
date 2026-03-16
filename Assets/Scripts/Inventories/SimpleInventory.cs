using System.Collections.Generic;

public class SimpleInventory : PersistentSingleton<SimpleInventory>
{ //this is a fixed inventory
    public int currency = 0;
    public int wood = 0;
    public int stone = 0;
    public int iron = 0;
    public bool hasWeapon = false;
    public bool hasQuiver = false;
    public bool hasPotion = false;
}
public class ArrayInventory : PersistentSingleton<ArrayInventory>
{
    public Item[] backpack = new Item[8]; //an array inventory
    public Item[] chest = new Item[64];
    public List<Item> dynamicSizeBackpack = new List<Item>(); //a dynamic inventory
}

[System.Serializable]
public class Item { public bool isStackable = false; }