using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<ItemsData> m_itemData = new List<ItemsData>();

    [SerializeField]
    private InventoryItemList m_keyItem;
    [SerializeField]
    private InventoryItemList m_healthItem;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        ShowKeyItems();
    }

    private void LoadData ()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "itemsData.csv");

        string rawData = File.ReadAllText(filePath);

        string[] lines = rawData.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            // Skip Header
            if (i == 0)
                continue;

            string[] item = lines[i].Split(',');

            ItemsData newData = new ItemsData();

            newData.ID = item[0];
            newData.Name = item[1];
            newData.Desc = item[2];
            newData.Type = item[3];

            newData.Icon = Path.Combine("IconsForder", newData.Type, newData.ID);

            m_itemData.Add(newData);
        }
    }

    public void ShowKeyItems()
    {
        m_healthItem.CloseItems();
        m_keyItem.ShowItems(m_itemData.FindAll(d => d.Type.Equals("Key")));
    }

    public void ShowHealthItems ()
    {
        m_keyItem.CloseItems();
        m_healthItem.ShowItems(m_itemData.FindAll(d => d.Type.Equals("Health")));
    }
}
