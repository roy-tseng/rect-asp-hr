import React, {useState, useEffect} from 'react'
import {useSelector} from 'react-redux'
import langFactory from '../../uiSettings/langFactory'
import TextField from '@material-ui/core/TextField';

const Employee = () => {

    const [info, SetInfo] = useState(null);
    const [langPack, setLang]  = useState(useSelector(state => state.LangPack));

    useEffect(() =>{

        if(langPack === null){
            setLang(langFactory());
        }

    },[]);

    return(
        <>
           <TextField id="standard-required" label={langPack.Component_Employee.TITLE_NAME} defaultValue={langPack.Component_Employee.TITLE_NAME} />
        </>
    )
}

export default Employee;