
const SearchHistory = ({historyData})=>{


    return (
        <div className="container" id="container-weather">
            <div className="card">
                <div className="card-header">                    
                    <h3>Búsquedas recientes</h3>
                </div>
                <div className="card-body">                                  
                    <ul className="list-group list-group-flush">
                        {
                            Array.isArray(historyData)?
                            historyData.map((history,i)=>{
                               return (
                                <li key={history.idHistorico} className="list-group-item">
                                    {history.ciudad} <span>{history.temperatura}&deg;</span>
                                </li>
                               )
                           }): '' 
                        }                                                  
                    </ul> 
                </div>
            </div>
        </div>
    )
}
export default SearchHistory