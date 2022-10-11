<template>
    <nav-bar></nav-bar>
    <p>Varaa pöytä</p>
    <input type="date" v-model="reservationDate" />
    <input type="time" min="09:00" max="22:00" v-model="reservationTime"/>
    Pöytä:
    <select v-model="wantedTable" name="cars">
        <template v-for="table in tables" :key="table.tableNumber">
            <option :value="table.tableNumber">Pöytä {{table.tableNumber}} koko {{table.size}} henkilöä</option>
        </template>
    </select>
    <div v-if="validReservation">
        <p>Vapaa aika</p>
        <button @click="makeReservation()">Tee varaus</button>
    </div>
    <div v-else>

        <p>Tämä aika on jo varattu tai et ole täyttänyt kenttiä</p>
    </div>
</template>

<script>
import NavBar from "@/components/NavBar";
import moment from "moment";
import swal from "sweetalert";
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
        let res = await fetch("https://localhost:5001/api/reservations/")
        let data = await res.json();
        this.reservations = data;
        let tablesReq = await fetch("https://localhost:5001/api/tables/");
        this.tables = await tablesReq.json();
    },
    methods: {
        async getOpenTimes(date) {
            let clockTime = this.reservationTime.split(":");
            let hours = +clockTime[0];
            let minutes = +clockTime[1];
            let wantedTime = moment(date).add(hours, "hours").add(minutes, "minutes");
            console.log({wantedTime});
            let isReserved = false;
            for(let time of this.reservations) {
                let start = moment(time.startTime);
                let end = moment(time.endTime);
                console.log({start, end, wantedTime})
                console.log({time});
                console.log(wantedTime.isBetween(start, end))
                console.log(wantedTime.isSame(start))
                console.log(time.tables.map(x => x.tableNumber).includes(this.wantedTable))
                isReserved = (wantedTime.isBetween(start, end) || wantedTime.isSame(start)) && time.tables.map(x => x.tableNumber).includes(this.wantedTable);
            }
            let isFilled = this.reservationDate !== "" && this.reservationTime !== "" && this.wantedTable !== 0;
            console.log({isReserved})
            this.validReservation = !isReserved && isFilled;
        },
        async makeReservation() {
            let clockTime = this.reservationTime.split(":");
            let hours = +clockTime[0];
            let minutes = +clockTime[1];
            let finalDate = moment(this.reservationDate).add(hours, "hours").add(minutes, "minutes");
            console.log(clockTime);
            let data = {
                reservationId: Math.max(...this.reservations.map(x => x.reservationId)) + 1,
                startTime: finalDate.format(),
                numberOfPeople: 4,
                userId: 1,
                tableNumbers: [this.wantedTable]
            }
            console.log("a: " + data.startTime);
            let res = fetch("https://localhost:5001/api/reservations/", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                    // 'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: JSON.stringify(data)
            });
            console.log(res);
            swal("Varaus tehtiin onnistuneesti ajalle " + finalDate.format("DD-MM-YYYY HH:mm"));
        }
    },
    watch: {
        async reservationDate(newDate) {
            await this.getOpenTimes(newDate);
        },
        async wantedTable() {
            await this.getOpenTimes(this.reservationDate);
        },
        async reservationTime() {
            await this.getOpenTimes(this.reservationDate);
        }
    }
}
</script>

<style scoped>
p {
    padding: 20px;
}

</style>