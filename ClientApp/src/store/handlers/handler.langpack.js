import LanguagePack from "../states/state.langpack"
import {ChangeLanguagePackActions} from "../actionDef/actionDef"
import langFactory, {SupportedLang} from "../../uiSettings/langFactory"

const LangHandler = (state=LanguagePack.langPack, action) => {

    switch(action.type){
        case ChangeLanguagePackActions.TW:
            state = langFactory(SupportedLang.TW);
            break;
        case ChangeLanguagePackActions.US:
            state = langFactory(SupportedLang.US);
            console.log(state);
            break;
        default:
            //state = langFactory(SupportedLang.TW);
            break;
    }
   
    return state;
}

export default LangHandler