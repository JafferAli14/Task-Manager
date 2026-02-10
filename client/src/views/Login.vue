<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useauthstore } from '../stores/authpinia';
import { ref } from 'vue';


const authstore=useauthstore()
const router=useRouter()

const username=ref('')
const password=ref('')
const error=ref('')

const handlelogin=async ()=>{
    try{
        error.value=""
        await authstore.login({
            username:username.value,
            password:password.value
        })
        router.push("/todos")
    }
    catch{
        error.value="invalid username or password"
    }

}
</script>

<template>
    <div class="comtainer mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="login">
                    <h3 class="text-center mt-5">Login</h3>
                    <form @submit.prevent="handlelogin">
                        <div class="usernameinput mt-3 mb-3">
                            <label class="form-label">Username</label>
                            <input type="text" class="form-control" placeholder="Enter username" v-model="username" required>
                        </div>
                        <div class="passwordinput">
                            <label class="form-label">Password</label>
                            <input type="password" class="form-control" placeholder="Enter password" v-model="password" required>
                        </div>

                        <button class="btn btn-primary w-100 mt-4" > Login </button>

                    </form>
                    <p v-if="error" class="mb-3"> 
                        {{ error }}
                    </p>

                    <p class="text-center mt-3">
                        Dont have an account? 
                        <router-link to="/register">Sign Up</router-link> 
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>


<!-- <template>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="login">
                  <h3 class="text-center mb-3 ">Login</h3>
                  <form @submit.prevent="handlelogin">
                  
                    <div class="mb-3">
                        <label for="form-label">Username</label>
                        <input type="text" class="form-control" placeholder="Enter Username" v-model="username" required>
                    </div>

                    <div class="mb-3">
                        <label for="form-label">Password</label>
                        <input type="password" class="form-control" placeholder="Enter Password" v-model="password" required>
                    </div>

                    <button class="btn btn-primary mt-4 w-100">Login</button>
                    <p v-if="error" class="text-danger text-center ">
                        {{ error }}
                    </p>
                    <p class="mt-4 text-center">Dont have an account?
                      <router-link to="/register" > Sign Up</router-link>
                    </p>
                  </form>
                </div>

            </div>
        </div>

    </div>

</template> -->
