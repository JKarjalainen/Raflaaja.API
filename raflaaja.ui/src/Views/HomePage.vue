<template>
    <nav-bar />
  <div class="hero-image">
    <div id="overlay"></div>
    <div class="hero-text">
      <h1 style="font-size:50px; -webkit-text-stroke: 1.5px black;" >{{ $t("message.menu") }}</h1>
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
<style>
@import url('https://fonts.googleapis.com/css2?family=Staatliches&display=swap');
</style>

<style scoped>

h1 {
  font-size: 60px;
  text-align: center;
  color: white;
  margin: 20px;
  font-family: 'Staatliches', cursive;  
  text-shadow: #000 0px 0px 8px;
}
.hero-image {
  background-image: url("@/assets/Menu.jpg");
  background-color: #cccccc;
  height: 400px;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  position: relative;

}
#overlay{
  position: absolute;
  height: 100%;
  width: 100%;
  background: #000;
  top: 0;
  right: 0;
  z-index: 0;
  opacity: 0.4;
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