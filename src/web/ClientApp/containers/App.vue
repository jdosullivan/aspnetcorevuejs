<template>
    <div class="page">
        <MainHeader></MainHeader>
        <!-- route outlet -->
        <!-- component matched by the route will render here -->
        <router-view></router-view>
    </div>
</template>

<script>
    import MainHeader from '../components/Header.vue'
    import { runPrefetch } from '../helper/routehelper'

    export default {
        components: {
            MainHeader
        },
        watch: {
            $route () {
               // runPrefetch(this.$router, this.$store);
            }
        }
    }
</script>