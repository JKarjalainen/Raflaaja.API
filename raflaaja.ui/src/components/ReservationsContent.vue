<template>
    <input type="date" v-model="reservationDate" />
    <div v-for="reservation in reservationsOnDate" v-bind:key="reservation">
        <hr>
        <p>UserId: {{reservation.user.userId}}</p>
        <p>Firstname: {{reservation.user.firstName}}</p>
        <p>Lastname: {{reservation.user.lastName}}</p>
        <p>Id: {{reservation.reservationId}}</p>
        <p>Start time: {{reservation.formattedStart}}</p>
        <p>End time: {{reservation.formattedEnd}}</p>
        <p>Number of people: {{reservation.numberOfPeople}}</p>
    </div>
    <hr>
</template>

<script>
import moment from "moment";
export default {
    name: "ReservationsContent",
    data() {
        return {
            reservationDate: "",
            reservations: [],
            reservationsOnDate: []
        }
    },
    methods: {
        async getReservations() {
            const response = await fetch("https://localhost:5001/api/reservations/");
            this.reservations = await response.json();
        }
    },
    async created() {
        await this.getReservations();
    },
    watch: {
        reservationDate(newDate) {
            let resDate = moment(newDate);
            this.reservationsOnDate = [];
            for(let reservation of this.reservations) {
                let date = moment(reservation.startTime);
                reservation.formattedStart = moment(reservation.startTime).format("Do MMMM YYYY, HH:mm")
                reservation.formattedEnd = moment(reservation.endTime).format("Do MMMM YYYY, HH:mm")
                if(resDate.isSame(date, "day")) {
                    this.reservationsOnDate = [...this.reservationsOnDate, reservation]
                }
            }
        }
    }
}
</script>

<style scoped>

</style>