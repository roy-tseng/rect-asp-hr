import  { useEffect, useState } from 'react'
import webSocket from 'socket.io-client'

const WebSocketClient = ({Protocol, Address, Port, children}) => {

    const [webSocket, setSocket] = useState(null);
    const [protocol, setProtocol] =  useState(Protocol);
    const [port, setPort] = useState(Port);
    const [address, setAddress] = useState(Address);


    function openSocket() {
        let ws_address = protocol + "://" + address + ":" + port;
        console.log(ws_address)
        setSocket(webSocket(ws_address));
    }

    useEffect(
        
        ()=>{
            openSocket()
        },[]
    )

    return (        
        <>
            {children}
        </>
    );    
}

export default WebSocketClient