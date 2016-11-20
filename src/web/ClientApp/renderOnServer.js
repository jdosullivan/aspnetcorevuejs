process.env.VUE_ENV = 'server';

const fs = require('fs');
const path = require('path');

const webpackConfig = require('../webpack.config');
const serverConfig = webpackConfig[1];


const outputPath = path.join(serverConfig.output.path, serverConfig.output.filename)
const bundleRenderer = require('vue-server-renderer').createBundleRenderer(fs.readFileSync(outputPath, 'utf-8'))

module.exports = function (params) {
    const context = Object.assign({}, params.data);
    return new Promise(function (resolve, reject) {
        bundleRenderer.renderToString(context, (err, resultHtml) => { // params.data is the store's initial state
            if (err) {
                reject(err.message);
            }
            resolve({
                html: resultHtml,
                globals: {
                    __INITIAL_STATE__: context.initialState // window.__INITIAL_STATE__ will be the initial state of the Vuex store
                }
            });
        });
    });
};
