# C# basics

## Getting started
The best way to get started with a C# project is to use `dotnet` cli tool. For simplicity sake we would stick to a cli application.
  - First let us create a folder named `dotnetcli`
  - `cd dotnetcli` to move into the directory from your terminal
  - run `dotnet new console`

Once the setup is completed. It would give create a dotnet project with certain files in the `cwd`. 

## Folder structure
We would be explore the prupose of each files and folder individually. Before, that lets look at the folder structure created within our `dotnetinit` folder.

```
dotnetinit
  - bin
  - obj
  - dotnetinit.csproj
  - Progam.cs
```

## File purposes

Let us first explore and understand the purpose of folder and files present iin the application created by dotnet cli tool.

### Summary
  - `bin` and `obj` folder contains you compiled code
  - `dotnetinit.csproj` contains information about how to build a project
  - `*.cs` where you actually code

### Program.cs
**Every `dotnet` application must have a starting point, this starting point is described by having a `Main` method under any desired class.**

By default `dotnet` cli tool will create a file named `Program.cs`, which contains the `Program` class which holds the starting point for us, ie the `Main` method. 

As long as your application is having `Main` method dotnet will successfully execute you program, irrespective of in which file your `Main` method lies, however, neeedless to say it is a standard to follow, to keep the entry point of your application in `Program.cs` under the `Program` class to be more clear about the starting point of your application. 

Now let's explore the basic code inside the `Program.cs`.

```
using System;

namespace dotnetinit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

- [`using`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive) is used a directive which allows us to use the diffferent types and objects defined in a given `namespace`, in this case the `System` namespace
- [`namespace`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace), keyword allows us to create a scope under which different tyeps and objects are declared. It is namespace which we use to import codes across modules. 

  A given `namespace` can contain
    - `class`
    - `enum`
    - `interface`
    - `delegate`
    - sub `namespace`
    - `struct`

  By default every C# file runs in an unnamed `namespace` (added by the C# compiler), often referred as the global `namespace`. And any type which not defined under    a `namespace` will by default belong to the global `namespace`.

  When a class or a type needs to resolved by a C# compiler it would first try to find if the given type is present in the current `namespace` or not. 
  If the type is not present in the current `namespace` it would try to find the type in its immedidate parent `namespace`, and it continues to do the same until it reaches the global/default `namespace`. One can also access members of default `namespace` by using `global::`.

- [`class Program`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class) is used to declare a new class, only single inheritance is allowed in C#. 
- [`static void Main`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/) is the entry point of every `dotnet` application, like mentioned previously, every `dotnet` application must have a single starting point which is `Main` method, as a convention/standard it is always placed under the `Program` class present in the `Progam.cs`. The parameters to the `Main` method are array of `String` which are passed to the application during its runtime.
    - `Main` should always be a `static` method implying that the method can be invoked without creating an instance of the class.
    - by default `Main` methods are [`private`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers).

### dotnetinit.csporj


## Sources
  - https://www.geeksforgeeks.org/main-method-in-c-sharp/
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
  - https://stackoverflow.com/a/15022530/4197363
  - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/
