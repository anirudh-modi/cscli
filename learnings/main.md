# Learnings

## Declaring a constant file
To declare a file which will contian constants to be used in the application, one needs to use a `static` class, with either `const` variables.

```
namespace cscli
{
    static class Constants
    {
        // A public constant which can be accessed by anyone
        public const string SPACED_TABLE = "SPACED_TABLE";

        // A private constant which can only be accessed inside the 
        // current class
        private const string TAB_TABLE = "TAB_TABLE";
    }
}
```

## Declaring a helper file
To declare a file which may contian helper functions or constants, one needs to use a `static` class, with either `const` variables or `static` method.

```
namespace cscli
{
    static class ConsoleHelper
    
        // A helper function which does not return anything
        public static void PrintRow(string text)
        {
            Console.Writeline(text);
        }
        
        // A helper function which return a string
        public static sgtring GetPrettyRow(string text)
        {
            return "---" + text + "---";
        }       
    }
}
```