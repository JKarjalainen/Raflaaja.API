<template>
    <div id="product-container">
        <div v-for="product in products" v-bind:key="product" class="prod">
            <h><i>{{ product.name }}</i></h>
            <p>{{ product.description }}</p>
            <p>{{ product.price }}€</p>
        </div>
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