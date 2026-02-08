import axios from "axios";

export const api=axios.create(
    {
    baseURL:"http://localhost:5261",
    headers:{
        "Content-Type":"application/json",
    },

})

//we check if theres a jwt token present 
api.interceptors.request.use( config=>{
    const token=localStorage.getItem('token')
    if(token&&config.headers){
        config.headers.Authorization=`Bearer ${token}`
    }
    return config
})