const path = require('path');
const webpack = require('webpack');
const merge = require('extendify')({ isDeep: true, arrays: 'concat' });
var devConfig = require('./webpack.config.dev');
var prodConfig = require('./webpack.config.prod');
var isDevelopment = process.env.ASPNETCORE_ENVIRONMENT === 'Development';

const srcFileDirectory = path.join(__dirname, 'ClientApp');

var clientConfig = merge({
    entry: {
        main: path.join(srcFileDirectory, 'client.js')
    },    
    output: {
        path: path.join(__dirname, 'wwwroot', 'dist'),
        publicPath: '/dist/', // Webpack dev middleware, if enabled, handles requests for this URL prefix
        filename: 'bundle.client.js'
    },
    module: {
        loaders: [
         {
             test: /\.(png|jpg|svg)$/,
             loader: 'url?limit=25000'
         },
          { test: /\.woff($|\?)|\.woff2($|\?)|\.ttf($|\?)|\.eot($|\?)|\.svg($|\?)/, loader: 'url-loader' },
          { test: /\.vue$/, loader: 'vue' },
          { test: /\.js$/, loader: 'babel', include: __dirname, exclude: /node_modules/ }
        ]
    },
    plugins: [
    ]
}, isDevelopment ? devConfig : prodConfig);

var serverConfig = merge({
    target: 'node',
    entry: {
        main: path.join(srcFileDirectory, 'server.js')
    },
    output: {
        path: path.join(__dirname, 'wwwroot', 'dist'),
        publicPath: '/dist/', // Webpack dev middleware, if enabled, handles requests for this URL prefix
        libraryTarget: 'commonjs2',
        filename: 'bundle.server.js'
    },
    module: {
        loaders: [
            {
                test: /\.(png|jpg|svg)$/,
                loader: 'url?limit=25000'
            },
          { test: /\.woff($|\?)|\.woff2($|\?)|\.ttf($|\?)|\.eot($|\?)|\.svg($|\?)/, loader: 'url-loader' },
          { test: /\.vue$/, loader: 'vue' },
          { test: /\.js$/,  loader: 'babel',  include: __dirname,  exclude: /node_modules/ },
          {
              test: /\.json?$/,
              loader: 'json'
          }
        ]
    },
    plugins: [
     
    ]
}, isDevelopment ? devConfig : prodConfig);

module.exports = [clientConfig, serverConfig];