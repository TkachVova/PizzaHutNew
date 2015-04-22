'use strict';
//heart of pizzahut app

var storeApp = angular.module('PizzaStore', ['720kb.socialshare']).
    config(['$routeProvider', function($routeProvider) {
    $routeProvider.
        when('/store', {
        templateUrl: 'partials/store.htm',
        controller: storeController 
        }).
        when('/pizza/:pizzaId', {
        templateUrl: 'partials/pizza.htm',
        controller: otherController
        }).
        when('/cart', {
        templateUrl: 'partials/shoppingCart.htm',
        controller: otherController
        }).
        when('/order', {
            templateUrl: 'partials/order.htm', 
            controller: otherController
        }).
        when('/thanks', {
            templateUrl: 'partials/thanks.htm'
           // controller: otherController
        }).
        otherwise({
        redirectTo: '/store'
        });
}]);



// create a data service that provides a store and a shopping cart that
// will be shared by all views 
storeApp.factory("DataService", function () {

    // create store
    var myStore = new store();

    // create shopping cart
    var myCart = new shoppingCart("PizzaStore");

    var myOrder = new order();

    // return data object with store and cart
    return {
        store: myStore,
        cart: myCart,
        order: myOrder
    };
});

//getting pizzas service
storeApp.service('pizzaService', ['$http', function ($http)
{
    this.getPizzas = function ($scope)
    {
        return $http({
            method: "GET",
            url: "../api/api/pizza",
            headers: {
                'Content-Type': 'application/json'
            }
        }).
        success(function (data)
        {
            $scope.store.pizzas = data;
        }).
        error(function (data)
        {
            alert("Some error occured");
        });;
    };
}]);



//filter for slicing string from some position to the end
storeApp.filter('startFrom', function () {
    return function(input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});

//filter for slicing stint from pos start to pos end
storeApp.filter('slice', function () {
    return function (arr, start, end) {
        start = +start;
        end = +end;
        return arr.slice(start, end);
    };
});

//filter for making cut of text and putting "..." after it. Used in small discription of pizza 
//in the main page/ option wordwise for not to cut half of the word if possible, if wordwise == false, we can cut half of the word.
storeApp.filter('cut', function () {
    return function (value, wordwise, max, tail) {
        if (!value) return '';

        max = parseInt(max, 10);
        if (!max) return value;
        if (value.length <= max) return value;

        value = value.substr(0, max);
        if (wordwise) {
            var lastspace = value.lastIndexOf(' ');
            if (lastspace != -1) {
                value = value.substr(0, lastspace);
            }
        }

        return value + (tail || ' …');
    };
});



