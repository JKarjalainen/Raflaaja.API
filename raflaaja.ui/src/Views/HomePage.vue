<template>
    <nav-bar />
    <menu-list />
    <footer-bar></footer-bar>
</template>

<script>
import MenuList from "@/components/MenuList";
import NavBar from "@/components/NavBar";
import FooterBar from "@/components/FooterBar";

export default {
    name: "HomePage",
    components: {
        NavBar,
        MenuList,
        FooterBar,
    }
}
</script>

<style scoped>

body {
  background: url("@/assets/Pizza.jpg") no-repeat center center
  fixed;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}

</style>