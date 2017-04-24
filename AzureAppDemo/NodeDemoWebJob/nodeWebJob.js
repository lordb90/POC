var config = require("./config.json");
var queue = require("./queue")(config);

var checkQueue = function () {
    queue.getSingleMessage()
        .then(processMessage)
        .catch(processError)
        .finally(setNextCheck);
};

var processMessage = function (message) {
    if (message) {
        console.dir(message);
        // processing commands, then ...
        return queue.deleteMessage(message);
    }
};

var processError = function (reason) {
    console.log("Error:");
    console.log(reason);
};

var setNextCheck = function () {
    setTimeout(checkQueue, config.checkFrequency);
};

checkQueue();