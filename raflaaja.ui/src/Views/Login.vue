<template>
<div id="page_container">
    <form>
        <h1>Kirjautuminen</h1>
        <div class="form-field">
            <label for="test">Käyttäjänimi</label>
            <input id="test" type="text">
        </div>
        <div class="form-field">
            <label for="test2">Salasana</label>
            <input id="test2" type="text">
        </div>
        <div id="submit_container">
            <input id="submit" type="submit" value="Kirjaudu">
        </div>
        <a href="/sign-up">Uupuuko käyttäjä?</a>

    </form> 
</div>  

</template>
<script>
/*
import NavBar from "@/components/NavBar";
components: {NavBar}
*/
    export default{
        name: "LoginPage"
    }
</script>
<style scoped>
    a{
        width: 100%;
        margin: auto;
        display: block;
        text-align: center;
        padding-top: 35px;
        color:#000;
        font-size: 18px;
    }
    #page_container{
        height:90vh;
        display: flex;
        align-items: center;
        justify-content: center;
        flex-direction: column;
    }
    .form-field{
        display: flex;
        flex-direction: column;
        margin: 20px 0px;
    }
    label{
        text-align: center;
        margin-bottom: 10px;
    }
    input[type="text"]{
        border: 3px solid #000;
    }
    input[type="text"]:focus-visible{
        border-color: rgb(15, 108, 221) !important;
        transition: .3s ease-in;
        outline: none !important;
    }
    form{
        width: 50%;
        margin: auto;
    }
    h1{
        text-align: center;
    }
    #submit_container{
        width:100%;
        display: flex;
        justify-content: center;
    }
    #submit{
        font-family:Helvetica;
        font-size: 30px;
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

</style>