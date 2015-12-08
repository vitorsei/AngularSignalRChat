angular.module('app').controller('mainCtrl', function ($scope, chat, toastr) {
    $scope.messages = [];

    $scope.inRoom = false;
    $scope.nameSet = false;

    $scope.setName = function () {
        $scope.nameSet = true;
    }

    $scope.joinRoom = function () {
        $scope.inRoom = true;
        chat.server.joinRoom($scope.roomName, $scope.name);
    }

    $scope.leaveRoom = function () {
        $scope.inRoom = false;
        chat.server.leaveRoom($scope.roomName, $scope.name);
    }

    $scope.sendMessage = function () {
        chat.server.sendMessage({ name: $scope.name, message: $scope.newMessage, roomName: $scope.roomName });
        displayMessage("You: " + $scope.newMessage);
        $scope.newMessage = "";
    };

    chat.client.newMessage = onNewMessage;

    function onNewMessage(message) {
        displayMessage(message);
        $scope.$apply();
        console.log(message);
    };

    function displayMessage(message) {
        $scope.messages.push({ message: message });
    }

    chat.client.newNotification = function onNewNotification(notification) {
        toastr.success(notification);
    }
});