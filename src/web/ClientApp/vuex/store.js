import Vue from 'vue';
import Vuex from 'vuex';
import { uploadImage, fetchGroup, fetchGroups, saveGroup, toggleNewGroupModal, deleteGroup } from './actions';
import { refreshAccessToken, getUserInfo, getToken, login, signup, logout } from './userActions';
import cookie from 'react-cookie';
import { ApiClient } from '../helper/apiclient';

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {  
        user: { authenticated: false },
        showNewGroupModal: false,
        currentGroup: { },
        groups: []
    },

    mutations: {
        GET_TOKEN_SUCCESS: (state, tokens) => {
            var expireTime = new Date();
            expireTime.setSeconds(expireTime.getSeconds() + tokens.expires_in - 20); //20 second buffer
            tokens.expires = expireTime.getTime();

            state.user = Object.assign({}, state.user, tokens);
            cookie.save( state.authCookieName, JSON.stringify(tokens));
        },
        GET_USER_INFO: (state, userInfo) => {
            state.user = Object.assign({}, state.user, {name: userInfo.name, email: userInfo.email, authenticated: true });
        },
        LOGOUT: (state) => {
            state.user = {}
        },
        FETCH_GROUP: (state, group) => {
            state.currentGroup = group;
        },
        FETCH_GROUPS: (state, groups) => {
            state.groups = groups;
        },
        SAVE_GROUP: (state, group) => {
            state.groups.unshift(group);
        },
        DELETE_GROUP: (state, group) => {
            var i = state.groups.indexOf(group);
            if(i !== -1) {
                state.groups.splice(i, 1);
            }
        },
        TOGGLE_NEW_GROUP_MODAL: (state) => {
            state.showNewGroupModal = !state.showNewGroupModal;
        }
    },

    actions: {
        uploadImage,
        login,
        signup,
        getUserInfo,
        getToken,
        logout,
        fetchGroup,
        fetchGroups,
        saveGroup,
        deleteGroup,
        toggleNewGroupModal,
        refreshAccessToken
    },

    getters: {       
        user: state => state.user,
        showNewGroupModal: state => state.showNewGroupModal,
        groups: state => state.groups,
        currentGroup: state => state.currentGroup,
        apiUrl: state => state.api_url,
        apiClient: (state) => { 
            return new ApiClient(state);
        }
    }
});

export default store;