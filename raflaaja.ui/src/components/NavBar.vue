<template>
    <ul>
        <li><router-link to="/">{{ $t("message.home") }}</router-link></li>
        <li><router-link to="/menu">{{ $t("message.menu") }}</router-link></li>
        <li><router-link to="/reservations">{{ $t("message.reserve") }}</router-link></li>
        <li><router-link to="/shoppingcart">{{ $t("message.orders") }}</router-link></li>
        <li v-if="$i18n.locale === 'en'" @click="setLocale('fi')"><a>Finnish</a></li>
        <li v-if="$i18n.locale === 'fi'" @click="setLocale('en')"><a>English</a></li>
    </ul>
</template>

<script>
export default {
    name: "NavBar",
    methods: {
        setLocale(locale) {
        this.$i18n.locale = locale
        this.$router.push({
          params: { lang: locale }
        })
        this.hideDropdown()
      }
    }
}
</script>


<style scoped>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #3a3a3a;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    z-index: 100;
    display: flex;
    justify-content: center;
}

li {
    float: left;
}

li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover {
    background-color: #111;
    transition: .3s;
}
</style>