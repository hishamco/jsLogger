var logLevel = {
    Trace: 0,
    Debug: 1,
    Information: 2,
    Warning: 3,
    Error: 4
};

function log(level, message) {
    $.post("log", { "level": level, "message": message });
};

(function () {
    var trace = console.trace;
    var debug = console.debug;
    var info = console.info;
    var warn = console.warn;
    var error = console.error;

    console.trace = function (message) {
        log(logLevel.Trace, message);
        trace.call(this, arguments);
    };

    console.debug = function (message) {
        log(logLevel.Debug, message);
        debug.call(this, arguments);
    };

    console.info = function (message) {
        log(logLevel.Information, message);
        info.call(this, arguments);
    };

    console.warn = function (message) {
        log(logLevel.Warning, message);
        warn.call(this, arguments);
    };

    console.error = function (message) {
        log(logLevel.Error, message);
        error.call(this, arguments);
    };
})();