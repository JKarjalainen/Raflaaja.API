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
import swal from "sweetalert";
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
            const response = await fetch("https://localhost:44389/api/products/");
            this.products = await response.json();
        },
        
        addProductToOrder(product) {
            if(this.order.length < 1)
                this.order = [product]
            else
                this.order = [...this.order, product]

            swal("Tuote lisätty tilaukseen", {
                buttons: false,
                timer: 1000,
            });
        }
    },

    
    async created() {
        await this.getProducts();
        let storage = localStorage.getItem("order");
        let data = storage.split(",")
        this.order = data;
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