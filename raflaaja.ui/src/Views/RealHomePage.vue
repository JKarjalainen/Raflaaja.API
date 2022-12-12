<template>
    <nav-bar></nav-bar>
    <div class="hero-image">
      <div id="overlay"></div>
      <div class="hero-text">
        <h1>Raflaaja</h1>
        <button><router-link to="/menu">{{ $t("message.orderbutton") }}!</router-link></button>
      </div>
    </div>
    <div style="margin-bottom: 20px;">
      <h2>{{ $t("message.popular") }}</h2>
      <div class="flex-container">
        <div class="card">
          <div class="container">
            <h4><b>Pepperoni pizza</b></h4>
            <p>kova pizza</p>
            <p>9€</p>
          </div>
        </div>
        <div class="card">
          <div class="container">
            <h4><b>Talon burgeri</b></h4>
            <p>kova bursa</p>
            <p>8€</p>
          </div>
        </div>
        <div class="card">
          <div class="container">
            <h4><b>Naudan ulkofile</b></h4>
            <p>kova pihvi</p>
            <p>17€</p>
          </div>
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

<style>
@import url('https://fonts.googleapis.com/css2?family=Staatliches&display=swap');
</style>

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

@media only screen and (max-width: 500px) {
  h1 {
    font-size: 70px !important;
  }
}

h1 {
  font-family: 'Staatliches', cursive;  
  text-shadow: #000 0px 0px 8px;
  font-size: 125px;
  text-transform: uppercase;
 
  z-index: 2;
}
h2{
  text-align: center;
  color: #3a3a3a;
  margin-top: 20px;
}

button {
  font-family: 'Staatliches', cursive;  
  font-size: 30px;
  letter-spacing: 2px;
  text-decoration: none;
  color: #000;
  cursor: pointer;
  border: 3px solid;
  padding: 0.25em 0.5em;
  position: relative;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  z-index: 2;
  background: rgb(255, 255, 255);
}
button:hover{
  transition: .3s;
  background-color: rgba(255, 255, 255, 0.324) ;
}

button:active {
  box-shadow: 0px 0px 0px 0px;
  top: 5px;
  left: 5px;
}
button a{
    color: #000 !important;
    text-decoration: none;
}

@media (min-width: 768px) {
  button {
    padding: 0.25em 0.75em;
  }
}

</style>