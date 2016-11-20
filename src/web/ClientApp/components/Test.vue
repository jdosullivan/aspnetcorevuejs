<template>
    <div>
        <a href="#">PlaceHGolder</a>
        <div><a @click="loginNow" href="#">Login</a></div>
        <div><a @click="logout" href="#">Logout</a></div>
        <div><a @click="getUserInfo" href="#">Get UserInfo</a></div>
        <div><a @click="refreshAccessToken" href="#">Refresh Token</a></div>
        <div class="values">
            <div>Token: {{ user.access_token }}</div>
            <div>Refresh: {{ user.refresh_token }}</div>
            <div>Name: {{ user.name }}</div>
        </div>
    </div>
</template>

<script>
    import { mapGetters, mapActions } from 'vuex';

    
    export default {
    methods: { ...mapActions(['getUserInfo', 'login', 'refreshAccessToken', 'logout']),
                loginNow() {
                    var credentials = { username: 'nwhybrid+1@gmail.com', password: 'Star2017' };
                    this.login(credentials);
                }
        },
        computed: { ...mapGetters(['user']) }
    }
</script>

<style>
    .values > div {
        margin-bottom: 20px;
    }
</style>