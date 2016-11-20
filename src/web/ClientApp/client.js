require('es6-promise').polyfill()
﻿import './css/main.scss';
import './css/NRGNetwork/icon.css';
import './css/NRGNetwork/idangerous.swiper.css';
import './css/NRGNetwork/stylesheet.css';
import { vueApp } from './app'
import cookie from 'react-cookie';

vueApp(window.__INITIAL_STATE__).then(({ store, router, app }) => {
    //update the auth cookie -- it may have been set from server side
    cookie.save( store.state.authCookieName, JSON.stringify(store.state.user));

    // actually mount to DOM
    app.$mount('#app');
});

