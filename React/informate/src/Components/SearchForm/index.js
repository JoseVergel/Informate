import React from 'react'
import {Form} from './style'

export const SearchForm =({search,setSearch,setSubmit})=>{

    const {city}=search
    

    const handleChange=e=>{
        setSearch({
            ...search,
            [e.target.name]:e.target.value
        })    
    }

    const handleSubmit=e=>{
        e.preventDefault();
        
        if(city.trim()===''){
            //setIsError(true)
            return
        }
        
        setSubmit(true)
        
    }
    return (
        <Form onSubmit={handleSubmit}>
            <div className="input-group">
                <input className='form-control' name='city' placeholder='Ingrese la ciudad' value={city} onChange={handleChange}></input>    
                <button className='btn btn-primary input-group-text' type='submit'>Buscar</button>                 
            </div> 
        </Form>
    )
}
