using System;
using System.Text.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Devices.Provisioning.Client;
using Microsoft.Azure.Devices.Provisioning.Client.Transport;
using LumenWorks.Framework.IO.Csv;

namespace air_pollution_monitoring_device
{
    class Program
    {
        // Telemetry globals.
        const int intervalInMilliseconds = 5000;        // Time interval required by wait function.

        // Read csv files

        // Monitoring Device globals.
        
        var co_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\carbon_monoxide.csv")), true))  
        {  
            co_table.Load(csvReader);  
        }  

        var no_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\nitrogen_dioxide.csv")), true))  
        {  
            no_table.Load(csvReader);  
        }  

        var o3_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\ozone.csv")), true))  
        {  
            o3_table.Load(csvReader);  
        }  

        var pm10_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\pm10.csv")), true))  
        {  
            pm10_table.Load(csvReader);  
        }  


        var pm25_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\pm25.csv")), true))  
        {  
            pm25_table.Load(csvReader);  
        }  

       var rh_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\relative_humidity.csv")), true))  
        {  
            rh_table.Load(csvReader);  
        }  


        var temp_table = new DataTable();  
        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\csv files\temperature.csv")), true))  
        {  
            temp_table.Load(csvReader);  
        }  



        // IoT Central global variables.
        static DeviceClient s_deviceClient;
        static CancellationTokenSource cts;
        static string GlobalDeviceEndpoint = "global.azure-devices-provisioning.net";
        static TwinCollection reportedProperties = new TwinCollection();

        // User IDs.
        static string IDScope = "0ne0044FD15";
        static string DeviceID = "RefrigeratedTruck1";
        static string PrimaryKey = "K5DyehF5gv4du3v9MZucWUXIU6wc0XGvA0YicuQZK2U=";


    };

    //collect progressive data input from the csv files
    static void UpdateDevice()
    {
        Collect_Temperature=
        collect_co = co_conc[i];


    };

    //Fancy Text
     static void colorMessage(string text, ConsoleColor clr)
    {
        Console.ForegroundColor = clr;
        Console.WriteLine(text + "\n");
        Console.ResetColor();
    }
    static void greenMessage(string text)
    {
        colorMessage(text, ConsoleColor.Green);
    }

    static void redMessage(string text)
    {
        colorMessage(text, ConsoleColor.Red);
    }


    static async void SendDeviceTelemetryAsync(Random rand, CancellationToken token)
    {
        while (true)
        {
            UpdateDevice();

            // Create the telemetry JSON message.
            var telemetryDataPoint = new
            {
                CarbonMonoixideConc =collect_co
                OzoneConc = state.ToString(),
                NitrogenDioxideConc = fan.ToString(),
                PM10Conc = contents.ToString(),
                PM25Conc = new { lon = currentLon, lat = currentLat },
                Temperature = eventText,
                Humidity = 
            };
            var telemetryMessageString = JsonSerializer.Serialize(telemetryDataPoint);
            var telemetryMessage = new Message(Encoding.ASCII.GetBytes(telemetryMessageString));

            Console.WriteLine($"Telemetry data: {telemetryMessageString}");

            // Bail if requested.
            token.ThrowIfCancellationRequested();

            // Send the telemetry message.
            await s_deviceClient.SendEventAsync(telemetryMessage);
            greenMessage($"Telemetry sent {DateTime.Now.ToShortTimeString()}");

            await Task.Delay(intervalInMilliseconds);
        }
    }

// Initiallize the  Connection

    static void Main(string[] args)
        {

            rand = new Random();
            colorMessage("Starting The Device", ConsoleColor.Yellow);
            
            

            try
            {
                using (var security = new SecurityProviderSymmetricKey(DeviceID, PrimaryKey, null))
                {
                    DeviceRegistrationResult result = RegisterDeviceAsync(security).GetAwaiter().GetResult();
                    if (result.Status != ProvisioningRegistrationStatusType.Assigned)
                    {
                        Console.WriteLine("Failed to register device");
                        return;
                    }
                    IAuthenticationMethod auth = new DeviceAuthenticationWithRegistrySymmetricKey(result.DeviceId, (security as SecurityProviderSymmetricKey).GetPrimaryKey());
                    s_deviceClient = DeviceClient.Create(result.AssignedHub, auth, TransportType.Mqtt);
                }
                greenMessage("Device successfully connected to Azure IoT Central");

                SendDevicePropertiesAsync().GetAwaiter().GetResult();

                Console.Write("Register settings changed handler...");
                s_deviceClient.SetDesiredPropertyUpdateCallbackAsync(HandleSettingChanged, null).GetAwaiter().GetResult();
                Console.WriteLine("Done");

                cts = new CancellationTokenSource();

                
                SendDeviceTelemetryAsync(rand, cts.Token);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                cts.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
        }


        public static async Task<DeviceRegistrationResult> RegisterDeviceAsync(SecurityProviderSymmetricKey security)
        {
            Console.WriteLine("Register device...");

            using (var transport = new ProvisioningTransportHandlerMqtt(TransportFallbackType.TcpOnly))
            {
                ProvisioningDeviceClient provClient =
                          ProvisioningDeviceClient.Create(GlobalDeviceEndpoint, IDScope, security, transport);

                Console.WriteLine($"RegistrationID = {security.GetRegistrationID()}");

                Console.Write("ProvisioningClient RegisterAsync...");
                DeviceRegistrationResult result = await provClient.RegisterAsync();

                Console.WriteLine($"{result.Status}");

                return result;
            }
        }
    }
   


}