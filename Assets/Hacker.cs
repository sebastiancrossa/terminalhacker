using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // --- Game State --- //
    public int gameLevel;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    // --- --- //

    void showHeader()
    {
        Terminal.WriteLine("crossaOS v1.6.6 build 33861");
        Terminal.WriteLine("Initializing terminal ... Done");
        Terminal.WriteLine("user@crossaOS-user/home$");
    }

    void showMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose an option:");
        Terminal.WriteLine("Press 1 for LIBRARY");
        Terminal.WriteLine("Press 2 for TECHNOLOGY");
        Terminal.WriteLine("Press 3 for PHILOSOPHY");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    // Start is called before the first frame update
    void Start()
    {
        showHeader();
    }

    void HandleMenuState(string input)
    {
        switch (input)
        {
            case "hack":
                showMainMenu();
                break;
            case "1":
                gameLevel = 1;

                currentScreen = Screen.Password;
                StartGame();

                break;
            case "2":
                gameLevel = 2;

                currentScreen = Screen.Password;
                StartGame();

                break;
            case "3":
                gameLevel = 3;

                currentScreen = Screen.Password;
                StartGame();

                break;
            default:
                Terminal.WriteLine("");
                Terminal.WriteLine("----------------------------");
                Terminal.WriteLine("Please choose a valid level");
                Terminal.WriteLine("----------------------------");
                Terminal.WriteLine("");

                Terminal.WriteLine("user@crossaOS-user/home$");

                break;
        }
    }

    void HandlePasswordState(string input)
    {
        Terminal.WriteLine(input);
    }

    void HandleWinState()
    {
        Terminal.WriteLine("You win!");
    }

    void OnUserInput(string input)
    {
        // Base case - We always want the user to be able to return to the main menu
        if (currentScreen == Screen.MainMenu || currentScreen == Screen.Password || currentScreen == Screen.Win)
        {
            if (input == "hack")
            {
                // Reseting up our local variables
                gameLevel = 0;
                currentScreen = Screen.MainMenu;

                showMainMenu();
            }
        }

        if (currentScreen == Screen.MainMenu)
        {
            HandleMenuState(input);
        }
        else if (currentScreen == Screen.Password)
        {
            HandlePasswordState(input);
        }
        else if (currentScreen == Screen.Win)
        {
            HandleWinState();
        }
        else
        {
            Terminal.WriteLine("There is an error, please try again");
        }
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + gameLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
