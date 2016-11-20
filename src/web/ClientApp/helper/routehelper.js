export const runPrefetch = (router, store) => {
    return new Promise((resolve, reject) => {
        var components = router.getMatchedComponents();
        if (components.length > 0 && components[0].preFetch) {
            components[0].preFetch(store).then(() => { resolve() });
        } else {
            resolve();
        }
    });
};