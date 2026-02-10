<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useauthstore } from '../../stores/authpinia';

const authstore=useauthstore()
const router=useRouter()

const handlelogout=()=>{
    authstore.logout()
    router.push('/login')
}

</script>

<template>
    <div class="navbar bg-dark px-4 navbar-dark navbar-expand-lg">
        <a class="navbar-brand" href="#">Task Manager</a>
        <div class="d-flex ms-auto gap-3 align-items-center">
            <!-- if user is not authenticated then: -->
             <template v-if="!authstore.isauthenticated">
                <router-link class="btn btn-outline-light" to="/login">
                    Login
                </router-link>
                <router-link class="btn btn-outline-light" to="/register">
                    Sign Up
                </router-link>
             </template>

             <!-- // if the user is authenticated then: -->
             <template v-else>
                <span class="text-white me-3">
                    Hi, {{ authstore.username }}
                </span>

                <button class="btn btn-danger" @click="handlelogout">
                    Logout
                </button>
             </template>
        </div>
    </div>
</template>