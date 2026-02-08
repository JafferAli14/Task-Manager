import { defineStore } from "pinia";
import type { logindto, registrationdto, } from "../types/auth";
import { api } from "../services/api";

export const useauthstore=defineStore('auth',{

    state:()=> ({
        token:null as string|null,
        username:null as string|null,
        isauthenticated:false,
    }),


    actions:{

        async login(data:logindto){
            try{
                const res= await api.post("user/login",data)

                //we get the data from the backend thats token and the username
                const {token,username}=res.data


                this.token=token
                this.username=username
                this.isauthenticated=true

                //store it in the local storage

                localStorage.setItem('token',token)
            }
            catch(error){
                console.log("login failed,try again")
                throw error
            }

        },

        async register(data:registrationdto){
            try{
                await api.post("",data)
            }
            catch(error){
                console.log("an error occured during the registration process")
                throw error
            }
        },

        logout(){

            localStorage.removeItem('token')
            this.isauthenticated=false
            this.username=null
            this.token=null

        }
    }

})