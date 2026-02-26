class Payment {
    pay(amount) {
        console.log(`Processing payment of ₹${amount}`);
    }
}

class CreditCardPayment extends Payment {
    pay(amount) {
        console.log(`Paid ₹${amount} using Credit Card`);
    }
}

class UPIPayment extends Payment {
    pay(amount) {
        console.log(`Paid ₹${amount} using UPI`);
    }
}

class CashPayment extends Payment {
    pay(amount) {
        console.log(`Paid ₹${amount} using Cash`);
    }
}

const creditPayment = new CreditCardPayment();
const upiPayment = new UPIPayment();
const cashPayment = new CashPayment();

creditPayment.pay(500);
upiPayment.pay(300);
cashPayment.pay(1000);