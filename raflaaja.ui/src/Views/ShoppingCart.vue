<template>
    <nav-bar></nav-bar>
    <div v-if="products.length < 1">Ostoskorisi on tyhjä</div>
    <div v-for="product in products" v-bind:key="product" class="prod">
        <h><i>{{ product.name }}</i></h>
        <p>{{ product.description }}</p>
        <p>{{ product.price }}€</p>
    </div>
    <div v-if="order.length > 0">
        <p>Yhteensä: {{ getFullPrice() }}€</p>
        <button @click="addOrder()">Tilaa</button>
    </div>
</template>

<script>
import NavBar from "@/components/NavBar";
import swal from "sweetalert";

export default {
    name: "ShoppingCart",
    components: {NavBar},
    data() {
        return {
            products: [],
            order: []

        }
    },

    methods: {
        async getProducts() {
            const response = await fetch("https://localhost:44389/api/products/");
            let allproducts = await response.json();
            for (let e of this.order) {
                this.products.push(allproducts.find(x => x.productId == e));
            }
            console.log(this.products);
        },

        getFullPrice() {
            let fullprice = 0;
            for (let e of this.products) {
                fullprice += e.price;
            }
            return fullprice;
        },
        async addOrder() {
            let distinctProducts = [...new Set(this.order)];
            let includedProductIds = [];
            for (let prodId of distinctProducts) {
                console.log(prodId)
                includedProductIds.push({productId: +prodId, amount: this.order.filter(id => id === prodId).length});
            }
            console.log({includedProductIds});
            await fetch("https://localhost:44389/api/orders/", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                    // 'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: JSON.stringify(includedProductIds)
            });

            localStorage.clear();
            this.order = [];
            this.products = [];
            swal({icon: "success", text: "Tilaus on lähetetty ravintolalle"})
        }

    },
    async created() {
        let storage = localStorage.getItem("order")
        this.order = storage !== null ? storage.split(",") : [];
        console.log(this.order);
        console.log(typeof (this.order));
        await this.getProducts();
    }

}
</script>

<style scoped>
.prod {
    padding: 30px;
    width: 50%;
    align-self: center;
}

div {
    padding: 30px;
}


</style>