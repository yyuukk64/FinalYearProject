using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordControl : MonoBehaviour
{
    public Image st;
    public string entering;

    [SerializeField]
    Sprite img_null;
    [SerializeField]
    Sprite img_0;
    [SerializeField]
    Sprite img_1;
    [SerializeField]
    Sprite img_2;
    [SerializeField]
    Sprite img_3;
    [SerializeField]
    Sprite img_4;
    [SerializeField]
    Sprite img_5;
    [SerializeField]
    Sprite img_6;
    [SerializeField]
    Sprite img_7;
    [SerializeField]
    Sprite img_8;
    [SerializeField]
    Sprite img_9;

    public void Increace()
    {
        if (st.sprite == img_null || st.sprite == img_9)
        {
            st.sprite = img_0;
            entering = "0";
        }
        else if (st.sprite == img_0)
        {
            st.sprite = img_1;
            entering = "1";
        }
        else if (st.sprite == img_1)
        {
            st.sprite = img_2;
            entering = "2";
        }
        else if (st.sprite == img_2)
        {
            st.sprite = img_3;
            entering = "3";
        }
        else if (st.sprite == img_3)
        {
            st.sprite = img_4;
            entering = "4";
        }
        else if (st.sprite == img_4)
        {
            st.sprite = img_5;
            entering = "5";
        }
        else if (st.sprite == img_5)
        {
            st.sprite = img_6;
            entering = "6";
        }
        else if (st.sprite == img_6)
        {
            st.sprite = img_7;
            entering = "7";
        }
        else if (st.sprite == img_7)
        {
            st.sprite = img_8;
            entering = "8";
        }
        else if (st.sprite == img_8)
        {
            st.sprite = img_9;
            entering = "9";
        }
    }

    public void Decreace()
    {
        if (st.sprite == img_null || st.sprite == img_1)
        {
            st.sprite = img_0;
            entering = "0";
        }
        else if (st.sprite == img_2)
        {
            st.sprite = img_1;
            entering = "1";
        }
        else if (st.sprite == img_3)
        {
            st.sprite = img_2;
            entering = "2";
        }
        else if (st.sprite == img_4)
        {
            st.sprite = img_3;
            entering = "3";
        }
        else if (st.sprite == img_5)
        {
            st.sprite = img_4;
            entering = "4";
        }
        else if (st.sprite == img_6)
        {
            st.sprite = img_5;
            entering = "5";
        }
        else if (st.sprite == img_7)
        {
            st.sprite = img_6;
            entering = "6";
        }
        else if (st.sprite == img_8)
        {
            st.sprite = img_7;
            entering = "7";
        }
        else if (st.sprite == img_9)
        {
            st.sprite = img_8;
            entering = "8";
        }
        else if (st.sprite == img_0)
        {
            st.sprite = img_9;
            entering = "9";
        }
    }
}
