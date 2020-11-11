import React, {useState} from 'react'
import axios from "axios";
import { Button } from '@material-ui/core';
import { useDispatch, useSelector } from 'react-redux'

const Login = (props) => {

    const dispatch = useDispatch();
    const langPack = useSelector(state => state.LangPack) //useState(langFactory()); 

    async function isLegalUser(){
        try 
        {
            //取得數據庫http://localhost:3003/posts的數據
            const Data = await axios.get("/WeatherForecast"); 
            console.log(Data.data);
        } 
        catch (error) 
        {
            alert("GET Error!!");    
        }  
    }

    return(
        <>
            <Button size="small" variant="contained" color="primary" onClick={isLegalUser}>{langPack.Component_Login.TITLE_Login_BUTTON}</Button>         
        </>
    )
}

export default Login;