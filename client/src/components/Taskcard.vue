<script setup lang="ts">
// import usetaskstore from '../stores/taskstore'
import { ref } from 'vue';
import type { taskdata } from '../types/tasks'

// const taskstore = usetaskstore()
const emit=defineEmits(["delete","update"])

const props=defineProps<{
  task:taskdata
}>()

//variable used to keep a track if we are editing or not
const isediting=ref(false)

//local copy to edit the task
const editabletask=ref({...props.task})

const saveupdate=()=>{
  emit('update',props.task.id,editabletask.value)
  isediting.value=false
}


</script>


<template>
  <div class="container mt-4">
    <div class="card shadow-sm h-100">
      <div class="card-body">
        <div v-if="isediting">
          <label class="form-label fw-bold">Title</label>
          <input v-model="editabletask.title" class="form-control mb-3 fs-3" />

          <label class="form-label fw-bold">Description</label>
          <textarea v-model="editabletask.description" class="form-control mb-3" rows="3"></textarea>
          <!-- <label class="form-label fw-bold">Priority</label>
          <select v-model="editabletask.priority" class="form-select mb-3">
            <option :value="1">1 (High)</option>
            <option :value="2">2 (Medium)</option>
            <option :value="3">3 (Low)</option>
          </select>

            <label class="form-label fw-bold">Due Date</label>
            <input type="date" v-model="editabletask.duedate" class="form-control mb-3" /> -->

          <div class="d-flex justify-content-end gap-2">
            <button class="btn btn-success" @click="saveupdate">SAVE</button>
            <button class="btn btn-outline-secondary" @click="isediting = false">CANCEL</button>
          </div>
        </div>
        <div v-else>
          <h5 class="d-flex justify-content-center card-title fw-bold fs-1">{{ task.title }}</h5>
          <p class="fw-bold fs-3">Description:</p>
          <p class="task-description card-text fs-4 ">{{ task.description }}</p>
          <div class="d-flex flex-column align-items-start mb-2">
            <span class=" fs-6 p-2 w-auto badge bg-info mb-3">
          Priority: {{ task.priority }} 
            </span>
            <span class=" fs-6 p-2 w-auto badge bg-secondary">
            Due: {{ task.duedate }}
            </span>
          </div>
        </div>
        <div class="d-flex justify-content-between mt-3">
          <button class="btn btn-secondary" @click="isediting=true"> UPDATE </button>
          <button class="btn btn-danger" @click="$emit('delete',task.id)"> DELETE </button>

        </div>
          <!-- <button class="btn btn-secondary" @click="$emit('update',task.id)"> UPDATE </button> -->
      </div>
    </div>
  </div>
</template>
