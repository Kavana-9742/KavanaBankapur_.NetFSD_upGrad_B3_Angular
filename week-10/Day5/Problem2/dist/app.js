"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const student_service_1 = require("./services/student.service");
const utils_1 = require("./utils/utils");
const students = [
    { id: 1, name: "Kavana", marks: 85 },
    { id: 2, name: "Riya", marks: 92 },
    { id: 3, name: "Shravya", marks: 38 }
];
console.log("Formatted Names:");
students.forEach(s => {
    console.log((0, utils_1.formatName)(s.name));
});
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${(0, utils_1.formatName)(s.name)}: ${(0, student_service_1.getGrade)(s.marks)}`);
});
const avg = (0, utils_1.calculateAverage)(students);
console.log("\nAverage Marks:", avg);
const topper = (0, student_service_1.getTopper)(students);
console.log("\nTopper:", (0, utils_1.formatName)(topper.name), "-", topper.marks);
