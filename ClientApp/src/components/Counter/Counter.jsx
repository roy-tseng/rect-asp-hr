import { useDispatch, useSelector } from 'react-redux'
import CounterActionGenerator from "../../store/actions/action.counter"
import ChangeLanguagePackActionsMaker from "../../store/actions/action.langpack"
import {SupportedLang} from "../../uiSettings/langFactory"
import { Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles({
    root: {
      minWidth: 275,
    },
    bullet: {
      display: 'inline-block',
      margin: '0 2px',
      transform: 'scale(0.8)',
    },
    title: {
      fontSize: 14,
    },
    pos: {
      marginBottom: 12,
    },
  });



const Counter = () => {

    const classes = useStyles();
    const dispatch = useDispatch();
    const langPack = useSelector(state => state.LangPack) //useState(langFactory());    
    
    // throght reducer list to get needed state, Counter is reducer name
    //const counter = useSelector(state => state.Counter.value);
    
    const counter = useSelector(state => {
        console.log('State: ', state);
        return state.Counter.value;
      }); // throght reducer list to get needed state, Counter is reducer name
    
    function changeLang(option){

        if(option === SupportedLang.US){
            dispatch(ChangeLanguagePackActionsMaker.US(langPack));
        }
        else {
            dispatch(ChangeLanguagePackActionsMaker.TW(langPack));
        }
    }

    return (
            <>
            <Card className={classes.root} variant="outlined">
                <CardContent>
                    <Typography className={classes.title} color="textSecondary" gutterBottom>
                        <a href="javascript:void(0)"  onClick={() => changeLang(SupportedLang.US)}> {SupportedLang.US}</a> /
                        <a href="javascript:void(0)"  onClick={() => changeLang(SupportedLang.TW)}>{SupportedLang.TW}</a><br/>
                    </Typography>
                    <Typography variant="h5" component="h2">
                        <span>Counter: {counter} </span>
                    </Typography>
                </CardContent>
                <CardActions>
                    <Button size="small" variant="contained" color="primary" onClick={() => dispatch(CounterActionGenerator.Add(counter))}>{langPack.Component_Counter.TITLE_Add_BUTTON}</Button>         
                    <Button size="small" variant="contained" color="primary" onClick={() => dispatch(CounterActionGenerator.Sub(counter))}>{langPack.Component_Counter.TITLE_Sub_BUTTON}</Button>         
                </CardActions>
            </Card>
            </>
        )
}

export default Counter