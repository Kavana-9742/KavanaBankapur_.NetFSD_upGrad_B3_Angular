import { calculateCartTotal } from './exportfile.js';

const cartProducts = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 }
];

const totalAmount = calculateCartTotal(cartProducts);

const invoice = `
----------- INVOICE -----------
${cartProducts.map(product => 
    `${product.name} 
     Price: ₹${product.price} 
     Quantity: ${product.quantity} 
     Subtotal: ₹${product.price * product.quantity}`
).join("\n\n")}

-------------------------------
Total Cart Value: ₹${totalAmount}
-------------------------------
`;

document.getElementById("output").textContent = invoice;
