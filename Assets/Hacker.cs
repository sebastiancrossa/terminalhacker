using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // --- Game config data --- //
    string[] level1Passwords = { "books", "aisle", "self", "font", "borrow" };
    string[] level2Passwords = { "phone", "network", "computer", "tech", "mkbhd" };
    string[] level3Passwords = { "stoicism", "marcus", "plato", "aristotle", "seneca" };
    // --- --- //


    // --- Game State --- //
    public int gameLevel;
    public string levelPassword;

    public enum Screen { MainMenu, Password, Win };
    public Screen currentScreen = Screen.MainMenu;
    // --- --- //

    void showHeader()
    {
        Terminal.WriteLine("crossaOS v1.6.6 build 33861");
        Terminal.WriteLine("Initializing terminal ... Done");
        Terminal.WriteLine("user@crossaOS-user/home$");
        Terminal.WriteLine("");
    }

    void showMainMenu()
    {
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
        showMainMenu();
    }

    void HandleMenuState(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");

        if (isValidLevel)
        {
            gameLevel = int.Parse(input);

            StartGame();
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("----------------------------");
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine("----------------------------");
            Terminal.WriteLine("");

            showMainMenu();
        }
    }


    void OnUserInput(string input)
    {
        // Base case - We always want the user to be able to return to the main menu
        if (currentScreen == Screen.MainMenu || currentScreen == Screen.Password || currentScreen == Screen.Win)
        {
            if (input == "menu")
            {
                // Reseting up our local variables
                currentScreen = Screen.MainMenu;

                Terminal.ClearScreen();
                showHeader();
                showMainMenu();
            }
        }

        if (currentScreen == Screen.MainMenu)
        {
            HandleMenuState(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            Terminal.WriteLine("-= You have CRACKED the CODE =-");
        }
        else
        {
            Terminal.WriteLine("There is an error, please try again");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;

        switch (gameLevel)
        {
            case 1:
                levelPassword = level1Passwords[3];
                break;
            case 2:
                levelPassword = level2Passwords[4];
                break;
            case 3:
                levelPassword = level3Passwords[0];
                break;
            default:
                Debug.LogError("# Error : Invalid level number");
                break;
        }


        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your password: ");
    }

    void checkPassword(string input)
    {
        string convertedInput = input.ToLower();

        if (levelPassword == input)
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Congratulations! You are in");
            Terminal.WriteLine("");

            currentScreen = Screen.Win;
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Sorry, wrong password!");
            Terminal.WriteLine("");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
