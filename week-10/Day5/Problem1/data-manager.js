"use strict";
//Generic Function
function getFirstElement(items) {
    return items[0];
}
//Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
const userManager = new DataManager();
const productManager = new DataManager();
userManager.add({ id: 1, name: "Kavana" });
userManager.add({ id: 2, name: "Riya" });
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });
const users = userManager.getAll();
const products = productManager.getAll();
console.log("Users:", users);
console.log("Products:", products);
console.log("First User:", getFirstElement(users));
console.log("First Product:", getFirstElement(products));
