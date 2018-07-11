
require.config({
    baseUrl: '',
    paths: {
        //'jquery': 'Scripts/jquery-1.10.2.min',
        //'knockout': 'Scripts/knockout-3.1.0.debug',
        'text': 'bower_components/text/text',
    },
    shim: {
        jquery: {
            exports: '$'
        },
        knockout: {
            exports: "ko"
        },
    }
});

// Start the app: 
require(['app'], function (app) {
    app.start();
});

