import querystring from 'querystring';
import { ApiClient } from '../helper/apiclient';
import cookie from 'react-cookie';
const isBrowser = typeof window !== 'undefined';

export const getToken = ({commit, state, dispatch, getters}, creds) => {
    return new Promise((resolve, reject) => {
        creds.scope = "offline_access";
        getters.apiClient.post(`connect/token`, dispatch, { data: querystring.stringify(creds), headers: { "Content-Type": "application/x-www-form-urlencoded" }}, false)
               .then(function(response) {
                   commit("GET_TOKEN_SUCCESS", response.data);
                   resolve();
               }).catch( err => {
                   reject(err);
               });
    });
}

export const getUserInfo = ({dispatch, commit, state, getters}, creds, redirect) => {
    return new Promise((resolve, reject) => {  
        getters.apiClient.get(`account/userinfo`, dispatch)
                      .then(response  => {
                          commit("GET_USER_INFO", response.data);
                          resolve();
                      }).catch((err) => { 
                          console.log(err);
                          resolve();
                      });
    });
}

function parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace('-', '+').replace('_', '/');
    return JSON.parse(new Buffer(base64, 'base64').toString());
};


export const login = ({dispatch, commit, state}, creds, redirect) => {
    return new Promise((resolve, reject) => {
        creds.grant_type = "password";
        dispatch('getToken', creds).then(() => {
            dispatch('getUserInfo').then(() => {
                resolve();
            });
        });        
    });
}

export const signup = ({dispatch, commit, state, getters}, creds) => {
    return new Promise((resolve, reject) => {
        getters.apiClient.post(`account/register`, dispatch, {data: creds }).then((response) => {
            dispatch('login', { username: creds.email, password: creds.password, 'grant_type': 'password' } ).then(() => {
                resolve();
            });           
        }).catch( err => {
            console.log(err);
        });
    });
}

export const logout = ({state, commit}) => {
    return new Promise((resolve, reject) => {  
        commit("LOGOUT");
        resolve();
    });
}

export const reloadUser = ({state, commit}) => {
    return new Promise((resolve, reject) => {  
        commit("RELOAD_USER");
        resolve();
    });
}



export const refreshAccessToken = ({state, commit, dispatch, getters}) => {
    return new Promise((resolve, reject) => {               
        var data = {
            grant_type: "refresh_token",
            refresh_token: state.user.refresh_token,
            scope: "offline_access"
        };

        getters.apiClient.post(`connect/token`, dispatch, {data: querystring.stringify(data), headers: { "Content-Type": "application/x-www-form-urlencoded" } }, false)
                .then((response) => {
                    commit("GET_TOKEN_SUCCESS", response.data);
                    resolve();
                })
                 .catch( err => {
                     dispatch('logout').then(() => {
                         resolve();
                     });
                 });

    });
}
    
