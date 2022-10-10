<template>
    <nav-bar></nav-bar>
  <div id="product-container">
    <div v-for="product in products" v-bind:key="product" class="prod">
      <h><i>{{ product.name }}</i></h>
      <p>{{ product.description }}</p>
      <p>{{ product.price }}€</p>
    </div>
    <p>Yhteensä: {{ getFullPrice() }}€</p>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar";
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
        for(let e of this.products) {
          fullprice += e.price;
        }
        return fullprice;
      },

    },
    async created() {
      this.order = localStorage.getItem("order").split(",");
      console.log(this.order);
      console.log(typeof(this.order));
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