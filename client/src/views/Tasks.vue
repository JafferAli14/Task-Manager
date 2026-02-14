<script setup lang="ts">
import { onMounted } from 'vue'
import Taskform from '../components/Taskform.vue';
import usetaskstore from '../stores/taskstore';
const taskstore=usetaskstore()

onMounted(()=>{
  taskstore.fetchtasks()
})


const handleCreate = async (data:any) => {
  await taskstore.addtask(data)
}

// const handlefetch=async()=>{
//   await taskstore.fetchtasks()
// }

</script>

<template>
  <div class="container mt-4">
    <h2> Task Card</h2>
    <Taskform @create="handleCreate" />
  </div>
</template>

