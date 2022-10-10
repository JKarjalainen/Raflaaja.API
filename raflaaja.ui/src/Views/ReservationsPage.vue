<template>
    <nav-bar></nav-bar>
    <p>Reservations</p>
    <input type="date" v-model="reservationDate" />
    <input type="time" min="09:00" max="22:00" v-model="reservationTime"/>
    Table number:
    <select v-model="wantedTable" name="cars">
        <template v-for="table in tables" :key="table.tableNumber">
            <option :value="table.tableNumber">Table {{table.tableNumber}} for {{table.size}} people</option>
        </template>
    </select>
    <div v-if="validReservation">
        validReservation
    </div>
    <div v-else>
        not valid
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
            tables: [],
            reservationTime: "",
            wantedTable: 0,
            validReservation: false
        }
    },
    async created() {
        console.log(moment())
        let res = await fetch("https://localhost:44389/api/reservations/")
        let data = await res.json();
        this.reservations = data;
        let tablesReq = await fetch("https://localhost:44389/api/tables/");
        this.tables = await tablesReq.json();
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
                console.log({time});
                isReserved = (wantedTime.isBetween(start, end) || wantedTime.isSame(start)) && time.tables.map(x => x.tableNumber).includes(this.wantedTable);
            }
            console.log({isReserved})
             this.validReservation = !isReserved;
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