const path = require("path");

module.exports = {
    entry: ['./index.js', './src/test.js'],
    output: {
        filename: 'mybundle.js',
        path: path.resolve(__dirname, '../wwwroot/js')
    },
};