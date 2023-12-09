using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private KeyRow[] keyRows;

    private void Awake()
    {
        keyRows = GetComponentsInChildren<KeyRow>();
    }

    //reset keyboard

    //get key index (KeyRow[x].Key[THIS PART])
    private List<int> getKeyIndexes(string guess)
    {
        List<int> indexes = new List<int>();
        string upperString = guess.ToUpper();
        string alphabetTop = "QWERTYUIOP";
        string alphabetMid = "ASDFGHJKL";
        string alphabetBot = "ZXCVBNM";

        for (int i = 0; i < upperString.Length; i++)
        {
            if (alphabetTop.Contains(upperString[i]))
            {
                indexes.Add(alphabetTop.IndexOf(upperString[i]));
            }
            else if (alphabetMid.Contains(upperString[i]))
            {
                indexes.Add(alphabetMid.IndexOf(upperString[i]));
            }
            else  if (alphabetBot.Contains(upperString[i]))
            {
                indexes.Add(alphabetBot.IndexOf(upperString[i]));
            }
        }

        return indexes;

    }

    private List<int> getKeyRowIndexes(string guess)
    {
        List<int> indexes = new List<int>();
        string upperString = guess.ToUpper();
        string alphabetTop = "QWERTYUIOP";
        string alphabetMid = "ASDFGHJKL";

        for (int i = 0; i < guess.Length; i++)
        {
            if (alphabetTop.Contains(upperString[i]))
            {
                indexes.Add(0);    
            }
            else if (alphabetMid.Contains(upperString[i]))
            {
                indexes.Add(1);
            }
            else 
            {
                indexes.Add(2);
            }
        }

        return indexes;
    }

    public void changeKeyboardColor(string guess, List<string> letterColor) {

        Color green = new Color(108f / 255f, 169f / 255f, 101f / 255f);
        Color yellow = new Color(200f / 255f, 182f / 255f, 83f / 255f);
        Color grey = new Color(120f / 255f, 124f / 255f, 127f / 255f);

        List<int> keyRowIndex = getKeyRowIndexes(guess);
        List<int> keyIndex = getKeyIndexes(guess);

        for (int i = 0; i < guess.Length; i++)
        {
            KeyTile currentKey = keyRows[keyRowIndex[i]].keys[keyIndex[i]];
            string currentColor = letterColor[i];

            if (currentColor == "Green")
            {
                currentKey.changeColor(green);
            }
            else if (currentColor == "Yellow" && currentKey.getColor() != green)
            {
                currentKey.changeColor(yellow);
            }
            else //grey or any other color
            {
                currentKey.changeColor(grey);
            }
        }
    }
}
