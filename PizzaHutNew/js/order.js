// order class
function order() {
    this.client = new customer("-1", "", "");
    this.deliveryAddress = "";
    this.items = [];
}


//set items from cart to order after pressing button make order
order.prototype.SetItems = function (items) {
    this.items = items;
}


//Clear order after posting order
order.prototype.ClearOrder = function () {
    this.userName = "";
    this.userAddress = "";
    this.userPhone = "";
    this.items = [];
}

order.prototype.submit = function () {
}



//funktion for posting order
order.prototype.Post = function () {
    var testItems = localStorage != null ? localStorage["PizzaStore_items"] : null;
    var testItemsP = JSON.parse(testItems);
        //alert(JSON.stringify(this));
    //alert(testItems);
    //alert(testItemsP.length);
if (testItemsP.length > 0) {
    $.ajax({
        type: "POST",
        data: JSON.stringify(this),
        url: "api/api/pizza",
        contentType: "application/json"
    });
    this.ClearOrder();
}
else {
    alert("Error! You tried to cheat!");
}

//alert(JSON.stringify(Order));
};
 
//customer class
function customer(id, name, phone) {
    this.id = id;
    this.name = name;
    this.phone = ""+phone;
}

