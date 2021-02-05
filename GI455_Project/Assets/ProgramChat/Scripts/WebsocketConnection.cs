using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Random = UnityEngine.Random;

namespace ProgramChat
{
    public class WebsocketConnection : MonoBehaviour
    {

        private WebSocket websocket;
        //login panel
        public InputField userName;
        public InputField port;
        public InputField ip;

        public GameObject chatPanel;
        public GameObject loginPanel;
        //chat panel
        public TextMeshProUGUI chatBoxText;
        public InputField inputMsg;

        private string username;

        public void Login()
        {   websocket = new WebSocket("ws://127.0.0.1:25500/");
            websocket.OnMessage += OnMessage;
            websocket.Connect();
            chatPanel.SetActive(false);
            loginPanel.SetActive(true);
            username = userName.text;
            if (websocket.ReadyState == WebSocketState.Open)
            {
                chatPanel.SetActive(true);
                loginPanel.SetActive(false);
            }
            
        }

        public void SendMsg()
        {
            var msg = new Message(username,inputMsg.text);
            var json = JsonUtility.ToJson(msg);
            websocket.Send(json);
            inputMsg.text = "";
        }


        void Update()
        {
           // if (Input.GetButtonDown())
          //  {
           //     websocket.Send("" + );
          //  }
        }

        public void OnDestroy()
        {
            if (websocket != null)
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            var data = JsonUtility.FromJson<Message>(messageEventArgs.Data);
            if (data.UserId == username)
            {
                Debug.Log("Same username");
                chatBoxText.text += "\n<align=right>" + data.Msg;
            }
            else
            {
                Debug.Log("different username");
                chatBoxText.text += "\n<align=left>" + data.Msg;
            }
            Debug.Log("Message from server :" + data.Msg);
        }
    }

    internal class Message
    {
        public string UserId;
        public string Msg;

        public Message(string id, string message)
        {
            UserId = id;
            Msg = message;
        }
    }
}

