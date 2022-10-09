<template>
    <ul>
        <li><router-link to="/">Menu</router-link></li>
        <li><router-link to="/reservations">Reservations</router-link></li>
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
    background-color: #333;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
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
}
</style>