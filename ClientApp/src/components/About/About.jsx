import React from 'react'
import {useSelector} from 'react-redux'

const About = () => {

    const langPack = useSelector(state => state.LangPack) //useState(langFactory());    

    return (
        <>
            {langPack.Component_About.TITLE_DESCRIPTION}
        </>
    )
}

export default About;