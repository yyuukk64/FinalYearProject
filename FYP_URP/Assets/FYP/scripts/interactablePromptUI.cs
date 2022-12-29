using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class interactablePromptUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    public bool IsDisplayed = false;

    // Start is called before the first frame update
    private void Start()
    {
        uiPanel.SetActive(false);
    }
    
    public void Setup(string promptText)
    {
        _promptText.text = promptText;
        uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
