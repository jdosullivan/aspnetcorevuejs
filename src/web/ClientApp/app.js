import Vue from 'vue';
import VueRouter from 'vue-router';
import App from './containers/App.vue';
import Groups from './containers/Groups.vue';
import store from './vuex/store.js';
import { routes } from './routes';
import * as filters from './filters';
import { sync } from 'vuex-router-sync';

export const vueApp = (newState) => {
    return new Promise((resolve, reject) => {
        Vue.use(VueRouter);
    
        // prime the store with server-initialized state.
        // the state is determined during SSR and inlined in the page markup.
        store.replaceState(Object.assign({}, store.state, newState)); // Merge with the state from the server

        // register global utility filters.
        Object.keys(filters).forEach(key => {
            Vue.filter(key, filters[key])
        })

        const router = new VueRouter({
            mode: 'history',
            routes
        });

        // sync the router with the vuex store.
        // this registers `store.state.route`
        sync(store, router);

        const app = new Vue({
            router,
            store, 
            ...App
        });
        
        resolve({ app, store, router });
    });
}