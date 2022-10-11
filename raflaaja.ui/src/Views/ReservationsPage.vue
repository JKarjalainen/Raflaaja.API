<template>
    <nav-bar></nav-bar>
  <div class="hero-image">
    <div class="hero-text">
      <h1 style="font-size:50px; -webkit-text-stroke: 1.5px black;" >Varaa pöytä</h1>
    </div>
  </div>
  <div class="varaus">
    <h3>Päivänmäärä</h3>
    <input type="date" v-model="reservationDate" />
    <h3>Kellonaika</h3>
    <input type="time" min="09:00" max="22:00" v-model="reservationTime"/>
    <h3>Pöytä</h3>
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
    <br>
    <br>
    <br>
  </div>
  <footer-bar></footer-bar>

</template>

<script>
import NavBar from "@/components/NavBar";
import moment from "moment";
import swal from "sweetalert";
import FooterBar from "@/components/FooterBar";
export default {
    name: "ReservationsPage",
    components: {NavBar,FooterBar},
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
.varaus {
  text-align: center;
}
.hero-image {
  background-image: url("@/assets/Table.jpg");
  background-color: #cccccc;
  height: 400px;
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
  font-size: 30px;
}
input, select {
  width: 51%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

button {
  font-family:Helvetica;
  font-size: 20px;
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