using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyTile : MonoBehaviour
{
    public char letter { get; private set; }
    private TextMeshProUGUI theText;
    public Outline theOutline;

    private void Awake()
    {
        theText = GetComponentInChildren<TextMeshProUGUI>();
        theOutline = GetComponent<Outline>();
        letter = theText.text[0];
    }

    public char GetLetter()
    {
        return letter;
    }

    public Color getColor(){
        return theText.color;
    }

    public void changeColor(Color targetColor)
    {
        theText.color = targetColor;
        theOutline.effectColor = targetColor;
    }
}
