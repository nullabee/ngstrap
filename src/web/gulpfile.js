/// <binding BeforeBuild='lib' />
"use strict";

var gulp = require("gulp"),
    series = require('stream-series'),
    inject = require('gulp-inject'),
    wiredep = require('wiredep').stream;

var webroot = "./wwwroot/";

var paths = {
    ngModule:       webroot + "app/**/*.module.js",
    ngRoute:        webroot + "app/**/*.route.js",
    ngService:      webroot + "app/**/*.service.js",
    ngController:   webroot + "app/**/*.controller.js",
    script:         webroot + "js/**/*.js",
    style:          webroot + "css/**/*.css"
};

gulp.task('injector', function () {
    var moduleSrc = gulp.src(paths.ngModule, { read: false });
    var routeSrc = gulp.src(paths.ngRoute, { read: false });
    var serviceSrc = gulp.src(paths.ngService, { read: false });
    var controllerSrc = gulp.src(paths.ngController, { read: false });
    var scriptSrc = gulp.src(paths.script, { read: false });
    var styleSrc = gulp.src(paths.style, { read: false });

    gulp.src(webroot + 'app/index.html')
        .pipe(wiredep({
            bowerJson: require('./../../bower.json'),
            directory: webroot + 'vendor/',
            optional: 'configuration',
            goes: 'here',
            ignorePath: '..',
            overrides: {
                angular: { main: ["angular.min.js"] },
                bootstrap: { main: ["dist/css/bootstrap.min.css"] },
                jquery: { main: ["dist/jquery.min.js"] },
            }
        }))
        .pipe(inject(series(scriptSrc, moduleSrc, serviceSrc, controllerSrc, routeSrc), { ignorePath: '/wwwroot' }))
        .pipe(inject(series(styleSrc), { ignorePath: '/wwwroot' }))
        .pipe(gulp.dest(webroot + 'app'));
});