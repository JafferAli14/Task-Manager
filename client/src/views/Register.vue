<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useauthstore } from '../stores/authpinia';
import { ref } from 'vue';


const authstore=useauthstore()
const router=useRouter()

const username=ref('')
const password=ref('')
const error=ref('')

const handleregister= async()=>{
    try{
        await authstore.register({
            username:username.value,
            password:password.value
        })

        router.push('/login')
    }
    catch{
        error.value="Registration failed please try again"
    }
}

</script>


<template>
    <div class="comtainer mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="register">
                    <h3 class="text-center mt-5">Sign In</h3>
                    <form @submit.prevent="handleregister">
                        <div class="usernameinput mt-3 mb-3">
                            <label class="form-label">Username</label>
                            <input type="text" class="form-control" placeholder="Enter username" v-model="username" required>
                        </div>
                        <div class="passwordinput">
                            <label class="form-label">Password</label>
                            <input type="password" class="form-control" placeholder="Enter password" v-model="password" required>
                        </div>

                        <button class="btn btn-primary w-100 mt-4" > Sign Up </button>

                    </form>
                    <p v-if="error" class="mb-3"> 
                        {{ error }}
                    </p>

                    <p class="text-center mt-3">
                        Already Have an Account? 
                        <router-link to="/login">Login</router-link> 
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>