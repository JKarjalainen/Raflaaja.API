import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/Views/HomePage";
import ReservationsPage from "@/Views/ReservationsPage";
import ShoppingCart from "@/Views/ShoppingCart";
import RealHomePage from "@/Views/RealHomePage";

const routes = [
    { path: "/menu", component: HomePage },
    { path: "/reservations", component: ReservationsPage },
    { path: "/shoppingcart", component: ShoppingCart },
    { path: "/", component: RealHomePage}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router