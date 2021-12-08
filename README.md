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

Before running the program run the following lines of code in the visual studio terminal
```

```

And repeat

```
until finished
```

## Deployment
The program is run by navigating to it's directory in the terminal and inserting the following code
'''
dotnet run 
'''

## Built With

* [.NET 6.0](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Visual Studio Code](https://visualstudio.microsoft.com/downloads/) - The IDE used
* [Ominisharp](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) - c# extension for vscode
* [LumenWorksCsvReader](https://www.nuget.org/packages/LumenWorksCsvReader/) - Used to import csv into c# data tables
* Microsoft Excel
* [Microsoft Azure IoT Central](https://azure.microsoft.com/en-us/services/iot-central/)

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
