import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/Views/HomePage";
import ReservationsPage from "@/Views/ReservationsPage";

const routes = [
    { path: "/", component: HomePage },
    { path: "/reservations", component: ReservationsPage}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router