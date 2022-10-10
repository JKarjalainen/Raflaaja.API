<template>
    <nav-bar></nav-bar>
    <p>
       fuck you
    </p>
</template>

<script>
import NavBar from "@/components/NavBar";
export default {
    name: "ShoppingCart",
    components: {NavBar},
    data() {
        return {
            order: []
        }
    },


    methods: {

    },

}
</script>

<style scoped>
.prod {
    padding: 20px;
    width: 50%;
    align-self: center;
}
#product-container {
    display: flex;
    margin-top: 50px;
    flex-direction: column;
    justify-content: flex-end;
}

</style>