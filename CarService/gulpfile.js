var gulp = require('gulp');
var less = require('gulp-less');

gulp.task('less', function () {
    return gulp.src('Styles/site.less') // only compile the entry file
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch', function () {
    gulp.watch('Styles/*.less', ['less']);  // Watch all the .less files, then run the less task
});

gulp.task('default', ['watch']); // Default will run the 'entry' watch task