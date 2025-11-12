<script setup>
import SeedMovies from "./SeedMovies.vue";
import MovieList from "./MovieList.vue";
</script>

<template>
  <div
    class="min-h-screen bg-gray-50 flex flex-col items-center justify-center gap-8"
  >
    <SeedMovies />
    <MovieList />
  </div>
</template>

<style scoped></style>
