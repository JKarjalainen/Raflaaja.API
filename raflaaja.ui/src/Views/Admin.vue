<template>
    
    <h2 style="text-align: center; background: #d9b99b; margin: 0; padding-bottom: 20px; padding-top: 20px;">Hello, Admin(username)</h2>
    <div class="flex-container">
        <div class="card">
            <div class="container">
                <button @click="changeClick($event)" id="seeMenuItems">Add or modify menu items</button>
            </div>
        </div>
        <div class="card">
            <div class="container">
                <button @click="changeClick($event)" id="seeTables">Add or modify tables</button>
            </div>
        </div>
        <div class="card">
            <div class="container">
                <button @click="changeClick($event)" id="seeOrders">See Orders</button>
            </div>
        </div>
    </div>
    <div v-if="menuitems == true">
        <div>
            <input type="text" v-model=newProduct.name>
            <input type="text" v-model=newProduct.description>
            <input type="text" v-model=newProduct.price>
            <button @click="addProduct()">Add</button>
        </div>
        <div v-if="products.length < 1" style="margin-top: 80px">You have no menu items</div>
        <div v-for="product in products" v-bind:key="product" class="prod">
            <input type="text" v-model=product.name>
            <input type="text" v-model=product.description>
            <input type="text" v-model=product.price>
            <button @click="modifyProduct(product)">Set changes</button>
            <button @click="deleteProduct(product.productId)">Delete</button>
        </div>
    </div>
    <div v-if="tableitems == true">
        <div>
            <input type="text" v-model=newTable.size>
            <button @click="addTable()">Add</button>
        </div>
        <div v-if="tables.length < 1" style="margin-top: 80px">You have no tables</div>
        <div v-for="table in tables" v-bind:key="table" class="prod">
            Table number {{table.tableNumber}}
            Table size <input type="text" v-model=table.size>
            <button @click="modifyTable(table)">Set changes</button>
            <button @click="deleteTable(table.tableNumber)">Delete</button>
        </div>
    </div>
    <div v-if="orderitems == true">
        <div v-if="orders.length < 1" style="margin-top: 80px">You have no orders</div>
        <div v-for="order in orders" v-bind:key="order" class="prod">
            <hr>
            <h><i>UserId of order {{ order.userId }}</i></h>
            <div v-for="orderItem in order.orderIncludes" v-bind:key="orderItem" class="prod">
                <h><i>{{ orderItem.product.name }}</i></h>
                <p>{{ orderItem.product.description }}</p>
                <p>{{ orderItem.product.price }}€</p>
            </div>
<!--            <p>{{ order.total() }}€</p>-->
        </div>
    </div>


</template>

<script>
//import test from 'node:test';

