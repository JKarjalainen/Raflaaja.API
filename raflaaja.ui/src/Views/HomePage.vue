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
#app {
  background-image: url("@/assets/Pizza.jpg");
}

</style>