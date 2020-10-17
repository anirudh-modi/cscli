# C# basics

## Getting started
The best way to get started with a C# project is to use `dotnet` cli tool. For simplicity sake we would stick to a cli application.
  - First let us create a folder named `dotnetcli`
  - `cd dotnetcli` to move into the directory from your terminal
  - run `dotnet new console`

Once the setup is completed. It would give create a dotnet projet with certain files in the `cwd`. 

We would be explore the prupose of each files and folder individually. Before, that lets look at the folder structure created within our `dotnetinit` folder.

```
dotnetinit
  - bin
  - obj
  - dotnetinit.csporj
  - Progam.cs
```

## Summary
  - `bin` and `obj` folder contains you compiled code
  - `dotnetinit.csproj` contains information about how to build a project
  - `*.cs` where you actually code
 
## Program.cs
Need less to say all the `*.cs` files are were most of our code would be living and working with. But let us cover some fundamental things which are present in the `Program.cs` file.

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

  By default every C# file runs in an unnamed `namespace` (added by the C# compiler), often referred as the global `namespace`. And any type which not defined under a `namespace` will by default belong to the global `namespace`.

  When a class or a type needs to resolved by a C# compiler it would first try to find if the given type is present in the current `namespace` or not. 
  If the type is not present in the current `namespace` it would try to find the type in its immedidate parent `namespace`, and it continues to do the same until it reaches the global/default `namespace`. One can also access members of default `namespace` by using `global::`.

- [`class`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class)
- [`static`]
- [`void`]
- [`Main`]
