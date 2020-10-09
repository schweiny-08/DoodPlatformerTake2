using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxDetector : MonoBehaviour
{
    public string text;
    public Text TextBox;

    void Start() {
        TextBox = GameObject.Find("Text").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TextBox.text = text;//"This is a checkpoint.\nYou will spawn at an activated\ncheckpoint when you die.";
            Debug.Log(text);
        }
    }
}
