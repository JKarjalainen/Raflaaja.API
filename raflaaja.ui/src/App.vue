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

#app {

}
</style>
