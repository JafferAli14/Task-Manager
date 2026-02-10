<template>
  <div class="container mt-5">
    <div class="d-flex justify-content-between align-items-center mb-4">
      <h2>My Todo List</h2>
      <button @click="handleLogout" class="btn btn-outline-danger btn-sm">
        Logout
      </button>
    </div>

    <div class="input-group mb-3">
      <input 
        v-model="newTodo" 
        type="text" 
        class="form-control" 
        placeholder="Add a new task..."
        @keyup.enter="addTodo"
      />
      <button @click="addTodo" class="btn btn-success">Add</button>
    </div>

    <ul class="list-group">
      <li 
        v-for="(todo, index) in todos" 
        :key="index" 
        class="list-group-item d-flex justify-content-between align-items-center"
      >
        {{ todo }}
        <button @click="removeTodo(index)" class="btn btn-sm btn-link text-danger">
          Delete
        </button>
      </li>
      <li v-if="todos.length === 0" class="list-group-item text-center text-muted">
        No tasks yet. Add one above!
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
// import { useAuthStore } from '../stores/authpinia'
import { useRouter } from 'vue-router'

// const authStore = useAuthStore()
const router = useRouter()

const newTodo = ref('')
const todos = ref<string[]>(['Learn Vue 3', 'Setup Pinia', 'Connect Router'])

const addTodo = () => {
  if (newTodo.value.trim()) {
    todos.value.push(newTodo.value)
    newTodo.value = ''
  }
}

const removeTodo = (index: number) => {
  todos.value.splice(index, 1)
}

const handleLogout = () => {
//   authStore.logout() // Assuming you have a logout action
  router.push('/login')
}
</script>