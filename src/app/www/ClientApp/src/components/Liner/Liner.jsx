import React, {useState, useEffect} from 'react'
import {useSelector} from 'react-redux'
import langFactory from "../../uiSettings/langFactory"
import TextField from '@material-ui/core/TextField';
import axios from 'axios'
import Button from '@material-ui/core/Button';
import * as LineAPI  from 'line-api'

/**
 *  curl -H "Authorization: Bearer {token}" -d "message={data} " https://notify-api.line.me/api/notify
 */


const Liner = () => {

    const [message, setMessage] = useState('');
    const [langPack, setLang] = useState(useSelector(state => state.LangPack));
    const [key, setKey] = useState("");
    const [notify, setNotify] = useState(null);

    useEffect(() =>{

        if(langPack === null){
            setLang(langFactory());
        }

        if(notify === null) {
          setNotify(new LineAPI.Notify({token: key}));
        }

    },[]);

    function handleTextFieldChange(e){
        setMessage(e.target.value);
    }

    function makeLineNotifyMessage(message, token){
        
        /**
        return {
            method: 'post',
            url: 'https://notify-api.line.me/api/notify',
            headers: {
              'Authorization': 'Bearer ' + 'YOUR_ACCESS_TOKEN',
              'Content-Type': 'application/x-www-form-urlencoded',
              'Access-Control-Allow-Origin': '*'
            },
            data: querystring.stringify({
              message: {'something you would like to push'},
            })
        };
        */
    }


    function postData(url, token) {
        // Default options are marked with *
        return fetch("https://notify-api.line.me/api/notify", {
            body: {'message':'測試一下！'}, // must match 'Content-Type' header
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            credentials: 'same-origin', // include, same-origin, *omit
            headers: {
                "Authorization": "Bearer " + token,
                "Content-Type": "application/x-www-form-urlencoded",
            },
            method: 'POST', // *GET, POST, PUT, DELETE, etc.
            mode: 'cors', // no-cors, cors, *same-origin
            redirect: 'follow', // manual, *follow, error
            referrer: 'no-referrer', // *client, no-referrer
        })
        .then(response => response.json()) // 輸出成 json
    }

    function sendMessage(content) {

        try 
        {
            let formData = new FormData()
            formData.append('message', content)
            axios.post("LineService/SendTextNotify", formData ,{
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            })
            .then( function(res) {
              console.log(res.data);
            })
            .catch( function(err) {
              console.error(err);
            });
        } 
        catch (error) 
        {
           console.log(error);
        }  
    }

    return (
        <>
          <TextField onChange={handleTextFieldChange} id="standard-required" label={langPack.Component_Liner.TITLE_MESSAGE} defaultValue={langPack.Component_Liner.TITLE_MESSAGE} />
           <br/> <Button
                onClick={() => sendMessage(message) }
                    variant="contained"
                    color="primary"
                >
                    {langPack.Component_Liner.TITLE_BUTTON_SEND}
                </Button>
        </>
    );
}

export default Liner;