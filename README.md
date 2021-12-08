# *KWALITY* ( SMART AIR POLLUTION MONITORING)

**An application to simulate an Air Pollution Monitoring Device.**

This application simulates the communication between Microsoft Azure IoT Central and an IoT device designed to collect pollution level data from it's immediate environment. IoT Central treats this simulation as real and the communication code between this device app and the IoT Central app is the same for a real device.

The application sends pollution level data extracted from csv files. The csv files were extracted from the daily survey data provided by the United States Environmental Protection Agency (EPA) using Microsoft Excel.
The various telemetric readings so derived are transmitted to the cloud and can be viewed, analysed and controlled from the client's IoT Central Hub.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

In order to successfully run this application the following should be installed on your local machine

* .NetCore SDK
* Visual studio
* C# extension for visual studio
* Basic knowledge of c#
Also a Microsoft Azure account and **Azure IoT Central** app is necessary as this app will communicate with ur cloud app using connection keys 

### Installing

Before running the program run the following lines of code in the visual studio terminal. This will install some of the necessary packages
```
dotnet add package AzureMapsRestToolkit --version 7.1.0
```

```
dotnet add package Microsoft.Azure.Devices.Client --version 1.39.0
```

```
dotnet add package Microsoft.Azure.Devices.Provisioning.Client --version 1.19.0
```

```
dotnet add package Microsoft.Azure.Devices.Provisioning.Transport.Mqtt --version 1.17.0
```

```
dotnet add package System.Text.Json --version 6.0.0
```

```
dotnet add package LumenWorksCsvReader
```

## Deployment
The program is run by navigating to it's directory in the terminal and inserting the following code
```
dotnet run 
```

## Built With

* [.NET 6.0](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Visual Studio Code](https://visualstudio.microsoft.com/downloads/) - The IDE used
* [Ominisharp](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) - c# extension for vscode
* [LumenWorksCsvReader](https://www.nuget.org/packages/LumenWorksCsvReader/) - Used to import csv into c# data tables
* Microsoft Excel
* [Microsoft Azure IoT Central](https://azure.microsoft.com/en-us/services/iot-central/)


## Authors

* **Oni Abdulazeez** - *Initial work* - [cheifowo](https://github.com/cheifowo)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hearty Thanks to my team mates who contributed one way or another to the success of this project
* Hats off to Microsoft learn for its guidance on how to implement various cloud solutions using Microsoft Azure and for providing the sample code on which this is based
* United States EPA for providing accurate and clean data on airquailty
* The Microsoft Africa Development Center Team
* And all Microsoft Student Ambassadors. Big Ups!!!
