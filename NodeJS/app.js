const app = require('express')();
const server = require('http').Server(app);
const webSocket = require('ws');

const wss = new webSocket.Server({server});

var wsList = [];
var roomList = [];

/*{ roomName: "" }*/

wss.on("connection"), (ws)=>{
    
    {
        console.log("client connected.");
        
        ws.on("message" , (data)=>{
            console.log("send from client : " + data);
            var toJsonObj = JSON,parse(data);
            
            if (toJsonObj.eventName=="CreateRoom")
            {
                console.log("Client request CreateRoom ["+newRoom.roomName+"]")
                var isFoundRoom = false;
                
                for (var i = 0; i < roomList.length;i++)
                {
                    if (roomList[i].roomName == toJsonObj.roomName)
                    {
                        isFoundRoom = true;
                        break;
                    }
                }
                
                if (isFoundRoom == true)
                {
                    ws.send("CreateRoomFail")
                }
                else 
                {
                    var newRoom = {
                        roomName: toJsonObj.roomName,
                        wsList[]
                    }
                    newRoom.wsList.push(ws);
                    
                    roomList.push(newRoom);
                    
                    ws.send("CreateRoomSuccess");
                    
                    console.log(client create room success.);
                    
                }
                console.log("Client request CreatRoom["+toJsonObj.roomName+"]");
                
            }
            else  if (toJsonObj.eventName == "JoinRoom") //joinRoom
            {
                console.log("client request JoinRoom");
            }
            else if (toJsonObj.eventName == "LeaveRoom")
            {
                var isFoundClientInRoom = false;
                for(var i = 0; i < roomList.length;i++)
                {
                    for (var j = 0; j < roomList[i].wsList[j]; j++)
                    {
                        if(ws = roomList[i].wsList[j])
                        {
                            roomList[i].wsList
                            isFoundClientInRoom = true;
                            break;
                        }
                    }
                }
            }
            
        });
    }
    
    ws.on("close",()=>{
        console.log("client disconnected.");
        
        for (var i = 0 ; i < roomList.length ; i++)
        {
            for (var j = 0 ; j < roomList[i].wsList.length ; j++)
            {
                if(ws == roomList[i].wsList[j])
                {
                    roomList[i].wsList.split(j,1);
                    break;
                }
            }
                
        }
    });
    
});
server.listener(process.env.PORT || 8080, ()=>{
    console.log("Server start at port" + server.sddress().port);
});
function Boardcast(data) 
{
    for (var i = 0; i < wsList.length; i++)
    {
        wsList[i].send(data);
    }
}