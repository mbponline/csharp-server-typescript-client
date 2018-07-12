
require.config({
    baseUrl: '',
    paths: {
        //'jquery': 'Scripts/jquery-1.10.2.min',
        'jasmine': 'bower_components/jasmine-core/lib/jasmine-core/jasmine',
        'jasmine-html': 'bower_components/jasmine-core/lib/jasmine-core/jasmine-html',
        'jasmine-boot': 'bower_components/jasmine-core/lib/jasmine-core/boot'

    },
    shim: {
        'jasmine-html': {
            deps: ['jasmine']
        },
        'jasmine-boot': {
            deps: ['jasmine', 'jasmine-html']
        }
    }
});

// // Start the app: 
// require(['src/app', 'jasmine-boot'], function (app) {
//   app.start();
// });

require(['jasmine-boot'], function () {
    require(['spec/Modules/dataService'], function () {
        //trigger Jasmine
        window.onload(undefined);
    })
});