using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public char letter { get; private set; }
    private TextMeshProUGUI theText;
    public Image theImage;

    private void Awake()
    {
        theText = GetComponentInChildren<TextMeshProUGUI>();
        theImage = GetComponent<Image>();
        letter = ' ';
    }

    /// <summary>
    /// set text in box to this letter
    /// </summary>
    /// <param name="letter">char it will be set to</param>
    public void SetLetter(char letter)
    {
        this.letter = letter;
        theText.text = letter.ToString();
    }

    /// <summary>
    /// return letter in specific box
    /// </summary>
    /// <returns></returns>
    public char GetLetter()
    {
        return letter;
    }

    public void flip(Color color)
    {
        StartCoroutine(FlipAnimation(color));
    }

    public void changeColor(Color targetColor)
    {
        theImage.color = targetColor;
    }
    
    /// <summary>
    /// animation function controls y-value of scale for pseudo animation (go from 1 to 0 to 1 again and change color at 0)
    /// </summary>
    /// <param name="color">Color the square should turn after guess (0 for green, 1 for yellow, 2 for grey)</param>
    private IEnumerator FlipAnimation(Color targetColor)
    {
        float flipDuration = .5f;   //time flip should be completed in
        float flipTime = 0f;        //tracker of the flip
        Vector3 originalScale = transform.localScale;
        bool flipped = false; // To check if we have flipped to the targetColor yet

        while (flipTime < flipDuration)
        {
            flipTime += Time.deltaTime;
            float scaleY;

            if (flipTime < flipDuration / 2f)
            {
                // First half of the animation
                scaleY = Mathf.Lerp(1, 0, flipTime / (flipDuration / 2f));
            }
            else
            {
                // Change color once when halfway through
                if (!flipped)
                {
                    theImage.color = targetColor;
                    flipped = true;
                }
                // Second half of the animation
                scaleY = Mathf.Lerp(0, 1, (flipTime - flipDuration / 2f) / (flipDuration / 2f));
            }

            transform.localScale = new Vector3(originalScale.x, scaleY, originalScale.z);

            if (flipTime >= flipDuration)
            {
                transform.localScale = originalScale; // Reset scale to original
                theImage.color = targetColor;
                break; // Exit the loop
            }

            yield return null;
        }
    }
}