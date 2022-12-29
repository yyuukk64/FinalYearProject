using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_itemName;
    [SerializeField]
    private TMP_Text m_itemDesc;
    [SerializeField]
    private Image m_itemIcon;

    public ItemsData data;
    public int count;

    public InventoryItem SetIcon (Sprite _spr)
    {
        m_itemIcon.sprite = _spr;

        return this;
    }

    public InventoryItem SetName (string _name)
    {
        m_itemName.text = _name;

        return this;
    }

    public InventoryItem SetDesciption (string _desc)
    {
        m_itemDesc.text = _desc;

        return this;
    }
}
