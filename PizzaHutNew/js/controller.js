'use strict';


// - store: contains the pizza list
// - cart: the shopping cart object
// - order: containg user name, address, phone, and list of pizzas he wants to buy
function storeController($scope, $routeParams, $location, $http, DataService, pizzaService) {

    // get store and cart from service
    $scope.store = DataService.store;
    $scope.cart = DataService.cart;
    $scope.order = DataService.order;

    // use routing to pick the selected pizza
    if ($routeParams.pizzaId != null) {
        $scope.pizza = $scope.store.getPizza($routeParams.pizzaId);
    }

    //getting pizza list from api/api/pizza
    $scope.store.pizzas = 
    {
       id : "" ,
       name : "",
       ingridients : "",
       price : ""
    }

    pizzaService.getPizzas($scope)

    

    //for going to link after ng-click
    $scope.go = function (path) {
        $location.path(path);
    };

}


//doesnt make get request
function otherController($scope, $routeParams, $location, $http, DataService, pizzaService) {

    // get store and cart from service
    $scope.store = DataService.store;
    $scope.cart = DataService.cart;
    $scope.order = DataService.order;

    // use routing to pick the selected pizza
    if ($routeParams.pizzaId != null) {
        $scope.pizza = $scope.store.getPizza($routeParams.pizzaId);
    }

    //for going to link after ng-click
    $scope.go = function (path) {
        $location.path(path);
    };

}