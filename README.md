# DS4Windows

Like those other DS4 tools, but sexier.

DS4Windows is an extract anywhere program that allows you to get the best
DualShock 4 experience on your PC. By emulating an Xbox 360 controller, many
more games are accessible. Other input controllers are also supported including the
DualSense, Switch Pro, and JoyCon controllers (**first party hardware only**).

This project is a fork of the work of Jays2Kings and Ryochan7. It adds various new features like switch
[debouncing](https://www.ganssle.com/debouncing.pdf), a tool that helps to fix stick drift and pitch and roll simulation
for DS3 based on accelerometer value (which is a work of [sunnyqeen](https://github.com/sunnyqeen)).

This fork also includes:

- A `Gamepad (Nintendo layout)` preset that swaps the face button layout for Nintendo/Switch muscle memory:
  `Cross -> B`, `Circle -> A`, `Square -> Y`, and `Triangle -> X`.
- A fallback for invalid Switch Pro stick calibration data so compatible controllers can keep a usable default stick range.
- Debug builds hide and skip update checks so local development builds do not prompt for upstream releases.

## About this fork

I've made this fork because some of the buttons on my controller started bouncing. Normally I would just add a
feature that would fix my problem, make a pull request to the original repo and forget about the project. 
The issue here is that Ryochan7 stopped maintaining the original project, so I decided to make slight 
modifications to the code that detects if the installed version is up-to-date, so it now pulls version info from my 
repo. This way if you install my version, you don't get the annoying popup saying your version is outdated. If there 
are any feature requests, I'm more than happy to at least look at them and assess whether I could add them.

## License

DS4Windows is licensed under the terms of the GNU General Public License version 3.
You can find a copy of the terms and conditions of that license at
[https://www.gnu.org/licenses/gpl-3.0.txt](https://www.gnu.org/licenses/gpl-3.0.txt). The license is also
available in this source code from the COPYING file.

## Downloads

- **[Main builds of DS4Windows](https://ds4-windows.com)**

For this fork, use the GitHub Releases page for ready-to-run builds. Publishing a release tag such as `v3.5.1`
will run the included `.github/workflows/release.yml` workflow and attach x64/x86 ZIP files to that release.

## Install

You can install DS4Windows by downloading it from [Official Website](https://ds4-windows.com) and place it to your preferred place.

Alternatively, you can download [`ds4w.bat`](https://github.com/ds4windowsapp/DS4Windows/blob/main/ds4w.bat) file and execute it. It will open a window that downloads and places the program in `%LOCALAPPDATA%\DS4Windows` and creates a desktop shortcut to the executable.

## Development

Visual Studio is not required. With the .NET 8 SDK installed, this repo can be built from VS Code or PowerShell:

```powershell
cd path\to\DS4Windows
$env:DOTNET_CLI_HOME="$PWD\.dotnet-home"
$env:NUGET_PACKAGES="$PWD\.nuget-packages"
dotnet build DS4WindowsWPF.sln -p:Platform=x64 --configfile NuGet.Config
```

The debug executable is written to:

```text
DS4Windows\bin\x64\Debug\net8.0-windows\DS4Windows.exe
```

For a local optimized build:

```powershell
dotnet build DS4WindowsWPF.sln -c Release -p:Platform=x64 --configfile NuGet.Config
```

## Requirements

- Windows 10 or newer (Thanks Microsoft)
- Microsoft .NET 8.0 Desktop Runtime. [x64](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.0-windows-x64-installer) or [x86](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.0-windows-x86-installer)
- Visual C++ 2015-2022 Redistributable. [x64](https://aka.ms/vs/17/release/vc_redist.x64.exe) or [x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)
- [ViGEmBus](https://vigembusdriver.com/) driver (DS4Windows will install it for you)
- **Sony** DualShock 4 or other supported controller
- Connection method:
  - Micro USB cable
  - [Sony Wireless Adapter](https://www.amazon.com/gp/product/B01KYVLKG2)
  - Bluetooth 4.0 (via an
  [adapter like this](https://www.newegg.com/Product/Product.aspx?Item=N82E16833166126)
  or built in pc). Only use of Microsoft BT stack is supported. CSR BT stack is
  confirmed to not work with the DS4 even though some CSR adapters work fine
  using Microsoft BT stack. Toshiba's adapters currently do not work.
  *Disabling 'Enable output data' in the controller profile settings might help with latency issues, but will disable lightbar and rumble support.*
- Disable **PlayStation Configuration Support** and
**Xbox Configuration Support** options in Steam
