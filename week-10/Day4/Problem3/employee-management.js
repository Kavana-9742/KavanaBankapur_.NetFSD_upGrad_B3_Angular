class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    getSalary() {
        return this.salary;
    }
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    displayDetails() {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }
    displayDetails() {
        super.displayDetails();
        console.log(`Team Size: ${this.teamSize}`);
    }
}
const emp1 = new Employee(1, "Kavana", 30000);
emp1.displayDetails();
emp1.setSalary(35000);
console.log(`Updated Salary: ${emp1.getSalary()}`);
console.log("----------------------");
const mgr1 = new Manager(2, "Riya", 50000, 5);
mgr1.displayDetails();
export {};
