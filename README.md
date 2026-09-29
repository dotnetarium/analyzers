# analyzers

This is a reference copy of the security analyzers from the former
[dotnet/roslyn-analyzers](https://github.com/dotnet/roslyn-analyzers) repository.
It is not a dependency of the Dotnetarium NuGet package or global tool.

The current official source for these analyzers is in `dotnet/sdk`:

- [Security analyzer implementations](https://github.com/dotnet/sdk/tree/main/src/Microsoft.CodeAnalysis.NetAnalyzers/src/Microsoft.CodeAnalysis.NetAnalyzers/Microsoft.NetCore.Analyzers/Security)
- [Flow analysis utilities](https://github.com/dotnet/sdk/tree/main/src/Microsoft.CodeAnalysis.NetAnalyzers/src/Utilities/FlowAnalysis)
- [Security analyzer tests](https://github.com/dotnet/sdk/tree/main/src/Microsoft.CodeAnalysis.NetAnalyzers/tests/Microsoft.CodeAnalysis.NetAnalyzers.UnitTests/Microsoft.NetCore.Analyzers/Security)

Compare those directories before bringing newer analyzer code into Dotnetarium.
The former `dotnet/roslyn-analyzers` repository directs development of
`Microsoft.CodeAnalysis.NetAnalyzers` to `dotnet/sdk`.
