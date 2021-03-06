using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace cansat_app
{
    public static class Mqtt
    {
        public static string[] _topic = { "teams/1064" };
        public static MqttClient client = new MqttClient("cansat.info");
        public static void conect()
        {

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += client_MqttMsgUnsubscribed;

            client.Connect(Guid.NewGuid().ToString(), "1064", "Tailfaji110");
            Subscribe(client);

            var isConnected = client.IsConnected;
        }

        public static void Subscribe(MqttClient client)
        {

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
            var susbs = client.Subscribe(_topic, qosLevels);

        }

        public static void Publish(string mensaje)
        {
            
            if (!client.IsConnected)
            {
                conect();
                
            }
            client.Publish(_topic[0], Encoding.UTF8.GetBytes(mensaje));
;
        }

        static void client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        static void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        static void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            Console.WriteLine("Mensaje Publicado = " + e.IsPublished);
        }
    }
}
