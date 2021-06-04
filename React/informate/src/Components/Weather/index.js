
const Weather=({weatherData})=>{    

    if(!weatherData){
        return null
    }    
    var urlIcon=`http://openweathermap.org/img/wn/${weatherData.icon}@2x.png`    

    return (
        <div className="container" id="container-weather">
            <div className="card">
                <div className="card-header">                    
                    {weatherData.city}
                </div>
                <div className="card-body"> 
                    <h1 className="card-tittle">
                        <span id="temperature">
                            {weatherData.temperature}&deg;
                            <img src={urlIcon} alt=''></img>                                                     
                        </span>
                    </h1>   
                    <div className="card-text">
                    {weatherData.description}   
                    </div>               
                    <div className="temp-range">
                        <div className="temp_min">
                            <span>Mínima</span>
                            <span>{weatherData.minTemperature}&deg;</span>
                        </div>
                        <div className="temp_max">
                            <span>Máxima</span>
                            <span>{weatherData.maxTemperature}&deg;</span>
                        </div>
                    </div>   
                </div>
            </div>
        </div>
    )
}

export default Weather