<template>
    <nav-bar></nav-bar>
    <div class="hero-image">
      <div class="hero-text">
        <h1 style="font-size:100px; -webkit-text-stroke: 3px black;" >Raflaaja</h1>
        <button><router-link to="/menu" style="text-decoration: none; color: black">{{ $t("message.orderbutton") }}!</router-link></button>
      </div>
    </div>
    <h2 style="text-align: center">{{ $t("message.popular") }}</h2>
    <div class="flex-container">
      <div class="card">
        <div class="container">
          <h4><b>Pepperoni pizza</b></h4>
          <p>vitun hyvä pizza</p>
          <p>9€</p>
        </div>
      </div>
      <div class="card">
        <div class="container">
          <h4><b>Talon burgeri</b></h4>
          <p>vitun hyvä bursa</p>
          <p>8€</p>
        </div>
      </div>
      <div class="card">
        <div class="container">
          <h4><b>Naudan ulkofile</b></h4>
          <p>vitun hyvä pihvi</p>
          <p>17€</p>
        </div>
      </div>
    </div>

  <footer-bar></footer-bar>

</template>

<script>
import NavBar from "@/components/NavBar";
import FooterBar from "@/components/FooterBar";
export default {
    name: "RealHomePage",
    components: {NavBar, FooterBar}
}
</script>

<style scoped>

.flex-container {
  display: flex;
  flex-wrap: nowrap;
}

.flex-container > div {
  text-align: center;
  font-size: 30px;
}

.card {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  width: 40%;
}

.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.container {
  padding: 2px 16px;
}

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