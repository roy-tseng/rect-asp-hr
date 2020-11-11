import {CounterActions} from '../actionDef/actionDef'

const CounterActionGenerator =  {

    Add : function (state){
        return {type : CounterActions.Add, payload: state };
    },

    Sub : function (state){
        return {type : CounterActions.Sub, payload: state };
    }
}

export default CounterActionGenerator;