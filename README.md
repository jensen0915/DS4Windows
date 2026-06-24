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

This fork is maintained for controller compatibility fixes that are useful in my setup, especially Switch Pro and
Nintendo-style controller layouts. It keeps the original DS4Windows behavior where possible, but adds small fixes for
compatible controllers that do not report calibration or button layout the same way as official PlayStation devices.

The current fork-specific changes are:

- A `Gamepad (Nintendo layout)` preset for Nintendo/Switch face-button order.
- A Switch Pro stick calibration fallback for compatible controllers with missing or invalid calibration data.
- Hidden update checks in debug builds, so local development runs do not prompt for upstream releases.

## License

DS4Windows is licensed under the terms of the GNU General Public License version 3.
You can find a copy of the terms and conditions of that license at
[https://www.gnu.org/licenses/gpl-3.0.txt](https://www.gnu.org/licenses/gpl-3.0.txt). The license is also
available in this source code from the COPYING file.

## Downloads

Ready-to-run builds for this fork are published on the
[GitHub Releases page](https://github.com/jensen0915/DS4Windows/releases).

For most Windows PCs, download the latest `DS4Windows_*_x64.zip` file from
[the latest release](https://github.com/jensen0915/DS4Windows/releases/latest).

## Install

1. Download `DS4Windows_*_x64.zip` from the latest GitHub Release.
2. Extract the ZIP to any folder you prefer.
3. Run `DS4Windows.exe`.

`ds4w.bat` is not the recommended install path for this fork because it may download a different upstream build.

Windows SmartScreen may warn that `DS4Windows.exe` is from an unknown publisher because this fork is not code-signed.
This is a personal fork, and I do not currently have extra budget for a paid code-signing certificate.
If you downloaded it from this repository's Releases page, choose **More info** and **Run anyway** to start it.

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

## Publishing a release

This repo includes a GitHub Actions release workflow. To publish a build:

1. Open the [new release page](https://github.com/jensen0915/DS4Windows/releases/new).
2. Create a new tag, for example `v3.5.1`, targeting `main`.
3. Set the release title to `DS4Windows v3.5.1`.
4. Add release notes describing the changes.
5. Leave the binary attachment area empty.
6. Click **Publish release**.

After publishing, GitHub Actions will build the app and attach the x64/x86 ZIP files to the release. If the files do
not appear immediately, wait for the release workflow to finish in the Actions tab.

If the release only shows GitHub's automatic `Source code (zip)` and `Source code (tar.gz)` files, open
**Actions**, choose **.NET Release**, click **Run workflow**, and enter the release tag such as `v3.5.1`.

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
