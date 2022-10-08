<template>
    <div v-for="product in products" v-bind:key="product">
        <h><i>{{ product.name }}</i></h>
        <p>{{ product.description }}</p>
        <span>{{ product.price }}</span>
    </div>
</template>

<script>
export default {
    name: "MenuList",
    data() {
        return {
            products: []
        }
    },
    methods: {
        async getProducts() {
            const response = await fetch("https://localhost:44389/api/products/");
            this.products = await response.json();
        }
    },
    async created() {
        await this.getProducts();
    }
}
</script>

<style scoped>

</style>