import React, {useState, useEffect} from 'react'
import {useSelector} from 'react-redux'
import langFactory from '../../uiSettings/langFactory'
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import { makeStyles } from '@material-ui/core/styles';
import axios from "axios";

const useStyles = makeStyles((theme) => ({
    button: {
      margin: theme.spacing(1),
    },
  }));

const Employee = () => {

    const classes              = useStyles();
    const [name, setName]      = useState('');
    const [info, SetInfo]      = useState(null);
    const [langPack, setLang]  = useState(useSelector(state => state.LangPack));

    useEffect(() =>{

        if(langPack === null){
            setLang(langFactory());
        }

    },[]);

    const handleTextField = (e) => {
        setName(e.target.value);
    }

    const executeCommands = async () => {
    
        try 
        {
            await axios.post("/EmployeeMgmt/Add", {name})
            .then(res => {
              console.log(res);
              console.log(res.data);
            })
        } 
        catch (error) 
        {
           console.log(error);
        }  
    }

    return(
        <>
           <TextField onChange={handleTextField} id="standard-required" label={langPack.Component_Employee.TITLE_NAME} defaultValue={langPack.Component_Employee.TITLE_NAME} />
           <br/> <Button
                    onClick={executeCommands}
                    variant="contained"
                    color="primary"
                    className={classes.button}
                >
                    {langPack.Component_Employee.TITLE_BUTTON_UPDATE}
                </Button>
        </>
    )
}

export default Employee;