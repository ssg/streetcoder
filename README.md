# about

This repository contains the example code snippets 
referenced in my book [Street Coder](https://streetcoder.org)
published by Manning Publications.

# requirements

Most of the code requires at least .NET 5 to be built. One project requires 
.NET Framework which is required for the migration example at the moment. 
You can download the latest .NET SDK 
at [Microsoft's download page](https://dotnet.microsoft.com/download).

One project requires .NET Framework in order to be built as it's 
part of a scenario about migrating from .NET Framework to .NET Core. If you're
on an environment that can't build .NET Framework projects, you can open
`streetcoder-nowin.slnf` solution filter to filter it out instead of the main
solution file `streetcoder.sln`.

I used [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
whose Community Edition is free, but you should also be able to use 
[Visual Studio Code](https://code.visualstudio.com/)
with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) 
if you find it more comfortable.

# notes
- The different flavors of the same function may have different names in the source 
  code while they're called the same in the repository. For example, `Contains` 
  function can have variants like `Contains2` and `Contains3` in the source code, but 
  it's listed as `Contains` in all the listings with different varieties. That's 
  intentional to keep the whole source code compilable without any trouble.
  Some flavors can use a word-based suffix instead of a numeric one.
