module.exports = function(config) {
  config.set({
    autoWatch: true,
    reporters: ['progress', 'notify'],
    frameworks: ['jasmine'],
    browsers: ['Chrome'],
    files: [
      "src/**/*.js",
      "spec/**/*.js"
    ],

    notifyReporter: {
      reportEachFailure: false, // Default: false, Will notify on every failed sepc
      reportSuccess: true, // Default: true, Will notify when a suite was successful
    }  });
};
