<template>
    
    <h2 style="text-align: center">Hello, Admin(username)</h2>
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
      <div v-if="products.length < 1" style="margin-top: 80px">You have no menu items</div>
      <div v-for="product in products" v-bind:key="product" class="prod">
        <input type="text" :value= product.name >
        <input type="text" :value= product.description>
        <input type="text" :value= product.price>
        <button>Set changes</button>
        <button @click="DeleteItem($event)">Delete</button>
      </div>
    </div>
    <div v-if="tableitems == true">
      <div v-if="tables.length < 1" style="margin-top: 80px">You have no tables</div>
      <div v-for="table in tables" v-bind:key="table" class="prod">
        <h><i>{{ table.name }}</i></h>
        <p>{{ table.description }}</p>
        <p>{{ table.price }}€</p>
      </div>
    </div>
    <div v-if="orderitems == true">
      <div v-if="orders.length < 1" style="margin-top: 80px">You have no orders</div>
      <div v-for="order in orders" v-bind:key="order" class="prod">
        <h><i>{{ order.username }}</i></h>
        <div v-for="product in order.products" v-bind:key="product" class="prod">
          <h><i>{{ product.name }}</i></h>
          <p>{{ product.description }}</p>
          <p>{{ product.price }}€</p>
      </div>
        <p>{{ order.total() }}€</p>
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





           
           testMenuItem: {
              name:"testituote",
              description:"Testituotteen kuvaus",
              price:9.99
            },
            testOrderItem:{
              username:"Matti Meikäläinen",
              products:[],
              total: function() {
                let tot = 0;
                //ei halunnu toimia for in loopil XD
                for (let i = 0; i<this.products.length;i++){
                  tot = tot + this.products[i].price;
                  console.log(tot)
                }
                return tot
              },
              setProd: function(prod) {
                this.products[this.products.length] = prod
                this.total()
              }
            },
            testOrderItem2:{
              username:"Maija Meikäläinen",
              products:[],
              total: function() {
                let tot = 0;
                for (let i = 0; i<this.products.length;i++){
                  tot = tot + this.products[i].price;
                  console.log(tot)
                }
                return tot
              },
              setProd: function(prod) {
                this.products[this.products.length] = prod
                this.total()
              }
            }
    }
  },
    methods:{
      async getProducts() {
            const response = await fetch("https://localhost:5001/api/products/");
            let allproducts = await response.json();
            for (let e of this.order) {
                this.products.push(allproducts.find(x => x.productId == e));
            }
            
        },

      changeClick: function(event){
        if(event.currentTarget.id == "seeMenuItems"){
          this.menuitems = true;
          this.tableitems = false;
          this.orderitems = false;
        }else if(event.currentTarget.id == "seeTables"){
          this.menuitems = false;
          this.tableitems = true;
          this.orderitems = false;
      }else{
        this.menuitems = false;
          this.tableitems = false;
          this.orderitems = true;
      }
    },






    DeleteItem: function(event){
      let parent = event.target.parentElement
      parent.style = "opacity:0.5;pointer-events: none"

      //tähän jotain tietokanta poisto juttuu emt

    }

 
   
  },
  async created() {
        this.products[0] = this.testMenuItem
        this.testOrderItem.setProd(this.products[0])
        this.testOrderItem2.setProd(this.products[0])
        this.testOrderItem2.setProd(this.products[0])
        this.testOrderItem2.setProd(this.products[0])
        this.orders[0] = this.testOrderItem
        this.orders[1] = this.testOrderItem2

        let storage = localStorage.getItem("order")
        this.order = storage !== null ? storage.split(",") : [];
        console.log(this.order);
        console.log(typeof (this.order));

        console.log(this.orders)
        await this.getProducts();
    }
  
}
</script>

<style scoped>

.flex-container {
  display: flex;
  flex-wrap: nowrap;
}

.flex-container > div {
  text-align: center;
  font-size: 30px;
}

.card {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  width: 40%;
}

.card:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.container {
  padding: 2px 16px;
}

div {
  font-size: 20px;
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
  font-family:Helvetica;
  font-size: 60px;
}

button {
  font-family:Helvetica;
  font-size: 30px;
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
