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

    public void SetLetter(char letter)
    {
        this.letter = letter;
        theText.text = letter.ToString();
    }

    public char GetLetter()
    {
        return letter;
    }

    public float flipDuration = 1f;
    private float flipTime = 0f;
    private Vector3 originalScale;

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
        originalScale = transform.localScale;
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