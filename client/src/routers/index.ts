import { createRouter, createWebHistory } from "vue-router";
import { useauthstore } from "../stores/authpinia";
import Todos from "../components/Todos.vue";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";

const router=createRouter({
    history:createWebHistory(),

    routes:[
        {
        path:'/',
        redirect:'/login'
        },

        {
        path:'/login',
        name:'Login',
        component:Login
        },

        {
        path:'/register',
        name:'Register',
        component :Register,
        },

        {
        path: '/todos',
        name: 'Todos',
        component: Todos, 
        meta: { requiresAuth: true } 
        }

        
    ]
})

router.beforeEach((to)=>{
    const authstore=useauthstore()
    if(to.meta.requiresAuth && !authstore.isauthenticated){
        return "/login"
    }
    if((to.path==='/login'||to.path==='/register')  && authstore.isauthenticated){
        return "/todos"
    }
})

export default router;