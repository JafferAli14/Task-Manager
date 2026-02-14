<script setup lang="ts">
import { onMounted } from 'vue'
import usetaskstore from '../stores/taskstore'

const taskStore = usetaskstore()

onMounted(() => {
  taskStore.fetchtasks()
})
</script>

<template>
  <div>
    <h1>Todo Page</h1>

    <p v-if="taskStore.tasks.length === 0">
      No tasks found.
    </p>

    <div v-for="task in taskStore.tasks" :key="task.id">
      <h3>{{ task.title }}</h3>
      <p>{{ task.description }}</p>
    </div>
  </div>
</template>

