<template>
    <nav-bar />
    <menu-list />
</template>

<script>
import MenuList from "@/components/MenuList";
import NavBar from "@/components/NavBar";

export default {
  name: 'App',
  components: {
      NavBar,
      MenuList,
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;1,100;1,300&display=swap');
#app {
    font-family: 'Roboto', sans-serif;
}
</style>
