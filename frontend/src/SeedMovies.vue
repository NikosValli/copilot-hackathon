<template>
  <div
    class="flex flex-col items-center p-6 bg-white rounded shadow w-full max-w-md mx-auto"
  >
    <h2 class="text-2xl font-bold mb-4 text-gray-800">Seed Movies</h2>
    <button
      class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition disabled:opacity-50"
      :disabled="loading"
      @click="seedMovies"
    >
      Seed Movies
    </button>
    <div v-if="loading" class="mt-4 flex items-center gap-2">
      <svg
        class="animate-spin h-5 w-5 text-blue-600"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
      >
        <circle
          class="opacity-25"
          cx="12"
          cy="12"
          r="10"
          stroke="currentColor"
          stroke-width="4"
        />
        <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v8z" />
      </svg>
      <span>Seeding in progress...</span>
    </div>
    <div v-if="message" class="mt-4 text-green-600">{{ message }}</div>
  </div>
</template>

<script setup>
import { ref } from "vue";

const loading = ref(false);
const message = ref("");

async function seedMovies() {
  loading.value = true;
  message.value = "";
  try {
    const res = await fetch("http://localhost:5065/seed", { method: "POST" }); // Use backend_HostAddress from backend.http
    if (res.ok) {
      message.value = "Movies seeded successfully!";
    } else {
      message.value = "Failed to seed movies.";
    }
  } catch (e) {
    message.value = "Error connecting to backend.";
  } finally {
    loading.value = false;
  }
}
</script>
