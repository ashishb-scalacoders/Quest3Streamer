using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using FMSocketIO;
// using SocketIOClient;
// using SocketIOClient.Newtonsoft.Json;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    // public SocketIOUnity socket;

    // public InputField EventNameTxt;
    // public InputField DataTxt;
    // public Text ReceivedText;

    // public GameObject objectToSpin;


    // // Start is called before the first frame update
    // async void Start()
    // { //TODO: check the Uri if Valid.
    //     var uri = new Uri("http://192.168.1.2:5454");
    //     // socket = new SocketIOUnity(uri, new SocketIOOptions
    //     socket = new SocketIOUnity("http://192.168.1.2:5454");/* , new SocketIOOptions
    //     {
    //         Query = new Dictionary<string, string>
    //             {
    //                 {"token", "UNITY" }
    //             }
    //         ,
    //         EIO = 4
    //         ,
    //         Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
    //     }); */
    //     socket.JsonSerializer = new NewtonsoftJsonSerializer();

    //     ///// reserved socketio events
    //     socket.OnConnected += (sender, e) =>
    //     {
    //         print("socket.OnConnected");
    //         socket.On("client_event", (response) =>
    //         {
    //             /* Do Something with data! */
    //             print("RD ");
    //             print(response.GetValue<string>());

    //         });

    //     };


    //     socket.OnPing += (sender, e) =>
    //     {
    //         print("Ping");
    //     };
    //     socket.OnPong += (sender, e) =>
    //     {
    //         print("Pong: " + e.TotalMilliseconds);
    //     };
    //     socket.OnDisconnected += (sender, e) =>
    //     {
    //         print("disconnect: " + e);
    //     };
    //     socket.OnReconnectAttempt += (sender, e) =>
    //     {
    //         print($"{DateTime.Now} Reconnecting: attempt = {e}");
    //     };
    //     ////

    //     // print("Connecting...");
    //     // socket.Connect();

    //     // socket.OnUnityThread("spin", (data) =>
    //     // {
    //     //     rotateAngle = 0;
    //     // });

    //     // ReceivedText.text = "";
    //     // socket.OnAnyInUnityThread((name, response) =>
    //     // {
    //     //     ReceivedText.text += "Received On " + name + " : " + response.GetValue<string>() + "\n";
    //     // });

    //     socket.On("client_event", (sender) =>
    //     {
    //         // image_uploaded
    //         print("received");
    //         print(sender.ToString());
    //     });
    //     socket.On("image_uploaded", (sender) =>
    //             {
    //                 // image_uploaded
    //                 print("received image_uploaded");
    //                 print(sender.ToString());
    //             });

    //     socket.OnAnyInUnityThread((name, response) =>
    //    {
    //        print("received in thread");
    //        print("Received On " + name + " : " + response.ToString() + "\n");
    //    });
    //     //     socket.OnAnyInUnityThread((name, response) =>
    //     //  {
    //     //      print("received in thread");
    //     //      print("Received On " + name + " : " + response.ToString() + "\n");
    //     //  });

    //     print("Connecting...");
    //     socket.Connect();
    // }
    // float rotateAngle = 45;
    // readonly float MaxRotateAngle = 45;
    // void Update()
    // {
    //     if (rotateAngle < MaxRotateAngle)
    //     {
    //         rotateAngle++;
    //         objectToSpin.transform.Rotate(0, 1, 0);
    //     }
    // }

    // public void EmitSpin()
    // {
    //     socket.Emit("client_event");
    // }


    // // Update is called once per frame
    // [ContextMenu("Send.")]
    // public void Send()
    // {
    //     socket.EmitAsync("client_event", "socketId 00 7");

    // }
    /* 
        public SocketIOComponent socketIO;
        [ContextMenu("Send.")]
        void Send()
        {
            // socketIO.Connect();
            socketIO.Emit("client_event", "By UNITy");
            socketIO.On("client_event", OnReceiveData);
        }

        void OnReceiveData(SocketIOEvent eventData)
        {
            print("Received");
            print(eventData.name);
            print(eventData.data);
        } */
}
