//Generic Function
function getFirstElement<T>(items: T[]): T {
  return items[0];
}

//Generic Interface
interface Repository<T> {
  add(item: T): void;
  getAll(): T[];
}

//Generic Class
class DataManager<T> implements Repository<T> {
  private items: T[] = [];

  add(item: T): void {
    this.items.push(item);
  }

  getAll(): T[] {
    return this.items;
  }
}

//Models
interface User {
  id: number;
  name: string;
}

interface Product {
  id: number;
  title: string;
}

const userManager = new DataManager<User>();
const productManager = new DataManager<Product>();

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