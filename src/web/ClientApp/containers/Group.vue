<template>
    <div :id="currentGroup.id" v-if="currentGroup">
        <div class="container be-detail-container">
            <h2 class="content-title">{{currentGroup.name}}</h2>
            <div>{{ currentGroup.description }}</div>
            <div class="blog-wrapper blog-list">
                <div class="blog-filter">
                    <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html" class="btn color-4 size-2 hover-9">concepts</a>
                    <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html" class="btn color-4 size-2 hover-9">drawing</a>
                    <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html" class="btn color-4 size-2 hover-9">streetart</a>
                    <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html" class="btn color-4 size-2 hover-9">new</a>
                    <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html" class="btn color-4 size-2 hover-9">people</a>
                </div>
                <Event />
            </div>
        </div>
    </div>
</template>

<script>
  import { mapGetters, mapActions } from 'vuex'
    import Event from '../components/Event.vue';

    export default {
    components: { Event },
        beforeRouteEnter (to, from, next) {
            next((vm) => {
                vm.fetchGroup(to.params.id)
                    .then(() => {
                        next(true);
                    }).catch( err => {
                        console.log(err);
                        next(false);
                    });
            });
        },
    // when route changes and this component is already rendered,
    // the logic will be slightly different.
    watch: {
        $route () {
            this.fetchGroup(this.$route.params.id)
                .catch( err => {
                    console.log(err);
                    next(false);
                });
        }
    },
    computed: mapGetters(['currentGroup', 'user']),
    methods: {
        ...mapActions(['fetchGroup'])
    }
}
</script>