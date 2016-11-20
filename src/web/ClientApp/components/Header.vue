<template>
    <header>
        <div class="container-fluid custom-container">
            <div class="row no_row row-header">
                <div class="brand-be">
                    <a href="/"><img class="logo-c active be_logo" src="../assets/images/logo.png" alt="logo"></a>
                </div>
                <div class="header-menu-block">
                    <button class="cmn-toggle-switch cmn-toggle-switch__htx"><span></span></button>
                    <ul class="header-menu" id="one" style="max-height: 481px;">
                        <li><router-link to="/">Home</router-link></li>
                        <li><router-link to="/discover">Discover Groups</router-link></li>
                        <li v-if="user.authenticated"><a href="#" @click.prevent="logoutAndRedirect">Logout</a></li>
                        <li v-if="!user.authenticated"><router-link to="/login">Login</router-link></li>
                        <li v-if="!user.authenticated"><router-link to="/signup">Sign Up</router-link></li>
                        <li v-if="user.authenticated">
                            <a id="add-work-btn" class="btn color-1" href="#" @click.stop="toggleNewGroupModal">Create Group </a>
                        </li>
                        <li v-if="user">{{user.name}}</li>
                    </ul>
                </div>
            </div>
        </div>
    </header>
</template>


<script>
    import { mapGetters, mapActions } from 'vuex'
    
    export default {
        methods: { ...mapActions(['toggleNewGroupModal', 'logout']), 
               logoutAndRedirect() {
                   var vm = this;
                   this.logout().then(() => {
                       if (vm.$route.meta.requiresAuth) {
                           vm.$router.push('/');
                       }
                   });     
               } 
        },
        computed: { ...mapGetters(['user']) }
    }
</script>