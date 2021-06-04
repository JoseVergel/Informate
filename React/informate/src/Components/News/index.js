import { Fragment } from 'react'
import {A} from './style' 



const News =({newsData})=>{  

    const getNews=(news,i)=>{
    
        return (
            <div key={i}>            
                <div className="card mb-3" id="news">
                    <div className="row g-0">
                        <div className="col-md-4">
                            <img src={news.urlImg} alt="..." className='preview-img' />                       
                        </div>
                        <div className="col-md-8">
                            <div className="card-body">
                                <h5 className="card-title"><A href={news.urlNews} target='_blank' rel='noreferrer'>{news.title}</A></h5>
                                <p className="card-text">{news.description}</p>
                                <p className="card-text"><small className="text-muted">Publicada {news.publishedAt}</small></p>
                            </div>
                        </div>                    
                    </div> 
                </div>  
            </div>
        )
    }
    
    if(!newsData){        
        return null
    }
   
    return (
        <Fragment>       
                        
            {
                Array.isArray(newsData)?
                <h2>Ultimas noticias</h2>:''
            }
            {   
                Array.isArray(newsData)?
                newsData.map((news,i)=>{                    
                    return getNews(news,i)
                })
                :''
            }
        </Fragment>
        
    )
}

export default News