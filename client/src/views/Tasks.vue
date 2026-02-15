<script setup lang="ts">
import Taskform from '../components/Taskform.vue';
import usetaskstore from '../stores/taskstore';
import Taskcard from '../components/Taskcard.vue';
import { onMounted } from 'vue';
const taskstore=usetaskstore()

onMounted(()=>{
  taskstore.fetchtasks()
})

const handledelete=async(id:number)=>{
  await taskstore.deletetask(id)
}

const handleupdate=async(id:number,data:any)=>{
  await taskstore.updatetask(id,data)
}

const handleCreate = async (data:any) => {
  await taskstore.addtask(data)
}

</script>

<template>
  <div class="container  mt-4">
    <h2> Task Dashboard</h2>
    <Taskform @create="handleCreate" />

    <div class="row mt-4">
        <div v-for="task in taskstore.tasks" :key="task.id" class="col-12 mb-3">
          <Taskcard :task="task" @delete="handledelete" @update="handleupdate"/>
        </div>
        <div v-if="taskstore.tasks.length===0" class="text-center mt-4">
          <h2>No tasks yet! Please make some tasks to view them here!</h2>
        </div>
    </div>
  </div>
</template>

