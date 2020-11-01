# C#.Net basics

## Getting started
The best way to get started with a `C#.Net` project is to use `dotnet` cli tool. For simplicity sake we would stick to a cli application.
  - First let us create a folder named `dotnetcli`
  - `cd dotnetcli` to move into the directory from your terminal
  - run `dotnet new console`

Once the setup is completed. It would give create a `dotnet` project with certain files in the `cwd`. 

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

| File/Folder         | Purpose                                              |
| ------------------- | ---------------------------------------------------- |
| `bin` and `obj`     | These folders contains your compiled code            |
| `dotnetinit.csproj` | contains information about how to build your project |
| `*.cs`              | where your actual code would live                    |


### `Program.cs`
<details>
<summary> Click to Read</summary>
  
  **Every `dotnet` application must have a starting point, this starting point is described by having a `Main` method under any desired class.**

  By default `dotnet` cli tool will create a file named `Program.cs`, which contains the `Program` class which holds the starting point for us, ie the `Main`   method. 

  As long as your application is having `Main` method dotnet will successfully execute you program, irrespective of in which file your `Main` method lies, however,   neeedless to say it is a standard to follow, to keep the entry point of your application in `Program.cs` under the `Program` class to be more clear about the     starting point of your application. 

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
</details>

### `dotnetinit.csporj`
<details>
  <summary>Click to Read</summary>
  
  As `dotnet` is a platform which supports multiple language, and are compiled and run using the same standard command ie, 
  - `dotnet run` to build and run
  - `dotnet run --no-build` to simply run
  - `dotnet build` to simply build an existing code

  It becomes fairly evident that underlying the `dotnet build` command, there needs to be a build system which must be able to answer some basic questions:
  - language being used, which in turn should mean compiler to be used
  - the dependencies/packages being used
  - the language version to be used
  - the output to be generated
  
  These information are collected by `dotnet` by passing the `.csproj` file, to the underlying build system [MSBuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2019). Every `dotnet` project need to have a `*.proj` file depending on the language, in order to let dotnet understand how to build and run this project, ie;
  - `.csproj` for a `C#` project
  - `.fsproj` for `F#` projet
  - `vbproj` for `VB` project and so on..

</details>

### `bin` or `obj` folder
  <details>
  <summmary>Click to Read</summary>

  Both the `bin` an `obj` folder contains a complied code for our project. One may ask why do we need to keep compiled code in 2 different folders why not create a `bin` folder with the final output for the `dll/exe` files, that is because the entire build process is performed in *incrementally* manner. 
  
  We have to understand that the `MSBuild` is not responsible only for a simple compile the code to generate the `IL` files, [but the entire build is responsible for varied process](https://docs.microsoft.com/en-us/visualstudio/msbuild/build-process-overview?view=vs-2019) from 
  - language resolution
  - codee compilation
  - configuration files resolution
  - package resolution
  - runtime output resolution
  - dependent files resolution
  - managing local cache copy for next build, etc
  
  | NOTE                                                                                                                                                             |
  | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
  | For further information about the build steps look into [MSBuild doc](https://docs.microsoft.com/en-us/visualstudio/msbuild/build-process-overview?view=vs-2019) |

  Now resolving and performing each step on subsequent build may work on a small project which varies from a mere couple of files, however for huge projects performing those unrequired steps could simply increase the time spent in building the application, so to reduce this, `MSBuild` performs [Incremental builds](https://docs.microsoft.com/en-us/visualstudio/msbuild/incremental-builds?view=vs-2019) where it would compares changes in project with its previous build and perform only steps which are required rather than buiilding the whole project from ground. And for this reason the 2 folders are introduced, i.e. 
  -  `bin` folder will contain the final compiled code ie the Intermediate Langauge files which would then be consumed by the `Core CLR` to convert into `Machine Code` and run it.
  -  `obj` folder contain a **partially compiled code** which is later used to generate the final output `IL` files for the `bin` folder

  For better information you can try to compare the output of subsequent compilation by running 
  - `dotnet build -v=n` which would give a brief overviewe about which individual stages are being performed, for the entire build process, 
  - or run `dotnet build -v=d` which gives a detailed information of why a stage was skipped and why a stage was executed
  
  If you want to see how changing your code effects the build process watch out for step `Target "CoreCompile` which is responsible for compiling your code, and how changing the code would trigger this step and how not changing any code triggers this step.

</details>

## References
  - https://www.geeksforgeeks.org/main-method-in-c-sharp/
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
  - https://stackoverflow.com/a/15022530/4197363
  - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/
  - https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2019
  - https://docs.microsoft.com/en-us/visualstudio/msbuild/build-process-overview?view=vs-2019
  - https://docs.microsoft.com/en-us/visualstudio/msbuild/incremental-builds?view=vs-2019
