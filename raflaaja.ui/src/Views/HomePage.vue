<template>
    <nav-bar />
  <div class="hero-image">
    <div class="hero-text">
      <h1 style="font-size:50px; -webkit-text-stroke: 1.5px black;" >Menu</h1>
    </div>
  </div>
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

h1 {
  font-family:Helvetica;
  font-size: 60px;
  text-align: center;
  color: white;
  margin: 20px;
}
.hero-image {
  background-image: url("@/assets/Menu.jpg");
  background-color: #cccccc;
  height: 400px;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  position: relative;
  margin-top: 30px;

}
router-link {
  text-decoration: none;
}

.hero-text {
  text-align: center;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  color: white;
}

</style>