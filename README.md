<a href="https://streetcoder.org">
  <img alt="book cover" src="https://user-images.githubusercontent.com/241217/150715271-6bcbf5ae-ed59-4360-94bd-dac1c000b1ea.png" width="100">
</a>

# about

This repository contains the example code snippets 
referenced in my book [Street Coder](https://streetcoder.org)
published by Manning Publications.

# requirements

Almost all projects target the latest .NET LTS release. They targeted .NET 5 originally, 
but .NET 5 support ended in early 2022. With this upgrade, you can build the projects 
using current tools with as little installation work and warnings as possible. 
The source code is still in parity with the book. I plan on maintaining 
this repository as easily buildable as possible for readers.

I also added a new "modern" branch to adopt newer coding conventions like nullable references,
primary constructors, records and so forth. Don't hesitate to check that out to see how
things are done on a newer version of .NET and C#.

One project requires .NET Framework 4.8 which was required for the migration example. 
You can open `streetcoder-nowin.slnf` solution filter to filter it out instead of the main
solution file `streetcoder.sln`.

You can open and build solution and project files using the latest version 
of [Visual Studio](https://visualstudio.microsoft.com/vs/). The Community Edition of Visual Studio 
is free for personal use, ~and it's available on Mac too.~

You can also use [Visual Studio Code](https://code.visualstudio.com/) with 
[OmniSharp C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) 
if you find it more comfortable.

# notes
- The different flavors of the same function may have different names in the source 
  code while they're called the same in the repository. For example, `Contains` 
  function can have variants like `Contains2` and `Contains3` in the source code, but 
  it's listed as `Contains` in all the listings with different varieties. That's 
  intentional to keep the whole source code compilable without any trouble.
  Some flavors can use a word-based suffix instead of a numeric one.

