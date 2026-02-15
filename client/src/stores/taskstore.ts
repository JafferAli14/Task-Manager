// import axios from "axios";
import { defineStore } from "pinia";
import { useauthstore } from "./authpinia";
import api from "../services/api";
import type { taskdata } from "../types/tasks";

// cosnt authstore=useauthstore();

const usetaskstore=defineStore('tasks',{
    state:()=>({
        tasks:[] as taskdata[]
    }),

    actions:{
        async fetchtasks(){
            const authstore=useauthstore()
            try{
            const res = await api.get<taskdata[]>("/api/todo",{
                headers:{
                Authorization:`Bearer ${authstore.token}`
                }
            })
            this.tasks=res.data
        }
        catch(error){
            console.log(error)
        }
            
        },

        async addtask(data:Omit<taskdata, "id" | "userId">) {
            const authstore=useauthstore()
            try{
            const res=await api.post<taskdata>("/api/todo/",data,{
                headers:{
                    Authorization:`Bearer ${authstore.token}`
                }
            })
            this.tasks.push(res.data)
            }
            catch(error){
                console.log(error )
            }
        },

        async updatetask(id:number, data: Partial<taskdata>){
            const authstore=useauthstore()
            try{
              const res = await api.put<taskdata>(`/api/todo/${id}`, data , {
                    headers:{
                        Authorization:`Bearer ${authstore.token}`
                    }
                })
                
            const index=this.tasks.findIndex(t=>t.id===id)
            if( index!==-1){
                this.tasks[index]=res.data
            }
            }
            catch(error){
                console.log(error)
            }
        },

    async deletetask(id:number,){
        const authstore=useauthstore()
        try{
        await api.delete(`/api/todo/${id}`,{
            headers:{
                Authorization:`Bearer ${authstore.token}`
            }
        })
        this.tasks=this.tasks.filter(t=> t.id!==id)
    }
    catch(error){
        console.log(error)
    }
    }
}
});

export default usetaskstore;