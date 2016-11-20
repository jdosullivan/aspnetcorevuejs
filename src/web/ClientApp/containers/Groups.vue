<template>
    <div id="groups_page">
        <Banner v-if="!user.authenticated"></Banner>
        <div class="container custom-container">
            <div class="row">
                <div class="col-md-12">
                    <FilterBar />
                    <NewGroupModal v-if="showNewGroupModal"  @close="toggleNewGroupModal" />
                    <div id="container-mix" class="row _post-container_">                       
                        <GroupBox v-for="grp in groups" :key="grp.id" :group="grp" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import Banner from '../components/Banner.vue'
import FilterBar from '../components/FilterBar.vue'
import Categories from '../components/Categories.vue'
import Tags from '../components/Tags.vue'
import GroupBox from '../components/GroupBox.vue'
import NewGroupModal from '../components/NewGroupModal.vue'
import { mapGetters, mapActions } from 'vuex'

export default {  
    name: `groups-view`,
    components: { NewGroupModal, Banner, FilterBar, Categories, Tags, GroupBox },
    computed: { ...mapGetters(['groups', 'showNewGroupModal', 'user']) },
    methods: { 
        ...mapActions(['fetchGroups', 'toggleNewGroupModal', 'deleteGroup'])
    },
    preFetch (store) {
        return store.dispatch('fetchGroups')        
    },
}
</script>
