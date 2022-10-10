<template>
    <div id="product-container">
        <div v-for="product in products" v-bind:key="product" class="prod">
            <h><i>{{ product.name }}</i></h>
            <p>{{ product.description }}</p>
            <p>{{ product.price }}€</p>
            <button @click="addProductToOrder(product.productId)">Lisää tilaukseen</button>
        </div>
    </div>
</template>

<script>
export default {
    name: "MenuList",
    data() {
        return {
            products: [],
            order: []
        }
    },

    watch: {
        order(newOrder) {
            localStorage.setItem("order", newOrder);
            console.log("order");
        }
    },

    methods: {
        async getProducts() {
            const response = await fetch("https://localhost:5001/api/products/");
            this.products = await response.json();
        },
        
        addProductToOrder(product) {
            this.order = [...this.order, product]
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