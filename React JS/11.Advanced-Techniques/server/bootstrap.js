require('ignore-styles');

require('@babel/helper-define-polyfill-provider');
require('babel-register')({
    ignore: [ /(node_modules)/ ],
    presets: ['@babel/preset-env', 'react-app']
});

require('./index');
