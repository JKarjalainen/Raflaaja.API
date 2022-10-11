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
            const response = await fetch("https://localhost:5001/api/products/");
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
div {
  font-size: 20px;
}
.prod {
    padding: 20px;
    width: 50%;
    align-self: center;
}
#product-container {
    display: flex;
    flex-direction: column;
    justify-content: flex-end;
    background-color: lightblue;
    width: 70%;
    margin: auto;
    width: 70%;
    padding: 10px;
}
button {
  font-family:Helvetica;
  font-size: 13px;
  letter-spacing: 2px;
  text-decoration: none;
  text-transform: uppercase;
  color: #000;
  cursor: pointer;
  border: 3px solid;
  padding: 0.25em 0.5em;
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

</style>