export default {
    name: "Admin-page",
    components: {},
    data() {
        return {
            products: [],
            orders: [],
            tables: [],
            menuitems: false,
            tableitems: false,
            orderitems: false,
            newProduct: {},
            newTable: {}
        }
    },
    methods: {
        async getProducts() {
            const response = await fetch("https://localhost:5001/api/products/");
            let allproducts = await response.json();
            this.products = allproducts;

        },

        changeClick: function (event) {
            if (event.currentTarget.id == "seeMenuItems") {
                this.menuitems = true;
                this.tableitems = false;
                this.orderitems = false;
            } else if (event.currentTarget.id == "seeTables") {
                this.menuitems = false;
                this.tableitems = true;
                this.orderitems = false;
            } else {
                this.menuitems = false;
                this.tableitems = false;
                this.orderitems = true;
            }
        },


        DeleteItem: function (event) {
            let parent = event.target.parentElement
            parent.style = "opacity:0.5;pointer-events: none"

            //tähän jotain tietokanta poisto juttuu emt

        },
        async getOrders() {
            // this.testOrderItem.setProd(this.products[0])
            // this.testOrderItem2.setProd(this.products[0])
            // this.testOrderItem2.setProd(this.products[0])
            // this.testOrderItem2.setProd(this.products[0])
            // this.orders[0] = this.testOrderItem
            // this.orders[1] = this.testOrderItem2
            const response = await fetch("https://localhost:5001/api/orders/");
            let allOrders = await response.json();
            this.orders = allOrders;


            console.log(this.order);
            console.log(typeof (this.order));
        },
        async modifyProduct(product) {
            product.price = +product.price;
            const response = await fetch("https://localhost:5001/api/products/" + product.productId, {
                method: "PUT",
                body: JSON.stringify(product),
                headers: {
                    "Content-Type": "application/json"
                }
            });
            console.log(await response.json());
            console.log(product)
        },
        async getTables() {
            const response = await fetch("https://localhost:5001/api/tables/");
            this.tables = await response.json();
        },
        async modifyTable(table) {
            table.size = +table.size;
            const response = await fetch("https://localhost:5001/api/tables/" + table.tableNumber, {
                method: "PUT",
                body: JSON.stringify(table),
                headers: {
                    "Content-Type": "application/json"
                }
            });
            console.log(await response.json());
        },
        async addProduct() {
            this.newProduct.price = +this.newProduct.price;
            const response = await fetch("https://localhost:5001/api/products/", {
                method: "POST",
                body: JSON.stringify(this.newProduct),
                headers: {
                    "Content-Type": "application/json"
                }
            });
            console.log(await response.json());
        },
        async addTable() {
            this.newTable.size = +this.newTable.size;
            const response = await fetch("https://localhost:5001/api/tables/", {
                method: "POST",
                body: JSON.stringify(this.newTable),
                headers: {
                    "Content-Type": "application/json"
                }
            });
            console.log(await response.json());
        },
        async deleteProduct(id) {
            const response = await fetch("https://localhost:5001/api/products/" + id, {
                method: "DELETE",
                body: JSON.stringify(this.newProduct),
            });
            console.log(await response.json());
        },
        async deleteTable(id) {
            const response = await fetch("https://localhost:5001/api/tables/" + id, {
                method: "DELETE",
            });
            console.log(await response.json());
        }


    },
    async created() {

        await this.getOrders();
        console.log(this.orders)
        await this.getProducts();
        await this.getTables();
    },


}
</script>

<style scoped>

.order{
  background: #d9b99b;
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  width: 33%;
  margin: 10px auto 0 auto;
}
div{
    display: flex;
    justify-content: center;
    flex-direction: column;
    align-items: center;
}
.flex-container {
  display: flex;
  flex-wrap: nowrap;
  padding-bottom: 10px;
  background: #d9b99b;
  flex-direction: row;

}
.card{
  box-shadow: none !important;
}
.flex-container > div {
    text-align: center;
    font-size: 30px;
}

.card {
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    transition: 0.3s;
    width: 40%;
}

.card:hover {
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
}

.container {
    padding: 2px 16px;
}

div {
    font-size: 20px;
}

.prod{
  display: flex;
  flex-direction: column;
  width: 33%;
}

.prod > *{
  margin-top: 10px;
  margin-left: 10px;
}

.hero-image {
    background-image: url("@/assets/Pizza.jpg");
    background-color: #cccccc;
    height: 700px;
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
    font-family: Helvetica;
    font-size: 60px;
}
input[type="text"]{
        border: 3px solid #000;
        font-size: 15px;
        padding:5px;
        margin-top: 10px;
    }
    input[type="text"]:focus-visible{
        border-color: rgb(15, 108, 221) !important;
        transition: .3s ease-in;
        outline: none !important;
    }
button {
  font-family: 'Staatliches', cursive;
  font-size: 30px;
  letter-spacing: 2px;
  text-decoration: none;
  text-transform: uppercase;
  color: #000;
  cursor: pointer;
  border: 3px solid;
  padding: 0.25em 0.5em;
  position: relative;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  margin-top: 10px;
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
