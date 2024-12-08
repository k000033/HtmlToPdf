<script setup lang="ts">
import { htmlToPdfAction } from "@/componentApi/htmlToPdfApi";
import TheWelcome from "../components/TheWelcome.vue";
import type { THtmlData } from "@/types/requestType";

const test = () => {
  const html3: string = document.body.outerHTML;

  htmlToPdfAction(html3);
};
</script>

<template>
  <main>
    <TheWelcome />
  </main>
  <button @click="test">test</button>
</template>
