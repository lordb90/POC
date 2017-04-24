var Q = require("Q");
var azure = require("azure");

module.exports = function (config) {

    var retryOperations = new azure.ExponentialRetryPolicyFilter();
    var queueService = azure.createQueueService(config.storageName, config.storageKey)
        .withFilter(retryOperations);
    var singleMessageDefaults = { numofmessages: 1, visibilitytimeout: 2 * 60 };

    var getSingleMessage = function () {
        var deferred = Q.defer();
        queueService.getMessages(config.queueName, singleMessageDefaults,
            getSingleMessageComplete(deferred));
        return deferred.promise;
    };

    var deleteMessage = function (message) {
        var deferred = Q.defer();
        queueService.deleteMessage(config.queueName, message.messageid,
            message.popreceipt, deleteComplete(deferred));
        return deferred.promise;
    };

    var getSingleMessageComplete = function (deferred) {
        return function (error, messages) {
            if (error) {
                deferred.reject(error);
            } else {
                if (messages.length) {
                    deferred.resolve(messages[0]);
                } else {
                    deferred.resolve();
                }
            }
        };
    };

    var deleteComplete = function (deferred) {
        return function (error) {
            if (error) {
                deferred.reject(error);
            } else {
                deferred.resolve();
            }
        };
    };

    return {
        getSingleMessage: getSingleMessage,
        deleteMessage: deleteMessage
    };
};