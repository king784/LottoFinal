using System;

[Serializable]
public class Item
{
    public int itemId;
    public string itemName;
    public string description;

    public Item(int id, string name, string description)
    {
        this.itemId = id;
        this.itemName = name;
        this.description = description;
    }
}
