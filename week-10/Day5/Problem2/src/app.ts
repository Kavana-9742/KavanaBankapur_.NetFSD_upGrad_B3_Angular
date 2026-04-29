import { Student } from "./models/student.model";
import { getGrade, getTopper } from "./services/student.service";
import { formatName, calculateAverage } from "./utils/utils";

const students: Student[] = [
  { id: 1, name: "Kavana", marks: 85 },
  { id: 2, name: "Riya", marks: 92 },
  { id: 3, name: "Shravya", marks: 38 }
];

console.log("Formatted Names:");
students.forEach(s => {
  console.log(formatName(s.name));
});

console.log("\nGrades:");
students.forEach(s => {
  console.log(`${formatName(s.name)}: ${getGrade(s.marks)}`);
});

const avg = calculateAverage(students);
console.log("\nAverage Marks:", avg);

const topper = getTopper(students);
console.log("\nTopper:", formatName(topper.name), "-", topper.marks);