# Open Weather

OpenWeather is a .NET C # Sample solution that contains a WPF app built using the MVVM pattern, a Windows Service that accesses the user's current weather data in background using OpenWeatherMapApi, a .NET library to access the OpenWeatherMapApi data, a .NET library to persist the weather data in a SQLite database and SetupProject generated by the installer of the WPF app and the Windows Service.

## Basic setup
### Required tools
To build this solution, the following tools were used:
* [Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/)
* [.NET 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
* [Microsoft Visual Studio Installer Projects](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects)

### Required libraries
The following libraries where installed using nugget:
* [Ninject](http://www.ninject.org/)
* [SQLite-net](https://github.com/praeclarum/sqlite-net)

## Assumptions
* This project was built **assumpting the user has internet connection**.
* This project was built **assumpting the user has enabled the access location in the device running the application**.
![Access location](/images/AccessLocation.png?raw=true "Access location")

## About the solution

This solution is composed of 5 projects:

 - **OpenWeatherApp:** **WPF** app built using the **MVVM** pattern with simple and basics classes to support the pattern. In this app you can Start/Stop the windows service that access to the weather data and **update and visualize** the latest weather data stored by the windows service. 
 - **OpenWeatherDataStore:** Simple **.NET library** to **persist** the weather **data** using **SQLite**.
 - **OpenWeatherMapApi**: Simple **.NET library** to **request** the weather **data** from the **OpenWeatherMapApi**. This library was buit auto generating code using [AutoRest](https://github.com/Azure/autorest) and doing just minimum changes.
 - **OpenWeatherService:** **Windows Service** that **access** to the weather data using **OpenWeatherMapApi project** and **store** it in a **SQLite database** using **OpenWeatherDataStore project**.
 - **OpenWeatherInstaller:** **Setup Project** built using [Microsoft Visual Studio Installer Projects](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects) to create an installer (.msi) that install the WPF application and the Windows Service.

## Running the solution
To execute this project you must follow the following steps:
### Download visual studio solution
`git clone https://github.com/agallardol/open-weather.git`
### Edit App.config file
You can change all of this config vars, but **to run the project you just need to config OpenWeatherMapApiAppId**.
 * **OpenWeatherMapApiBaseAddress:** It's the base address of the [OpenWeatherMapApi](https://openweathermap.org/api), for example, "https://api.openweathermap.org/data/2.5/".
 * **OpenWeatherMapApiAppId:** It's the AppId created in the OpenWeatherMap platform.
 * **DataStoreFileName:** It's the filename to persist the weather data using sqlite.
 * **GetCurrentWeatherServiceName:** It's the service name of the Windows Service contained in the OpenWeatherService project.

### Build solution
Open "OpenWeather.sln" using Visual Studio Community 2019, then "Right Click" in .sln file and select "Build solution".
### Install OpenWeatherService
* Navigate to project folder
* Enter to OpenWeatherService/bin/[debug|release]
* Open PowerShell and run `installutil -u .\OpenWeatherService.exe`

At this point you will have the Windows service installed =D

![OpenWeatherService](/images/OpenWeatherService.png?raw=true "OpenWeatherService")

### Run OpenWeatherApp
* At this point just press Play in Visual Studio =D
![OpenWeatherApp](/images/OpenWeatherApp.png?raw=true "OpenWeatherApp")

## Creating the installer
The installer of the app just **"Right Click"** on the **"OpenWeatherInstaller"** project and select **"Build project"**.

At this point you will have the following files:

![Installer of the WPF app and the Windows Service](/images/Installer.png?raw=true "Installer of the WPF app and the Windows Service")
