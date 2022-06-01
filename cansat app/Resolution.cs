using cansat_app;
using Cansat2021;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Prueba
using System.Threading;

using System.IO;
namespace cansat_app
{
    public partial class Resolution : Form
    {
        public static List<byte> buffer = new List<byte>();
        public static List<byte> bufferout = new List<byte>();
        public static List<string> telemetry = new List<string>();
        public static SerialPort _serialPort;
        public static string simfile;
        public static string export;
        public static int line;
        public static System.IO.StreamReader file ;
        public Resolution()
        {
            InitializeComponent();
            simfile = textBox3.Text;
            export = "C:/cansat 2022/csv/";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        
        static bool _continue;
        
        public  void init()
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;  
            serialPort1.PortName = SetPortName(Form1.portname );
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_OnReceiveData);
            }

            _continue = true;
           

         
        }

        private  void port_OnReceiveData(object sender,
                                  SerialDataReceivedEventArgs e)
        {
            //SerialPort sp = (SerialPort)sender;
            
            while (serialPort1.BytesToRead >1){
                var byteReaded = serialPort1.ReadByte();
                if (byteReaded == 0x7E)
                {
                    buffer.Clear();
                    telemetry.Clear();
                }
                buffer.Add((byte)byteReaded);

                if (buffer.Count >= 9)
                {
                    var buffer2 = buffer[2];
                    byte aux;
                    aux = (byte)(buffer[2] + 0x04);
                    if (aux == (byte)buffer.Count) //pregunta si ya tenemos toda la trama dentro de buffer
                    {
                        var message = "";
                        for (int i = 8; i < (buffer.Count - 1); i++)
                        {
                            message += (char)buffer[i];
                        }

                        // escribe el mensaje en el textbox1 para ser detectado por evento "textBox1_TextChanged"
                        SetText(message);
                        //Split message and send to CsvHelper class to create or append 
                        telemetry = message.Split(',').ToList();
                        Cansat2021.CsvHelper.writeCsvFromList(telemetry,export); //escribe los datos en un CSV file

                        
                        

                    }
                }

            }
        }

        public void fillForm(List<string> telemetry)
        {
            if (telemetry[3] == "C")
            {

                var Containerdata = new Container {
                    TeamId = telemetry[0],
                    MissionTime =telemetry[1],
                    PacketCount =telemetry[2],
                    PacketType =telemetry[3],
                    Mode =telemetry[4],
                    TPReleased =telemetry[5],
                    Altitude =telemetry[6],
                    Temperature =telemetry[7],
                    Voltage =telemetry[8],
                    GpsTime =telemetry[9],
                    GpsLatitude =telemetry[10],
                    GpsLongitude =telemetry[11],
                    GpsAltitude =telemetry[12],
                    GpsSats =telemetry[13],
                    SoftwareState =telemetry[14],
                    CmdEcho =telemetry[15]
                };

                PutData(Containerdata.PacketCount, Containerdata.MissionTime, Containerdata.GpsTime, Containerdata.GpsLatitude, Containerdata.GpsLongitude, Containerdata.GpsAltitude
                    , Containerdata.GpsSats, Containerdata.Voltage, Containerdata.Altitude, Containerdata.Temperature, Containerdata.TPReleased);
            }
            else
            {
                var PayloadData = 
                    new SciencePayload
                    {
                        TeamId = telemetry[0],
                        MissionTime = telemetry[1],
                        PacketCount = telemetry[2],
                        PacketType = telemetry[3],
                        TpAltitude = telemetry[4],
                        TpTemperature = telemetry[5],
                        TpVoltage = telemetry[6],
                        GYRO_R = telemetry[7],
                        GYRO_P = telemetry[8],
                        GYRO_Y = telemetry[9],
                        ACCEL_R = telemetry[10],
                        ACCEL_P = telemetry[11],
                        ACCEL_Y = telemetry[12],
                        MAG_R = telemetry[13],
                        MAG_P = telemetry[14],
                        MAG_Y = telemetry[15],
                        POINTING_ERROR = telemetry[16],
                        TpSoftwareState = telemetry[17]
                    };
                if(PayloadData.PacketType == "T")
                {
                    PutDataPayload1(PayloadData.TpAltitude, PayloadData.TpTemperature, PayloadData.POINTING_ERROR);
                }
                
            }
        }
        public static string SetPortName(string defaultPortName)
        {
            try
            {
                string portName = "";

                Console.WriteLine("Available Ports:");
                foreach (string s in SerialPort.GetPortNames())
                {
                    Console.WriteLine("   {0}", s);
                }

                Console.Write("COM port({0}): ", defaultPortName);
                //portName = Console.ReadLine();

                if (portName == "")
                {
                    portName = defaultPortName;
                }
                return portName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            init();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            file = new System.IO.StreamReader(this.textBox3.Text);
            var datatx = "CMD,1064,SIM,ACTIVATE";
            bufferout.Clear();
            bufferout.Add(0x7E);
            bufferout.Add(0x00);
            bufferout.Add((byte)(datatx.Length + 5));
            bufferout.Add(0x01);
            bufferout.Add(0x01);
            bufferout.Add(0x01); //0x01 
            bufferout.Add(0x11); //0x11
            bufferout.Add(0x00);

            for (int i = 0; i < datatx.Length; i++)
            {
                bufferout.Add((byte)datatx[i]);
            }
            byte chkaux = 0;
            for (int i = 3; i < datatx.Length + 8; i++)
            {
                chkaux += bufferout[i];
            }
            chkaux = (byte)(0xFF - chkaux);
            bufferout.Add(chkaux);




            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();

            }
            serialPort1.Write(bufferout.ToArray(), 0, bufferout.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var datatx = "CMD,1064,SIM,ENABLE";
            bufferout.Clear();
            bufferout.Add(0x7E);
            bufferout.Add(0x00);
            bufferout.Add((byte)(datatx.Length + 5));
            bufferout.Add(0x01);
            bufferout.Add(0x01);
            bufferout.Add(0x01); //0x01 
            bufferout.Add(0x11); //0x11
            bufferout.Add(0x00);

            for (int i = 0; i < datatx.Length; i++)
            {
                bufferout.Add((byte)datatx[i]);
            }
            byte chkaux = 0;
            for (int i = 3; i < datatx.Length + 8; i++)
            {
                chkaux += bufferout[i];
            }
            chkaux = (byte)(0xFF - chkaux);
            bufferout.Add(chkaux);




            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();

            }
            serialPort1.Write(bufferout.ToArray(), 0, bufferout.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            for(double i = 0; i < 1000; i++)
            {
                double n = i;
                String N = n.ToString();
                double m = i * 0.5;
                String M = m.ToString();
                PutData(N,M, N, M,N, M, N, M, N, "R","N");
                PutDataPayload1(N, M, N);
                Thread.Sleep(200);
            }
            
        }

        private void Resolution_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void missionTime_lbl_Click(object sender, EventArgs e)
        {

        }

        //FUNCION PUBLICA MANDAR DATOS A LABEL EN TIEMPO REALL
        public void PutData(string pc, string mt, string gpsT, string gpsLa, string gpsLo, string gpsA, string gpsS, string cV, string cA, string cT, string tpr)
        {
            packetCount_lbl.Text = pc;
            missionTime_lbl.Text = mt;
            gpsTime_lbl.Text = gpsT;
            gpsLatitude_lbl.Text = gpsLa;
            gpsLongitude_lbl.Text = gpsLo;
            gpsAltitude_lbl.Text = gpsA;
            gpsSats_lbl.Text = gpsS;
            voltage_lbl.Text = cV;
            cAltitude_lbl.Text = cA;
            cTemperature_lbl.Text = cT;
            if (tpr.Equals("R"))
            {
                P1green_img.Visible = true;
                P1red_img.Visible = false;

            }
            else
            {
                P1green_img.Visible = false;
                P1red_img.Visible = true;
            }
            
            Application.DoEvents();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var datatx = "CMD,1064,CX,ON";
                bufferout.Clear();
                bufferout.Add(0x7E);
                bufferout.Add(0x00);
                bufferout.Add((byte)(datatx.Length + 5));
                bufferout.Add(0x01);
                bufferout.Add(0x01);
                bufferout.Add(0x01); //0x01 
                bufferout.Add(0x11); //0x11
                bufferout.Add(0x00);

                for (int i = 0; i < datatx.Length; i++)
                {
                    bufferout.Add((byte)datatx[i]);
                }
                byte chkaux = 0;
                for (int i = 3; i < datatx.Length + 8; i++)
                {
                    chkaux += bufferout[i];
                }
                chkaux = (byte)(0xFF - chkaux);
                bufferout.Add(chkaux);




                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();

                }
                serialPort1.Write(bufferout.ToArray(), 0, bufferout.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }












        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = false,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = false,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog1.FileName;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Resolution.export = this.textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Resolution.simfile= this.textBox3.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            {
                string command;
                if ((command = file.ReadLine()) == null)
                {
                    file.Close();
                    timer1.Enabled = false;

                }else{

                      while (     (command.Contains("#") | command.Contains(" ") ) &      ((command = file.ReadLine()) != null)   )
                       {
                        command = file.ReadLine();
                        
                        }

                    command=command.Replace("$", "1064");
                    var datatx = command;
                    bufferout.Clear();
                    bufferout.Add(0x7E);
                    bufferout.Add(0x00);
                    bufferout.Add((byte)(datatx.Length + 5));
                    bufferout.Add(0x01);
                    bufferout.Add(0x01);
                    bufferout.Add(0x01); //0x01 
                    bufferout.Add(0x11); //0x11
                    bufferout.Add(0x00);

                    for (int i = 0; i < datatx.Length; i++)
                    {
                        bufferout.Add((byte)datatx[i]);
                    }
                    byte chkaux = 0;
                    for (int i = 3; i < datatx.Length + 8; i++)
                    {
                        chkaux += bufferout[i];
                    }
                    chkaux = (byte)(0xFF - chkaux);
                    bufferout.Add(chkaux);




                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();

                    }
                    if ( (command != "") | (command!= "### End of file ###")  )
                    {
                        textBox2.Text = command;
                        serialPort1.Write(bufferout.ToArray(), 0, bufferout.Count);
                    }
                    
                }




            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            file = new System.IO.StreamReader(this.textBox3.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fillForm(textBox1.Text.Split(',').ToList()); //muestra los datos en pantalla
            Mqtt.Publish(textBox1.Text); //envia los datos al Servidor MQTT
        }
            

        public void PutDataPayload1(string p1a,string p1t, string POINTING_ERROR)
        {
            P1A_lbl.Text = p1a;
            P1T_lbl.Text = p1t;
            P1RPM_lbl.Text = POINTING_ERROR;
        }


        private void groupBox9_Enter(object sender, EventArgs e)
        {
            
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
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
        public string ACCEL_R { get; set; }
        public string ACCEL_P { get; set; }
        public string ACCEL_Y { get; set; }
        public string MAG_R { get; set; }
        public string MAG_P { get; set; }
        public string MAG_Y { get; set; }
        public string POINTING_ERROR { get; set; }
        public string TpSoftwareState { get; set; }
    }
}
