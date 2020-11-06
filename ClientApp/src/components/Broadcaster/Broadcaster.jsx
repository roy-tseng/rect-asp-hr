import { useState } from "react";
import langFactory from "../../uiSettings/langFactory"

const Broadcaster = (props) => {

    let targetScope = "0.0.0.0";
    let langPack = langFactory();    
    const[message, setMessage] = useState('')
    
    function onChangeHandler (event) {
        setMessage(event.target.value);
    };
    
    return (
        <>
            <div>
                <input type="text" onChange={onChangeHandler} value={message}></input>
                <button>{langPack.Component_Broadcast.TITLE_SEND_BUTTON}</button>
                <button>{langPack.Component_Broadcast.TITLE_CLOSE_BUTTON}</button>
            </div>
        </>
    );

}

export default Broadcaster;