using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] float fadeTime;
    private Image blackScreen;

    void Start()
    {
        blackScreen = GetComponent<Image>();
        blackScreen.enabled = true;
    }

    void Update()
    {
        blackScreen.CrossFadeAlpha(0f, fadeTime, false);
    }
}
