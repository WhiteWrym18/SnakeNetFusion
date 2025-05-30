# SnakeNetFusion

<!--
NOTE: .NET 10 Preview 4 is currently not available for download on GitHub Actions. The following badges may show failing status until a new preview or stable version is released by Microsoft.
-->
[![Build .NET 10 Preview (Windows 10/11)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/.net10-preview-windows.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/.net10-preview-windows.yml)
[![Build .NET 10 Preview (Ubuntu 24.04)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/.net10-ubuntu-2404.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/.net10-ubuntu-2404.yml)
[![Build .NET 10 Preview (macOS Catalyst)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/.net10-MacCatalyst.yml/badge.svg?branch=main)](https://github.com/WhiteWrym18/SnakeNetFusion/actions/workflows/.net10-MacCatalyst.yml)

## Compatibility

| Operating System      | Framework          | Supported            | Note                                                     |
|----------------------|--------------------|----------------------|----------------------------------------------------------|
| Windows 10/11        | .NET 10 Preview    | ⚠️ (CI not available) | Modern MAUI version                                      |
| Ubuntu 24.04         | .NET 10 Preview    | ⚠️ (CI not available) | GTK (Linux)                                              |
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

## Note sull'integrazione Game Center

Tuttavia, considera che:


- , né la lettura dello stato degli achievements o delle classifiche (solo invio/visualizzazione).

Se ti serve anche la lettura dei punteggi, la gestione di eventi di autenticazione, o , chiedi pure!
