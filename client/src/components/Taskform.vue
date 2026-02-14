<script setup lang="ts">
import { ref } from 'vue';

const emit=defineEmits(["create"])

const form = ref({
    title:"",
    description:"",
    priority:"low",
    duedate:null,
    completed:false
})

const submit=()=>{
    emit("create",form.value)

    form.value=({
    title:"",
    description:"",
    priority:"low",
    duedate:null,
    completed:false
})
}

</script>

<template>
        <div class="container">

            <form @submit.prevent="submit">
                <div class="input-titletask mb-3 mt-3">
                    <input type="text" placeholder="Title" v-model="form.title" class="form-control">
                </div>
                <div class="input-desctask mb-3">
                    <textarea type="text" placeholder="Task Description" v-model="form.description" class="form-control"></textarea>
                </div>
                <div class="input-priorityselect mb-3 mt-3">
                    <select class="form-select" v-model="form.priority">
                        <option value="low">Low</option>
                        <option value="medium">Medium</option>
                        <option value="high">High</option>
                    </select>
                </div>
                <div class="input-duedate mb-3">
                    <input type="date" class="form-control" v-model="form.duedate">
                </div>
                <button class="btn btn-primary w-100" type="submit"> Add Task </button>
            </form>
        </div>
</template>