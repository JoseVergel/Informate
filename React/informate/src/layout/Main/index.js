import Weather       from '../../Components/Weather'
import News          from '../../Components/News'
import SearchHistory from '../../Components/SearchHistory'

const Main= ({newsData,weatherData,historyData})=>{

    return (
        <div className="container-fluid">
            <div className="row">
                <div className="col-9">
                <News newsData={newsData}/>
                </div>
                <div className="col-3"> 
                <Weather        
                    weatherData={weatherData}
                /> 
                <SearchHistory historyData={historyData}/>
                </div>   
            </div>        
        </div>
    )
}

export default Main

