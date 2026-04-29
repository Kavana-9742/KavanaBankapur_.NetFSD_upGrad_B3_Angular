//Variable Declaration
const userName: string = "John";
let age: number = 25; // using let because we will update it
const email: string = "john@example.com";
const isSubscribed: boolean = true;

//Type Inference
let city = "Bangalore"; // inferred as string
let loginCount = 5;     // inferred as number

//Template Literal
let profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
console.log("Initial Profile:");
console.log(profileMessage);

//Operators

// Increment age by 1
age = age + 1;

// Check premium eligibility (age > 18 AND subscribed)
const isEligibleForPremium: boolean = age > 18 && isSubscribed;

// Comparison operator example
const isAdult: boolean = age >= 18;

//Updated Profile Message
profileMessage = `Hello ${userName}, now you are ${age} years old. Premium Eligible: ${isEligibleForPremium}`;

console.log("\nAfter Updating Age:");
console.log(profileMessage);

console.log("\nAdditional Details:");
console.log(`City: ${city}`);
console.log(`Login Count: ${loginCount}`);
console.log(`Is Adult: ${isAdult}`);
console.log(`Subscribed: ${isSubscribed}`);