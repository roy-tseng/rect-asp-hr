import CounterHandler from "../handlers/handler.counter"
import LangHandler from "../handlers/handler.langpack"
import { combineReducers } from 'redux'

const Reducers = {
    Counter : CounterHandler,
    LangPack: LangHandler
}

const HandlerDoc = combineReducers(
    Reducers
)

export default HandlerDoc;