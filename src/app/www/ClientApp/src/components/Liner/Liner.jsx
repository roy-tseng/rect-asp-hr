import React, {useState, useEffect} from 'react'
import {useSelector} from 'react-redux'
import langFactory from "../../uiSettings/langFactory"
import TextField from '@material-ui/core/TextField';
import axios from 'axios'
import Button from '@material-ui/core/Button';

/**
 *  curl -H "Authorization: Bearer {token}" -d "message={data} " https://notify-api.line.me/api/notify
 */

const Liner = () => {

    const [message, setMessage] = useState('');
    const [langPack, setLang] = useState(useSelector(state => state.LangPack));
    
    useEffect(() =>{

        if(langPack === null){
            setLang(langFactory());
        }

    },[]);

    function handleTextFieldChange(e){
        setMessage(e.target.value);
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
          <TextField onChange={handleTextFieldChange} id="standard-required" label={langPack.Component_Liner.TITLE_MESSAGE} defaultValue="" />
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