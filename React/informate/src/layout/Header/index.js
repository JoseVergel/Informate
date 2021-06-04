import React,{useState,useEffect,useRef} from 'react'
import {SearchForm} from '../../Components/SearchForm'
import Clouds from 'vanta/dist/vanta.clouds.min'
import * as THREE  from 'three'
import {Container} from './style'
//import {Container} from '@material-ui/core'

export const Header = (props)=>{
    
  const [vanta,setVanta]=useState(0)
  const refHeader = useRef(null)
  
  useEffect(()=>{
    if(!vanta){
      setVanta(
        Clouds({
            THREE,
            el:refHeader.current
          })
      )

      
    }  
  },[vanta])

    return (
        <Container ref={refHeader}>
            <h1>El clima</h1>
            <SearchForm {...props} />
        </Container>
    )
}