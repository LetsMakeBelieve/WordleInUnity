using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*TODO LIST:
-fix tileflip on restart
-fix game over screen
-check letters on keyboard for correct color (Edge Case: (SW: SWAMP Guess: MAMMA (issue with a not turning yellow)))
-reset keyboard colors
-shake effect on wrong word
-edit background ui
*/

public class Board : MonoBehaviour
{
    private List<string> WordList = new List<string>();
    private byte[] ByteList;
    public GameOver EndGame;

    /// <summary>
    /// Gets words from text document and stores them in the WordList
    /// </summary>
    private void ReadCSV() //holy shit this worked!
    {
        string path = Path.Combine(Application.streamingAssetsPath, "words.txt");
        char[] chars;

        if (!File.Exists(path))
        {
            Debug.Log("File does not exists\n");
        }
        else
        {
            ByteList = File.ReadAllBytes(path);
        }

        for (int z = 0; z <= ByteList.Length; z+=6)
        {
            string holder = "";
            for (int i = 0; i < 5; i++)
            {
                chars = System.Text.Encoding.ASCII.GetString(ByteList).ToCharArray();
                holder += chars[i+z];
            }
            WordList.Add(holder);
        }
    }

    /// <summary>
    /// Clears the board for a new game
    /// </summary>
    public void ClearBoard()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                rows[i].tiles[j].SetLetter(' ');
                rows[i].tiles[j].changeColor(new Color(18f / 255f, 19f / 255f, 18f / 255f));
            }
        }

        //keyboard.clearKeyboard();
        rowIndex = 0;
        colIndex = 0;
        typeLock = false;
        lastLetter = false;

        secretWord = NewSecretWord();
        Debug.Log(secretWord);
    }


    private static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[] {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, 
        KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P,
        KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
        KeyCode.Y, KeyCode.Z
    };

    private string NewSecretWord()
    {

        int randomIndex = Random.Range(0, WordList.Count);
        return WordList[randomIndex];
    }

    /// <summary>
    /// Checks if entered word ins in the word list
    /// </summary>
    /// <returns>True if word is in list or false otherwise</returns>
    private bool isValidWord() //use hash map here
    {
        string guess = getGuess();

        int listSize = WordList.Count;
        for(int i = 0; i < listSize; i++)
        {
            if (guess == WordList[i])
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// creates a string from char array of current row
    /// </summary>
    /// <returns>the guess as a string</returns>
    public string getGuess()
    {
        string guess = "";

        for (int i = 0; i < 5; i++)
        {
            guess += rows[rowIndex].tiles[i].GetLetter();
        }

        return guess;
    }

    private IEnumerator FlipTilesWithDelay(string secretWord)
    {
        string guess = getGuess();
        Color rgbValue;
        List<string> letterColor = new List<string>();
        typeLock = true;
        int rowIndexCopy = rowIndex;
        rowIndex++;
        colIndex = 0;

        Dictionary<char, int> secretCounts = new Dictionary<char, int>();
        //count occurrences of each letter in the secret word and store in dictionary
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (!secretCounts.ContainsKey(secretWord[i]))
            {
                secretCounts[secretWord[i]] = 0;
            }
            secretCounts[secretWord[i]]++;
        }

        //first pass (FP): Check for correct positions
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (guess[i] == secretWord[i])
            {
                letterColor.Add("Green");
                secretCounts[guess[i]]--; //decrease the count of the matched letter
            }
            else
            {
                letterColor.Add(""); // Placeholder for second pass
            }
        }

        // Second pass (SP): Check for correct letters in wrong positions
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (letterColor[i] == "") // Not matched in the first pass
            {
                if (secretWord.Contains(guess[i]) && secretCounts[guess[i]] > 0)
                {
                    letterColor[i] = "Yellow";
                    secretCounts[guess[i]]--; // Decrease the count of the matched letter
                }
                else
                {
                    letterColor[i] = "Grey";
                }
            }
        }

        //EXAMPLE:      secretWord = HEART && guess = GREAT
        //              Dictionary = ('G', 1),('R', 1),('E', 1),('A', 1),('T', 1)
        //
        //(After FP)    Dictionary = ('G', 1),('R', 1),('E', 1),('A', 1),('T', 0)
        //              letterColor = ("", "", "", "", "Green")
        //
        //(After SP)    Dictionary = ('G', 1),('R', 0),('E', 0),('A', 0),('T', 0)
        //              letterColor = ("Grey", "Yellow", "Yellow", "Yellow", "Green")

        for (int i = 0; i < guess.Length; i++)
        {
            if (letterColor[i] == "Green")
            {
                rgbValue = new Color(108f / 255f, 169f / 255f, 101f / 255f);
                rows[rowIndexCopy].tiles[i].flip(rgbValue);
                yield return new WaitForSeconds(.25f);
            }
            else if (letterColor[i] == "Yellow")
            {
                rgbValue = new Color(200f / 255f, 182f / 255f, 83f / 255f);
                rows[rowIndexCopy].tiles[i].flip(rgbValue);
                yield return new WaitForSeconds(.25f);
            }
            else
            {
                rgbValue = new Color(120f / 255f, 124f / 255f, 127f / 255f);
                rows[rowIndexCopy].tiles[i].flip(rgbValue);
                yield return new WaitForSeconds(.25f);
            }
        }

        keyboard.changeKeyboardColor(guess, letterColor);

        lastLetter = false;
        typeLock = false;
    }

    /// <summary>
    /// Checks the word against the guess and updates the tiles accordingly
    /// (eventually also update virtual keyboard)
    /// </summary>
    /// <param name="secretWord"></param>
    /// <param name="">Pass in the secret word</param>
    private void CheckWord(string secretWord)
    {
        StartCoroutine(FlipTilesWithDelay(secretWord));
    }

    /// <summary>
    /// Triggers gameover overlay
    /// </summary>
    /// <param name="win">checks if player guessed word or not</param>
    private void GameOver(bool win)
    {
        EndGame.Setup(rowIndex, win, secretWord);
    }

    //end game function should check if last word is correct or not

    private int colIndex = 0;
    private int rowIndex = 0;
    private bool lastLetter = false;
    private Row[] rows;
    public Keyboard keyboard; //public variable
    private string secretWord;
    private bool typeLock = false;

    private void Awake()
    {
        ReadCSV();
        rows = GetComponentsInChildren<Row>();
        ClearBoard();
    }

    private void Update(){
        //handling input
        for (int i = 0; i < SUPPORTED_KEYS.Length; i++){
            if (Input.GetKeyDown(SUPPORTED_KEYS[i]) && !typeLock){
                
                if(colIndex > 4){
                    break;
                }

                if(!lastLetter){
                    rows[rowIndex].tiles[colIndex].SetLetter((char)SUPPORTED_KEYS[i]);
                    colIndex++;
                }

                if(colIndex > 4){
                    lastLetter = true;
                    colIndex = 4;
                }
                break;
            }
        }

        //handling action keys
        if(Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete) && colIndex != 0 && !typeLock){
            typeLock = true;
            if (rows[rowIndex].tiles[colIndex].GetLetter() != ' '){
                rows[rowIndex].tiles[colIndex].SetLetter(' ');
            }
            else if (colIndex > 0){
                colIndex--;
                rows[rowIndex].tiles[colIndex].SetLetter(' ');

            }

            if (colIndex < 0){
                colIndex = 0;
            }

            lastLetter = false;
            typeLock = false;
        }


        if (Input.GetKeyDown(KeyCode.Return) && !typeLock)
        {
            if (getGuess() == secretWord)
            {
                GameOver(true);
                typeLock = true;
            } else if (colIndex == 4 && isValidWord() && rowIndex < 5)
            {
                CheckWord(secretWord);
            }
            else if (colIndex == 4 && isValidWord() && rowIndex == 5)
            {
                CheckWord(secretWord);
                typeLock = true;

                if(getGuess() == secretWord)
                {
                    GameOver(true);
                } else
                {
                    GameOver(false);
                }

            }


        }
    }
}
