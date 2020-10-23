# Declaring a constant file
To declare a file which will contian constants to be used in the application, one needs to use a `static` class, with either `const` variables.

```
namespace learning
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

## Usage
```
using static learning.Constants;

namespace learning
{
    static void Main()
    {
        Console.WriteLine(SPACED_TABLE);
    }
}
```

# Declaring a helper file
To declare a file which may contian helper functions or constants, one needs to use a `static` class, with either `const` variables or `static` method.

```
namespace learning
{
    static class ConsoleHelper
    {
    
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


## Usage
```
using static learning.ConsoleHelper;

namespace learning
{
    static void Main()
    {
        PrintRow("Hellow world");
    }
}
```

# Declaring Array of objects
To declare an `array` of `objects`, we can either define the type of the object by creating a `class` holding the blueprint for our object and create instance of the `new CustomClass`, or create an `anonymous` object.

## Class based approach
```
namespace learning
{
    static class ObjectHelper
    {
        // Declaring a new type of object named Row which will have properties
        //      title : of string type
        //      description : of string type
        //      isHeader : of bool type
        public class Row
        {
            public string title;
            public string description;
            public bool isHeader;
            // we can also define private members here

            public Row(string title, string description, bool isHeader)
            {
                this.title = title;
                this.description = description;
                this.isHeader = isHeader;
            }
        }
    }
}
```

### Usage
```
using learning;

namespace learningExecutor
{
    class LearningExecutor
    {
        static void Main()
        {
            ObjectHelper.Row[] rows = new ObjectHelper.Row[] {
                new ObjectHelper.Row("add", "this is a test", false),
                new ObjectHelper.Row("tasks", "Listing all the tasks is a test", false),
            };

            // ObjectHelper.Row[] rows defines that the type of the rows variable
            // is an array of ObjetHelper.Row

            // new ObjectHelper.Row[] creates an array of Row with its member as
            //  new ObjectHelper.Row("add", "this is a test", false)
        }
    }
}
```

## Anonymous object based approach

```
// Usage

namespace learningExecutor
{
    class LearningExecutor
    {
        static void Main()
        {
            var rows = new[] {
                new { title = "add",  description = "this is a test", isHeader = false }, // This creates an anonymous object
                new { title = "tasks",  description = "this is a test", isHeader = false },
            };
        }
    }
}
```
