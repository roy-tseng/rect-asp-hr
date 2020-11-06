import {ChangeLanguagePackActions} from "../actionDef/actionDef"

const ChangeLanguagePackActionsMaker = {

    TW : function (data) {
        return {type : ChangeLanguagePackActions.TW, payload: data};
    },

    US : function (data) {
        return {type : ChangeLanguagePackActions.US, payload: data};
    }
}

export default ChangeLanguagePackActionsMaker
