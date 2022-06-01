using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.Timers;

namespace Cansat2021
{
    public class CsvHelper
    {
        public static void writeCsvFromList(List<string> telemetryList, string path)
        {
            #region Option1
            if (!string.IsNullOrEmpty(telemetryList[3])) //si hay algún valor en la 4ta posición de la lista...
            {
                if (telemetryList[3] == "C")
                {
                    var records = new List<Container>
                    {
                        new Container {
                            TeamId = telemetryList[0],
                            MissionTime = telemetryList[1],
                            PacketCount = telemetryList[2],
                            PacketType = telemetryList[3],
                            Mode = telemetryList[4],
                            TPReleased = telemetryList[5],
                            Altitude = telemetryList[6],
                            Temperature = telemetryList[7],
                            Voltage = telemetryList[8],
                            GpsTime = telemetryList[9],
                            GpsLatitude = telemetryList[10],
                            GpsLongitude = telemetryList[11],
                            GpsAltitude = telemetryList[12],
                            GpsSats = telemetryList[13],
                            SoftwareState = telemetryList[14],
                            CmdEcho = telemetryList[15]
                        }
                    };
                    //string path = "C:\\Flight_1064_C.csv";
                    handleContainerFile(path+ "\\Flight_1064_C.csv", records);
                }
                else
                {
                    //string path;
                    var records = new List<SciencePayload>
                    {
                        new SciencePayload
                        {
                            TeamId = telemetryList[0],
                            MissionTime = telemetryList[1],
                            PacketCount = telemetryList[2],
                            PacketType = telemetryList[3],
                            TpAltitude = telemetryList[4],
                            TpTemperature = telemetryList[5],
                            TpVoltage = telemetryList[6],
                            GYRO_R = telemetryList[7],
                            GYRO_P = telemetryList[8],
                            GYRO_Y = telemetryList[9],
                            ACCEL_R = telemetryList[10],
                            ACCEL_P = telemetryList[11],
                            ACCEL_Y = telemetryList[12],
                            MAG_R = telemetryList[13],
                            MAG_P = telemetryList[14],
                            MAG_Y = telemetryList[15],
                            POINTING_ERROR = telemetryList[16],
                            TpSoftwareState = telemetryList[17]
                        }
                    };
                    string path2;

                    path2 = "\\Flight_1064_T.csv" ;
                    handlePayloadFile(path+path2, records);
                }
            }
            #endregion //cuando viene completo 12,265,155,,,,,,,,,,,

            #region Option2
            if (telemetryList.Count == 19)
            {
                var records = new List<Container>
                {
                    new Container {
                        TeamId = telemetryList[0],
                            MissionTime = telemetryList[1],
                            PacketCount = telemetryList[2],
                            PacketType = telemetryList[3],
                            Mode = telemetryList[4],
                            TPReleased = telemetryList[5],
                            Altitude = telemetryList[6],
                            Temperature = telemetryList[7],
                            Voltage = telemetryList[8],
                            GpsTime = telemetryList[9],
                            GpsLatitude = telemetryList[10],
                            GpsLongitude = telemetryList[11],
                            GpsAltitude = telemetryList[12],
                            GpsSats = telemetryList[13],
                            SoftwareState = telemetryList[14],
                            CmdEcho = telemetryList[15]
                    }
                };
                //string path = "C:\\Flight_1064_C.csv";
                handleContainerFile(path+ "\\Flight_1064_C.csv", records);
            }
            else if (telemetryList.Count == 7)
            {
                //string path;
                var records = new List<SciencePayload>
                {
                    new SciencePayload
                    {
                        TeamId = telemetryList[0],
                            MissionTime = telemetryList[1],
                            PacketCount = telemetryList[2],
                            PacketType = telemetryList[3],
                            TpAltitude = telemetryList[4],
                            TpTemperature = telemetryList[5],
                            TpVoltage = telemetryList[6],
                            GYRO_R = telemetryList[7],
                            GYRO_P = telemetryList[8],
                            GYRO_Y = telemetryList[9],
                            ACCEL_R = telemetryList[10],
                            ACCEL_P = telemetryList[11],
                            ACCEL_Y = telemetryList[12],
                            MAG_R = telemetryList[13],
                            MAG_P = telemetryList[14],
                            MAG_Y = telemetryList[15],
                            POINTING_ERROR = telemetryList[16],
                            TpSoftwareState = telemetryList[17]
                    }
                };
                String path2;
                path2 = "\\Flight_1064_T.csv" ;

                handlePayloadFile(path+path2, records);
            }
            #endregion//

        }

        public class Container
        {
            public string TeamId { get; set; }
            public string MissionTime { get; set; }
            public string PacketCount { get; set; }
            public string PacketType { get; set; }
            public string Mode { get; set; }
            public string TPReleased { get; set; }
            public string Altitude { get; set; }
            public string Temperature { get; set; }
            public string Voltage { get; set; }
            public string GpsTime { get; set; }
            public string GpsLatitude { get; set; }
            public string GpsLongitude { get; set; }
            public string GpsAltitude { get; set; }
            public string GpsSats { get; set; }
            public string SoftwareState { get; set; }
            public string CmdEcho { get; set; }

        }

        public class SciencePayload
        {
            public string TeamId { get; set; }
            public string MissionTime { get; set; }
            public string PacketCount { get; set; }
            public string PacketType { get; set; }
            public string TpAltitude { get; set; }
            public string TpTemperature { get; set; }
            public string TpVoltage { get; set; }
            public string GYRO_R { get; set; }
            public string GYRO_P { get; set; }
            public string GYRO_Y { get; set; }
            public string ACCEL_R{ get; set; }
            public string ACCEL_P{ get; set; }
            public string ACCEL_Y{ get; set; }
            public string MAG_R { get; set; }
            public string MAG_P { get; set; }
            public string MAG_Y { get; set; }
            public string POINTING_ERROR { get; set; }
            public string TpSoftwareState { get; set; }

        }

        private static void handleContainerFile(string path, List<Container> records)
        {
            if (!File.Exists(path))
            {
                var myFile = File.Create(path);
                
                myFile.Close();
            }
            var csvFileLenth = new FileInfo(path).Length;
            if (csvFileLenth == 0)
            {
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.NextRecord();
                    csv.WriteRecords(records);
                }
            }
            else
            {
                // Append to the file.
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    // Don't write the header again.
                    HasHeaderRecord = false,
                };
                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(records);
                }
            }
        }

        private static void handlePayloadFile(string path, List<SciencePayload> records)
        {
            if (!File.Exists(path))
            {
                var myFile = File.Create(path);
                myFile.Close();
            }
            var csvFileLenth = new FileInfo(path).Length;
            if (csvFileLenth == 0)
            {
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.NextRecord();
                    csv.WriteRecords(records);
                }
            }
            else
            {
                // Append to the file.
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    // Don't write the header again.
                    HasHeaderRecord = false,
                };
                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(records);
                }
            }
        }

        public string readExampleFile()
        {
            //var data = File.OpenRead(Server.MapPath("C:\\simp_cmd_example.txt"));
            //var FileAsString = data.ToString();
            //return FileAsString;
            var FileAsString = "";
            string path = "C:\\simp_cmd_example.txt";
            if (File.Exists(path))
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                    counter++;
                }

                file.Close();
                System.Diagnostics.Debug.WriteLine("There were {0} lines.", counter);
            }
            return FileAsString;
        }
    }
}