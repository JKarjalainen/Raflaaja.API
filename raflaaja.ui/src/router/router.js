import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/Views/HomePage";
import ReservationsPage from "@/Views/ReservationsPage";
import ShoppingCart from "@/Views/ShoppingCart";

const routes = [
    { path: "/", component: HomePage },
    { path: "/reservations", component: ReservationsPage },
    { path: "/shoppingcart", component: ShoppingCart }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router