# README for "Wordle in Unity"
## Introduction

"Wordle in Unity" is a personal project where I recreate the popular word game Wordle from scratch in Unity, without using any YouTube tutorials. Here is the (admittedly lackluster) game screen:
<img width="953" alt="Screenshot 2023-12-28 at 6 35 54 PM" src="https://github.com/LetsMakeBelieve/WordleInUnity/assets/134026692/493e67d2-90a1-4c71-b406-07d855b6d150">


Here 

## Project Timeline

- 11/22/23: Initial creation of the game scene, including text boxes and borders setup.
- 11/23/23: Developed a script for text input into the boxes.
- 11/24/23: Bug fixes for backspace functionality and letter deletion.
- 11/25/23: Implemented a word list and a script to populate string arrays with these words.
- 11/26/23: Enabled functionality for the enter/return key.
- 11/27/23: Created a game-over screen.
- 11/28/23: Added a restart button that clears the board.
- 12/3/23: Developed the game logic for tile color changes based on word correctness.
- 12/5/23: Implemented flipping animation for letters upon word submission.
- 12/6/23: Enhanced the flipping animation using coroutines for sequential flips.
- 12/7/23: Created a virtual keyboard with interactive buttons in Unity.
- 12/8/23: Added functionality for keyboard keys to change color upon word input.
- 12/9/23: Project uploaded to GitHub; learned GitHub basics.
- 12/10/23: Fixed color-changing issues with keyboard keys.
- 12/11/23: Enabled keyboard reset after each game.
- 12/12/23: Resolved issues with tile color persistence post-restart and premature game-over screen display.
- 12/23/23: Added click functionality to keyboard buttons for letter input and implemented auto-clearing of the row for incorrect words.
## Future Additions

- Return and Backspace Virtual Keys: To enhance the virtual keyboard's functionality and user experience.
- Enhanced UI for Game Over Screen: To improve visual appeal and user engagement.
- Improved Wordlist: A more comprehensive list including plurals but excluding overly obscure words.
- Interactive 'How to Play' Button: To guide new players through game rules and mechanics.
- Sound Effects and Mute Button: To add auditory feedback and give players control over sound settings.
- Hover Effect on Virtual Keyboard Keys: For a more interactive and responsive user interface.
## Installation

I'm still pretty new to github and how to actually use it, so I only really know how to install things on mac, but I'm sure its pretty similar on Windows/Linux platforms.
### Method 1: Git through the Console
#### Step 1: Copy the URL
Copy the Repository URL: https://github.com/LetsMakeBelieve/WordleInUnity or click the 'Clone or download' button and copy the repository URL.
#### Step 2: Cloning the Repo
Open a terminal or command prompt and navigate to the directory where you want to clone the project using ```cd <directory_path>``` (usually in your projects folder or Unity projects folder) and Run ```git clone <repository_URL>```.
#### Step 3: Opening the Project in Unity
Launch Unity hub and click on the 'Add' button in the Projects tab and navigate to the directory where you cloned the repository. When you find it, select the project folder and click 'Open'. Unity Hub will add the project to your Projects list. Ensure you have the correct version of Unity Editor installed for the project. If not, download the required version through Unity Hub. (<b>2022.3.9f1 is the Unity version</b>)
#### Step 4: Running the Game
Click on the project in Unity Hub to open it in Unity Editor. Click the 'Play' button at the top-center of the Unity Editor. The game should start playing in the Game view.

### Method 2: Github Desktop
#### Step 1: Copy the URL
Copy the Repository URL: https://github.com/LetsMakeBelieve/WordleInUnity or click the 'Clone or download' button and copy the repository URL.
#### Step 2: Cloning the Repo
Open GitHub Desktop and click on the button in the top left corner that says <b>Current Repository</b>. Next click on the <b>Add</b> button and click on the option that says <b>Clone Repository...</b>. You will have three little tabs on the little pop up, make sure to navigate to the <b>URL</b> tab. Paste the URL of this repository into the prompted input and select a file destination (probably your Github Projects or Unity Projects folder or whatever), afterwards click the button that says <b>Clone</b> and let it download, that should be all for this.
#### Step 3: Opening the Project in Unity
Launch Unity hub and click on the 'Add' button in the Projects tab and navigate to the directory where you cloned the repository. When you find it, select the project folder and click 'Open'. Unity Hub will add the project to your Projects list. Ensure you have the correct version of Unity Editor installed for the project. If not, download the required version through Unity Hub. (<b>2022.3.9f1 is the Unity version</b>)
#### Step 4: Running the Game
Click on the project in Unity Hub to open it in Unity Editor. Click the 'Play' button at the top-center of the Unity Editor. The game should start playing in the Game view.
## Usage

The game is the exact same controls as the NYT Wordle and follows these rules:
- You have to guess a 5 letter word in 6 attempts
- Every time you submit a guess, you learn more about the secret word
- Each letter of a guess will change to one of three colors: grey, yellow, or green.
- Grey indicates that the letter is not in the secret word
- Yellow indicates that the letter is in the word, but not in the correct position.
- Green indicates that the letter is both in the secret word and in the correct position.

(There will be a button in the game explaining the rules... hopefully I get around to that)

## Contributing

If you see anything you think you can add to improve and make better or just something you hate and want to change, I'd be happy to review any pull requests to the repo and probably add it.

## Contact

For any inquiries or contributions, please contact me at Mitchell2Karan@gmail.com.
