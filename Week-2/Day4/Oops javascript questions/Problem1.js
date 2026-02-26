class Student {
    constructor(name, rollNumber, marks) {
        this.name = name;
        this.rollNumber = rollNumber;
        this.marks = marks;
    }

    getDetails() {
        console.log(`Name: ${this.name}`);
        console.log(`Roll Number: ${this.rollNumber}`);
        console.log(`Marks: ${this.marks}`);
    }

    getGrade() {
        if (this.marks >= 90) {
            return "A";
        } else if (this.marks >= 75 && this.marks <= 89) {
            return "B";
        } else if (this.marks >= 50 && this.marks <= 74) {
            return "C";
        } else {
            return "Fail";
        }
    }
}

const student1 = new Student("Kavana", 101, 92);
const student2 = new Student("Shravya", 102, 68);

console.log("Student 1 Details:");
student1.getDetails();
console.log("Grade:", student1.getGrade());

console.log("\nStudent 2 Details:");
student2.getDetails();
console.log("Grade:", student2.getGrade());