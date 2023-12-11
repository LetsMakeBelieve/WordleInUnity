using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyTile : MonoBehaviour
{
    private Color originalColor = new Color(1f, 1f, 1f);
    public char letter { get; private set; }
    private TextMeshProUGUI theText;
    private Outline theOutline;
    private bool green = false;
    private bool yellow = false;

    private void Awake()
    {
        theText = GetComponentInChildren<TextMeshProUGUI>();
        theOutline = GetComponent<Outline>();
        letter = theText.text[0];
    }

    public void setGreenBool(bool choice){
        green = choice;
    }
    public bool isGreen(){
        return green;
    }

    public void setYellowBool(bool choice){
        yellow = choice;
    }
    public bool isYellow(){
        return yellow;
    }

    public char GetLetter()
    {
        return letter;
    }

    public void clearKey(){
        green = false;
        yellow = false;
        theText.color = originalColor;
        theOutline.effectColor = originalColor;
    }

    public void changeColor(Color targetColor)
    {
        theText.color = targetColor;
        theOutline.effectColor = targetColor;
    }
}
