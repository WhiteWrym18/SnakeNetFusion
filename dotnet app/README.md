# SnakeNet

<!--
NOTE: .NET 10 Preview 4 is currently not available for download on GitHub Actions. The following badges may show failing status until a new preview or stable version is released by Microsoft.
-->
![Build .NET 10 (Windows 10/11 Preview) - currently unavailable](https://github.com/WhiteWrym18/SnakeNet/actions/workflows/build-dotnet10-preview.yml/badge.svg)
![Build .NET 10 (Ubuntu 25.04) - currently unavailable](https://github.com/WhiteWrym18/SnakeNet/actions/workflows/build-dotnet10-ubuntu-2504.yml/badge.svg)
![Build .NET 6 (Windows 7 simulato)](https://github.com/WhiteWrym18/SnakeNet/actions/workflows/build-dotnet6-windows7.yml/badge.svg)

## Compatibility


| Operating System | Framework        | Supported |
|------------------|-----------------|-----------|
| Windows 7        | .NET 6          | ✅        |
| Windows 10/11    | .NET 10 Preview | ⚠️ (CI not available) |
| Ubuntu 25.04     | .NET 10 Preview | ⚠️ (CI not available) |

This application is compatible with Windows 7 (via .NET 6), Windows 10/11 (via .NET 10 Preview) and Ubuntu 25.04 (via .NET 10).

**Note:** .NET 10 Preview 4 is not currently available for download on GitHub Actions. CI builds for .NET 10 will fail until Microsoft releases a new preview or stable version. Local builds may still work if you have the SDK installed.

## Getting Started

Build and run with:

```
dotnet build -f net6.0-windows
# or
# dotnet build -f net10.0-windows
# or
# dotnet build -f net10.0
```
