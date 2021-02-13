using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
using ProgramChat;
using UnityEngine.UI;

namespace ChatWebSocketWithJson
{
    public class WebSocketConnection : MonoBehaviour
    {
        class MessageData
        {
            public string username;
            public string message;
        }

        struct SocketEvent
        {
            public string eventName;
            public string roomName; //data

            public SocketEvent(string eventName, string roomName)
            {
                this.eventName = eventName;
                this.roomName = roomName;
            }
        }
        public GameObject rootConnection;
        public GameObject rootMessenger;

        public InputField inputUsername;
        public InputField inputText;
        public Text sendText;
        public Text receiveText;
        
        private WebSocket ws;

        private string tempMessageString;

        public void Start()
        {
            rootConnection.SetActive(true);
            rootMessenger.SetActive(false);
        }

        public void Connect()
        {
            string url = $"ws://127.0.0.1:25500/";

            ws = new WebSocket(url);

            ws.OnMessage += OnMessage;

            ws.Connect();
            
            SocketEvent socketEvent = new SocketEvent("CreateRoom", "TestRoom01");

            string toJsonStr = JsonUtility.ToJson(socketEvent);
            
            ws.Send(toJsonStr);
            
            rootConnection.SetActive(false);
            rootMessenger.SetActive(true);
        }

        public void Disconnect()
        {
            if (ws != null)
                ws.Close();
        }
        
        public void SendMessage()
        {
            if (inputText.text == "" || ws.ReadyState != WebSocketState.Open)
                return;

            MessageData messageData = new MessageData();
            messageData.username = inputUsername.text;
            messageData.message = inputText.text;

            string toJsonStr = JsonUtility.ToJson(messageData);
            ws.Send(toJsonStr);
            inputText.text = "";
        }

        private void OnDestroy()
        {
            if (ws != null)
                ws.Close();
        }

        private void Update()
        {
            if (string.IsNullOrEmpty(tempMessageString)== false)
            {
                MessageData recieveMessageData = JsonUtility.FromJson<MessageData>(tempMessageString);

                if (recieveMessageData.username == inputUsername.text)
                {
                    sendText.text += recieveMessageData.username+":"+ recieveMessageData.message + "\n";
                    receiveText.text += "\n";
                }
                else
                {
                    sendText.text += "\n";
                    receiveText.text += recieveMessageData.username+":"+ recieveMessageData.message + "\n";
                }
                //receiveText.text += tempMessageString + "\n";
                tempMessageString = "";
            }
        }

        private void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            tempMessageString = messageEventArgs.Data;
        }
    }
}


