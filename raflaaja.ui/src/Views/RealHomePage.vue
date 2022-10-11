<template>
    <nav-bar></nav-bar>
    <div class="hero-image">
      <div class="hero-text">
        <h1 style="font-size:100px; -webkit-text-stroke: 3px black;" >Raflaaja</h1>
        <button><router-link to="/menu" style="text-decoration: none; color: black">Tilaa nyt!</router-link></button>
      </div>
    </div>
</template>

<script>
import NavBar from "@/components/NavBar";
export default {
    name: "RealHomePage",
    components: {NavBar}
}
</script>

<style scoped>

div {
  font-size: 20px;
}

.hero-image {
  background-image: url("@/assets/Pizza.jpg");
  background-color: #cccccc;
  height: 700px;
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
h1 {
  font-family:Helvetica;
  font-size: 60px;
}

button {
  font-family:Helvetica;
  font-size: 30px;
  letter-spacing: 2px;
  text-decoration: none;
  text-transform: uppercase;
  color: #000;
  cursor: pointer;
  border: 3px solid;
  padding: 0.25em 0.5em;
  box-shadow: 1px 1px 0px 0px, 2px 2px 0px 0px, 3px 3px 0px 0px, 4px 4px 0px 0px, 5px 5px 0px 0px;
  position: relative;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
}

button:active {
  box-shadow: 0px 0px 0px 0px;
  top: 5px;
  left: 5px;
}

@media (min-width: 768px) {
  button {
    padding: 0.25em 0.75em;
  }
}

</style>