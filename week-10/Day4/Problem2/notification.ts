export {};

//Required Parameter
function getWelcomeMessage(userName: string): string {
    return `Welcome ${userName}!`;
}

//Optional Parameter
function getUserInfo(userName: string, age?: number): string {
    return age !== undefined
        ? `User ${userName} is ${age} years old`
        : `User ${userName} has not provided age`;
}

//Default Parameter
function getSubscriptionStatus(
    userName: string,
    isSubscribed: boolean = false
): string {
    return isSubscribed
        ? `${userName} is subscribed`
        : `${userName} is not subscribed`;
}

function checkPremiumEligibility(age: number): boolean {
    return age > 18;
}

const getAccountUpdate = (userName: string): string => {
    return `Hello ${userName}, your account is updated`;
};

const notificationService = {
    appName: "NotifyApp",

    sendNotification: (userName: string): string => {
        return `Hello ${userName}, welcome to ${notificationService.appName}`;
    }
};

const userName: string = "Kavana";

console.log(getWelcomeMessage(userName));
console.log(getUserInfo(userName, 23));
console.log(getUserInfo(userName));

console.log(getSubscriptionStatus(userName, true));
console.log(getSubscriptionStatus(userName));

console.log(`Eligible: ${checkPremiumEligibility(20)}`);

console.log(getAccountUpdate(userName));

console.log(notificationService.sendNotification(userName));