# SnakeNet

<!--
NOTE: .NET 10 Preview 4 is currently not available for download on GitHub Actions. The following badges may show failing status until a new preview or stable version is released by Microsoft.
-->
[![Build .NET 10 (Windows 10/11 Preview)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/build-dotnet10-preview.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/build-dotnet10-preview.yml)
[![Build .NET 10 (Ubuntu 25.04)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/build-dotnet10-ubuntu-2504.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/build-dotnet10-ubuntu-2504.yml)

## Compatibility

| Operating System      | Framework          | Supported            | Note                                                     |
|----------------------|--------------------|----------------------|----------------------------------------------------------|
| Windows 10/11        | .NET 10 Preview    | ⚠️ (CI not available) | Modern MAUI version                                      |
| Ubuntu 25.04         | .NET 10 Preview    | ⚠️ (CI not available) | GTK (Linux)                                              |
| macOS (Catalyst)     | .NET 10 Preview    | ⚠️ (CI not available) | Mac Catalyst                                             |
| Windows 7/8/8.1      | .NET 6             || [SnakeNetClassic](https://github.com/WhiteWrym18/SnakeNetClassic)                 |
| Windows 95/98/ME     |[dotnet9x ](https://github.com/itsmattkc/dotnet9x)|| [SnakeNetClassic](https://github.com/WhiteWrym18/SnakeNetClassic) |
| Windows XP/Vista     | .NET Framework 3.5 || [SnakeNetClassic](https://github.com/WhiteWrym18/SnakeNetClassic)                 |

This application is compatible with Windows 10/11 (via .NET 10 Preview), Ubuntu 25.04 (via .NET 10 GTK), and macOS (via Mac Catalyst).


**Note:** .NET 10 Preview 4 is not currently available for download on GitHub Actions. CI builds for .NET 10 will fail until Microsoft releases a new preview or stable version. Local builds may still work if you have the SDK installed.

## Getting Started

Build and run with:

```
dotnet build -f net10.0-windows
# or
# dotnet build -f net10.0-gtk
# or
# dotnet build -f net10.0-maccatalyst
```
