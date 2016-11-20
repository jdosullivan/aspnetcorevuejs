var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var extractCSS = new ExtractTextPlugin('site.css');

module.exports = {
    module: {
        loaders: [
            { test: /\.(s?)css$/i, loader: extractCSS.extract(['css', 'sass']) }
        ]
    },
    plugins: [
        extractCSS,
        new webpack.optimize.OccurenceOrderPlugin(),
        new webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } }),
        new webpack.DefinePlugin({ 'process.env.NODE_ENV': '"production"' })
    ]
};
