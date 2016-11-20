import axios from 'axios';
const isBrowser = typeof window !== 'undefined';
const methods = ['get', 'post', 'put', 'patch', 'del'];

class RequestClient {
    constructor(state) {
        methods.forEach( (method) =>
            this[method] = (path, dispatch, { data, headers } = {}, checkAccessToken = true) => new Promise( (resolve, reject) => {
                var instance = axios.create({
                    baseURL: state.api_url,
                    timeout: 30000,
                    headers
                });

                let retries = 1;
                const request = () => {
                    if (state.user.access_token && state.user.refresh_token != null) {
                        const authHeader = { authorization: 'Bearer ' + state.user.access_token };
                        headers = Object.assign({}, headers, authHeader);
                    } 
                                                            
                    instance[method](path, data ? data : { headers }, data && headers ? { headers } : undefined )
                         .then(response  => {
                             resolve(response);
                         }).catch( err => {
                             reject(err);
                         });
                };

                if (state.user.refresh_token && state.user.refresh_token !== null && checkAccessToken === true && state.user.expires < new Date().getTime() && (!data || data. grant_type !== "refresh_token")) {
                    dispatch(`refreshAccessToken`).then(() => {
                        request();
                    });
                } else {
                    request();
                }

                

            }));
    }
}

export const ApiClient = (state) => {
    return new RequestClient(state);
};