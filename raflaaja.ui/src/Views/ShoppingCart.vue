<template>
    <nav-bar></nav-bar>
  <div class="hero-image">
    <div class="hero-text">
      <h1 style="font-size:50px; -webkit-text-stroke: 1.5px black;" >Tilauksesi</h1>
    </div>
  </div>
  <div class="bg">
    <div v-if="products.length < 1" style="margin-top: 80px">Ostoskorisi on tyhjä</div>
    <div v-for="product in products" v-bind:key="product" class="prod">
      <h><i>{{ product.name }}</i></h>
      <p>{{ product.description }}</p>
      <p>{{ product.price }}€</p>
    </div>
    <div v-if="order.length > 0">
      <p>Yhteensä: {{ getFullPrice() }}€</p>
      <button @click="addOrder()">Tilaa</button>
    </div>
  </div>
  <footer-bar></footer-bar>
</template>

<script>
import NavBar from "@/components/NavBar";
import swal from "sweetalert";
import FooterBar from "@/components/FooterBar";

export default {
    name: "ShoppingCart",
    components: {NavBar,FooterBar},
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
    padding-top: 30px;
    width: 50%;
    align-self: center;
}

div {
    padding-left: 50px;
    font-size: 20px;
}
button {
  font-family:Helvetica;
  font-size: 17px;
  letter-spacing: 2px;
  text-decoration: none;
  text-transform: uppercase;
  color: #000;
  cursor: pointer;
  border: 3px solid;
  padding: 0.25em 0.5em;
  margin-bottom: 20px;
  box-shadow: 1px 1px 0px 0px, 2px 2px 0px 0px, 3px 3px 0px 0px, 4px 4px 0px 0px, 5px 5px 0px 0px;
  position: relative;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
}

button:active {
  box-shadow: 0px 0px 0px 0px;
  top: 5px;
  left: 5px;
}

@media (min-width: 768px) {
  button {
    padding: 0.25em 0.75em;
  }
}
.hero-image {
  background-image: url("@/assets/Table2.jpg");
  background-color: #cccccc;
  height: 400px;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  position: relative;
  margin-top: 30px;

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
h1 {
  font-family:Helvetica;
  font-size: 60px;
  text-align: center;
  color: white;
  margin: 20px;
}
.bg {
  background-color: floralwhite;
}

</style>