import { vueApp } from './app'
import { runPrefetch } from './helper/routehelper'


export default (context) => {
    return new Promise((resolve, reject) => {       
        return vueApp(context).then(({ store, router, app }) => { 
            // set router's location
            router.push(context.url);

            const prefetchAction = () => {
               return runPrefetch(router, store).then(() => {
                    // After all preFetch hooks are resolved, our store is now
                    // filled with the state needed to render the app.
                    // Expose the state on the render context, and let the request handler
                    // inline the state in the HTML response. This allows the client-side
                    // store to pick-up the server-side state without having to duplicate
                    // the initial data fetching on the client.
                    context.initialState = store.state;           
                    resolve(app);
                });
            };

            if (store.state.user.access_token) {
                return store.dispatch(`getUserInfo`).then(() => {
                    prefetchAction();
                });
            } else {
                prefetchAction();  
            }
        });
    });
}
