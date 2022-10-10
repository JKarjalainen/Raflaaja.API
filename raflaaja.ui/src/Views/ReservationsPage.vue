<template>
    <nav-bar></nav-bar>
    <p>Reservations</p>
    <input type="date" v-model="reservationDate" />
    <input type="time" min="09:00" max="22:00" v-model="reservationTime"/>
    <div v-if="reservationDate !== ''">

    </div>
</template>

<script>
import NavBar from "@/components/NavBar";
import moment from "moment";
export default {
    name: "ReservationsPage",
    components: {NavBar},
    data() {
        return {
            reservations: [],
            reservationDate: "",
            openTimes: [],
            reservationTime: ""
        }
    },
    async created() {
        console.log(moment())
        let res = await fetch("https://localhost:44389/api/reservations/")
        let data = await res.json();
        this.reservations = data;
    },
    methods: {
        async getOpenTimes(date) {
            let wantedTime = moment(date);
            console.log({wantedTime});
            let isReserved = false;
            for(let time of this.reservations) {
                let start = moment(time.startTime);
                let end = moment(time.endTime);
                console.log({start, end, wantedTime})
                isReserved = wantedTime.isBetween(start, end) || wantedTime.isSame(start)
            }
            console.log({isReserved});
        },
        async getOpenTables(date, time) {
            return (date, time);
        },
    },
    watch: {
        async reservationDate(newDate) {
            await this.getOpenTimes(newDate);
        }
    }
}
</script>

<style scoped>
p {
    padding: 20px;
}
</style>