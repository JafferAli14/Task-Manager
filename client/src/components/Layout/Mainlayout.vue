<script setup lang="ts">
import Footer from './Footer.vue';
import Navbar from './Navbar.vue';


</script>

<template>
    <div class="d-flex flex-column min-vh-100">
        <Navbar/>
        <main class="container  mt-5 flex-grow-1">
            <!-- <slot /> -->
             <router-view />
        </main>

        <Footer/>
    </div>
</template>