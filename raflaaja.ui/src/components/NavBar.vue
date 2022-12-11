<template>
    <ul>
        <li><router-link to="/">Koti</router-link></li>
        <li><router-link to="/menu">Ruokalista</router-link></li>
        <li><router-link to="/reservations">Varaa pöytä</router-link></li>
        <li><router-link to="/shoppingcart">Tilauksesi</router-link></li>
    </ul>
</template>

<script>
export default {
    name: "NavBar"
}
</script>

<style scoped>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #3a3a3a;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    z-index: 100;
    display: flex;
    justify-content: center;
}

li {
    float: left;
}

li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover {
    background-color: #111;
    transition: .3s;
}
</style>