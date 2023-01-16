import Book from "./Book.js";

const book1 = new Book(
    "First Things First",
    "Stephen R. Covey",
    1995,
    20.99,
    false,
)

console.log(book1);
console.log(`The book's year is ${book1.year}`);
book1.countYearsOld();