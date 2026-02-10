import { defineStore } from "pinia";
import type { authresponse, logindto, registrationdto, } from "../types/auth";
import api from "../services/api";



export const useauthstore=defineStore('auth',{

    state:()=> ({
        token:localStorage.getItem('token') as string|null,
        username:localStorage.getItem('username') as string|null,
        isauthenticated:!!localStorage.getItem('token'),
    }),


    actions:{

        async login(data:logindto){
            try{
                const res= await api.post<authresponse>("/api/Auth/login",data)
                console.log("LOGIN RESPONSE:", res.data)

                //we get the data from the backend thats token and the username
                const {token,username}=res.data


                this.token=token
                this.username=username
                this.isauthenticated=true

                //store it in the local storage

                localStorage.setItem('token',res.data.token)
                localStorage.setItem('username',res.data.username)

            }
            catch(error){
                console.log("login failed,try again")
                throw error
            }

        },

async register(data: registrationdto) {
  try {
    const res = await api.post("/api/Auth/register", data)
    console.log("Registered successfully", res.data)
  } catch (error) {
    console.log("Registration failed", error)
    throw error
  }
},


        logout(){

            localStorage.removeItem('token')
            localStorage.removeItem('username')

            this.isauthenticated=false
            this.username=null
            this.token=null

        }
    }

})