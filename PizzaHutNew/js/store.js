//store class
function store() {
    this.pizzas = [];
    this.filteredPizzas = [];
    this.currentPage = 0;
    this.pageSize = 6;  
}

store.prototype.getPizza = function (id) {
    for (var i = 0; i < this.pizzas.length; i++) {
        if (this.pizzas[i].id == id)
            return this.pizzas[i];
    }
    return null;
}

//get number of pages to provide filtering pagination
store.prototype.numberOfPages = function () {
    return Math.ceil(this.pizzas.length / this.pageSize);
}

store.prototype.goOnTop = function () {
    window.scrollTo(0, 0);
};


