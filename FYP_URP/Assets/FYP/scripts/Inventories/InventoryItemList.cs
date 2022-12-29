using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemList : MonoBehaviour
{
    [SerializeField]
    private GameObject m_itemPreb;

    [SerializeField]
    private Transform m_content;

    private List<ItemsData> m_items = new List<ItemsData>();
    private List<InventoryItem> m_itmeList = new List<InventoryItem>();

    public void ShowItems (List<ItemsData> _items)
    {
        //UpdateItems();

        this.gameObject.SetActive(true);

        foreach (ItemsData data in _items) 
        {
            if (!m_items.Contains(data))
            {
                InventoryItem itemObj = GameObject.Instantiate(m_itemPreb, m_content).GetComponent<InventoryItem>();

                Sprite icon = Resources.Load<Sprite>(data.Icon);

                itemObj.SetName(data.Name).SetDesciption(data.Desc).SetIcon(icon);
                itemObj.data = data;

                m_items.Add(data);
                m_itmeList.Add(itemObj);
            }
        }
    }

    public void UpdateItems()
    {
        //TODO: Create willbedelete list

        foreach (InventoryItem item in m_itmeList)
        {
            if (item.count < 1)
            {
                m_items.Remove(item.data);
                m_itmeList.Remove(item);

                Destroy(item.gameObject);
            }
        }
    }

    public void CloseItems ()
    {
        this.gameObject.SetActive(false);
    }
}
