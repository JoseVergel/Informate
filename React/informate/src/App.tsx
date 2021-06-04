import './App.css';
import {Header}      from './layout/Header'
import Main          from './layout/Main'
import Footer        from './layout/Footer'
import {useState,useEffect,useRef} from 'react'
import axios         from 'axios'

function App(){
  //Define cuando el usuario realiza la búsqueda
  const [submit,setSubmit]=useState(false)
  
  const [search,setSearch]=useState({
      city:''
  }) 
  const [weatherData,setWeatherData]= useState("")
  const [newsData,setNewsData] =useState({})  
  const [historyData,setHistoryData] = useState({}) 
  const {city}=search
  const divRef = useRef<HTMLDivElement>(null)

  useEffect(()=>{
    const setWeatherAndNews=()=>{         
       
        const url= `https://localhost:44316/api/Informate/${city}`
        axios.get(url).then(response=>{
          const {data}=response
          console.log(data)
          setWeatherData(data.weather)
          setNewsData(data.news)          
          setSubmit(false)          
          //Se hace scroll automático
          if(divRef.current !==null)
            divRef.current.scrollIntoView({ behavior: 'smooth' })

        }).catch(error=>{
            console.log(error)
        })
    }
    if(submit){
      setWeatherAndNews()    
    }

  },[submit,city])

  useEffect(()=>{
      const url= `https://localhost:44316/api/Historico`;
      axios.get(url).then(response=>{
        const {data}=response
        setHistoryData(data)
        console.log(data)  
      }).catch(error=>{
        console.log(error)
      })
  },[])

  return (
    <div>      
      <Header 
        search={search} 
        setSearch={setSearch}
        setSubmit={setSubmit}
      />
      <div ref={divRef} />
      <Main 
        newsData={newsData }
        weatherData={weatherData}
        historyData={historyData} 
      />
      <Footer />   
    </div>
  )
}

export default App
