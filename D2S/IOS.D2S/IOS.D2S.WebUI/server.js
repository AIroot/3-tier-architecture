'use strict';

// Module dependencies.
var express = require('express'),
    path = require('path'),
    cors = require('express-cors'),
    fs = require('fs'),
    methodOverride = require('method-override'),
    morgan = require('morgan'),
    bodyParser = require('body-parser');

var app = module.exports = exports.app = express();

app.locals.siteName = "IOS D2S";

app.use(express.static(__dirname + '/public'));

app.get('/*', function (req, res) {
    res.sendFile(__dirname + '/public/index.html');
});

app.use(methodOverride());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));

app.use(cors({
    allowedOrigins: [
        'http://localhost:33001/'
    ]
}))


// Start server
var port = process.env.PORT || 2500;
app.listen(port, function () {
    console.log('PMS server listening on port %d in %s mode', port, app.get('env'));
});
