var websocket = require('ws');

var websocketServer = new websocket.Server({port:25500}, ()=>{
    console.log("Mean server is Running")
})

var wsList = [];

websocketServer.on("connection", (ws,rq)=>{
    //Lobby
    {
        console.log('client connected.');
        //reception
        ws.on("message",(data))=>{
            console.log("send from client :" + data);
            if (data == "Create")
    }
    
   /* wsList.push(ws);
    
  
  
  
  
  
  
    ws.on("message",(data)=>{
        console.log("send from client :"+data);
        Boardcast(data);
    });
    
    ws.on("close",()=>{
        
        wsList = ArrayRemove(wsList,ws);        
        console.log("client disconnected.");
    });
});


function ArrayRemove(arr,value) {
    return arr.filter((element)=>{
        return element != value;
    })

}

function Boardcast(data) {
    for (var i = 0;i<wsList.length;i++)
    {
        wsList[i].send(data);
    }

}
