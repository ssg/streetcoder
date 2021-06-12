# about

This repository contains example code snippets 
referenced in my book [Street Coder](https://www.manning.com/books/street-coder)
published by Manning Books.

# requirements

Most of the code requires at least .NET 5
to be built. You can download the latest
.NET SDK at [Microsoft's download page](https://dotnet.microsoft.com/download).

One project requires .NET Framework in order to be built as it's 
part of a scenario about migrating from .NET Framework to .NET Core. 

I used [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
whose Community Edition is free, but you should also be able to use 
[Visual Studio Code](https://code.visualstudio.com/)
if you find it more comfortable.

# notes
- The different flavors of the same function may have different names in the source 
  code while they're called the same in the repository. For example, `Contains` 
  function can have variants like `Contains2` and `Contains3` in the source code, but 
  it's listed as `Contains` in all the listings with different varieties. That's 
  intentional to keep the whole source code compilable without any trouble.
  Some flavors can use a word-based suffix instead of a numeric one.