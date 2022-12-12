import { createApp } from 'vue'
import App from './App.vue'
import router from "./router/router";
import { createI18n } from "vue-i18n";

const i18n = createI18n({
    legacy: false,
    locale: "en",
    globalInjection: true,
    messages: {
        en: {
            message: {
                home: "Home",
                menu: "Menu",
                reserve: "Reserve a table",
                orders: "Shopping cart",
                orderbutton: "Order",
                date: "Date",
                time: "Time",
                table: "Table",
                reservationmessage: "This table is already reserved or the fields are empty",
                finalsum: "Price",
                emptyshoppingcart: "Your shopping cart is empty",
                popular: "Our most popular items!"

            },      
        },
        fi: {
            message: {
                home: "Koti",
                menu: "Ruokalista",
                reserve: "Varaa pöytä",
                orders: "Ostoskori",
                orderbutton: "Tilaa",
                date: "Päivänmäärä",
                time: "Kellonaika",
                table: "Pöytä",
                reservationmessage: "Tämä aika on jo varattu tai et ole täyttänyt kenttiä",
                finalsum: "Yhteensä",
                emptyshoppingcart: "Ostoskorisi on tyhjä",
                popular: "Suosituimmat tuotteemme!"
            },  
        }
    }
})

createApp(App).use(router).use(i18n).mount('#app')

