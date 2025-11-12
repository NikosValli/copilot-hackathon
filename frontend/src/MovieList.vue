<template>
  <div class="p-6 bg-white rounded shadow w-full max-w-2xl mx-auto">
    <h2 class="text-2xl font-bold mb-4 text-gray-800">Movie List</h2>
    <div v-if="loading" class="flex items-center gap-2 mb-4">
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
      <span>Loading movies...</span>
    </div>
    <ul v-if="movies.length" class="divide-y divide-gray-200">
      <li
        v-for="movie in movies"
        :key="movie.id"
        class="py-3 flex justify-between items-center"
      >
        <span class="font-medium text-gray-700">{{ movie.title }}</span>
        <span class="bg-gray-100 text-gray-600 px-2 py-1 rounded text-xs">{{
          movie.category?.name
        }}</span>
      </li>
    </ul>
    <div v-else-if="!loading" class="text-gray-500">No movies found.</div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";

const movies = ref([]);
const loading = ref(false);

async function fetchMovies() {
  loading.value = true;
  try {
    const res = await fetch("http://localhost:5065/movies"); // Use backend_HostAddress from backend.http
    if (res.ok) {
      const data = await res.json();
      // Flatten and deduplicate movies by id
      const rawMovies = data.$values || [];
      const seen = new Set();
      const uniqueMovies = [];
      for (const m of rawMovies) {
        if (m && m.id && !seen.has(m.id)) {
          uniqueMovies.push(m);
          seen.add(m.id);
        }
      }
      movies.value = uniqueMovies;
    }
  } finally {
    loading.value = false;
  }
}

onMounted(fetchMovies);
</script>
