<template>
    <router-link to="/">p</router-link>
    <router-view></router-view>
</template>

<script>

export default {
  name: 'App',
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;1,100;1,300&display=swap');
#app {
    font-family: 'Roboto', sans-serif;
    min-height: 100vh;
    display: flex;
    flex-direction: column;
}

.card{
  margin: 10px !important;
  background-color: #d9b99b;
  color: #3a3a3a;
}
body{
  margin: 0 !important;
}

</style>
