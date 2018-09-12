const webpack = require('webpack');
var path = require('path');
//const ExtractTextPlugin = require('extract-text-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = [
    {
        entry: {
            'bundle': './ClientApp/app.js',
        },

        mode: 'development',

        output: {
            path: path.resolve('./wwwroot'),
            filename: '[name].js'
        },

        resolve: {
            extensions: [".webpack.js", ".web.js", ".mjs", ".js", ".json"]
        },

        module: {
            rules: [
                {
                    test: /\.js/, use: [{
                        loader: 'babel-loader'
                    }], exclude: /node_modules/
                },
                /*{
                    test: /\.css$/, use: ExtractTextPlugin.extract({
                        fallback: "style-loader",
                        use: "css-loader"
                    })
                },*/
                {
                    test: /\.css$/,
                    use: [
                        {
                            loader: MiniCssExtractPlugin.loader,
                            options: {
                                // you can specify a publicPath here
                                // by default it use publicPath in webpackOptions.output
                                publicPath: '../'
                            }
                        },
                        "css-loader"
                    ]
                },
                {
                    test: /\.flow/, use: [{
                        loader: 'ignore-loader'
                    }]
                },
                {
                    test: /\.mjs$/,
                    include: /node_modules/,
                    type: "javascript/auto",
                }
            ]
        },

        plugins: [
            //new ExtractTextPlugin('style.css', { allChunks: true })
            new MiniCssExtractPlugin({
                // Options similar to the same options in webpackOptions.output
                // both options are optional
                filename: "[name].css",
                chunkFilename: "[id].css"
            })
        ]
    }
];