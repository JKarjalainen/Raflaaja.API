import {createRouter, createWebHistory} from "vue-router";
import HomePage from "@/Views/HomePage";
import ReservationsPage from "@/Views/ReservationsPage";
import ShoppingCart from "@/Views/ShoppingCart";
import RealHomePage from "@/Views/RealHomePage";
import AdminPage from "@/Views/Admin"
import ReservationsContent from "@/components/ReservationsContent";
import LoginPage from "@/Views/Login";
import SignUpPage from "@/Views/Sign-up";

const routes = [
    {path: "/menu", component: HomePage},
    {path: "/reservations", component: ReservationsPage},
    {path: "/shoppingcart", component: ShoppingCart},
    {path: "/", component: RealHomePage},
    {path: "/admin", component: AdminPage},
    {path: "/admin/reservations", component: ReservationsContent},
    {path: "/login",component: LoginPage},
    {path: "/sign-up",component: SignUpPage}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router