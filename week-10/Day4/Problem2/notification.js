//Required Parameter
function getWelcomeMessage(userName) {
    return `Welcome ${userName}!`;
}
//Optional Parameter
function getUserInfo(userName, age) {
    return age !== undefined
        ? `User ${userName} is ${age} years old`
        : `User ${userName} has not provided age`;
}
//Default Parameter
function getSubscriptionStatus(userName, isSubscribed = false) {
    return isSubscribed
        ? `${userName} is subscribed`
        : `${userName} is not subscribed`;
}
function checkPremiumEligibility(age) {
    return age > 18;
}
const getAccountUpdate = (userName) => {
    return `Hello ${userName}, your account is updated`;
};
const notificationService = {
    appName: "NotifyApp",
    sendNotification: (userName) => {
        return `Hello ${userName}, welcome to ${notificationService.appName}`;
    }
};
const userName = "Kavana";
console.log(getWelcomeMessage(userName));
console.log(getUserInfo(userName, 23));
console.log(getUserInfo(userName));
console.log(getSubscriptionStatus(userName, true));
console.log(getSubscriptionStatus(userName));
console.log(`Eligible: ${checkPremiumEligibility(20)}`);
console.log(getAccountUpdate(userName));
console.log(notificationService.sendNotification(userName));
export {};
