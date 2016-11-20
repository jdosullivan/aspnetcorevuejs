module.exports = {
    module: {
        loaders: [
         { test: /\.(s?)css$/i, loaders: ["style", "css", "sass"] },
         { test: /\.less$/, loaders: ["style", "css", "less"] },
        ]
    },
    devtool: 'inline-source-map'
};
