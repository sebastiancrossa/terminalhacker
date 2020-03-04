using UnityEngine;

public class Hacker : MonoBehaviour
{
    // --- Game config data --- //
    string[] level1Passwords = { "books", "aisle", "self", "font", "borrow" };
    string[] level2Passwords = { "phone", "network", "computer", "tech", "mkbhd" };
    string[] level3Passwords = { "stoicism", "marcus", "plato", "aristotle", "seneca" };

    AudioSource errorSound;
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

        if (input == "menu")
        {
            // Reseting up our local variables
            currentScreen = Screen.MainMenu;

            Terminal.ClearScreen();
            showHeader();
            showMainMenu();
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
            Terminal.WriteLine("-= You have already cracked the code. Type \"menu\" to sign out =-");
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
                levelPassword = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                levelPassword = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                levelPassword = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("# Error : Invalid level number");
                break;
        }


        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your password, hint: " + levelPassword.Anagram());
        Terminal.WriteLine("Type menu to exit");
    }

    void checkPassword(string input)
    {
        string convertedInput = input.ToLower();

        if (levelPassword == input)
        {
            DisplayWinScreen();
        }
        else
        {
            StartGame(); // If the user gets the password wrong, a new hint will appear
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;

        Terminal.ClearScreen();

        Terminal.WriteLine("Congratulations! You are in");
        ShowLevelReward();

        Terminal.WriteLine("");
        Terminal.WriteLine("Type menu to exit");
    }

    void ShowLevelReward()
    {
        switch (gameLevel)
        {
            case 1:

                Terminal.WriteLine("Have a book");
                Terminal.WriteLine(@"
                    ______
                   /     //
                  /     //
                 /____ //
                (_____(/
                ");
                break;
            case 2:
                Terminal.WriteLine("Have a computer");
                Terminal.WriteLine(@"
                 _
                |-|  __
                |=| [Ll]
                |^| ====
                ");
                break;
            case 3:
                Terminal.WriteLine("Have a virtue");
                Terminal.WriteLine(@"
    \ |____
   .', ,  ()
  / -.  _)| 
 |_(_.    |
 '-'\  )  |
                ");
                break;
            default:
                break;
        }
    }
}
