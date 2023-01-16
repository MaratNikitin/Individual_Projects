class Book {
    // constructor for the method:
    constructor(
        name,
        author,
        year,
        price,
        isNew
    ){
        this.name = name;
        this.author = author;
        this.year = year;
        this.price = price;
        this.isNew = isNew;
    }

    // method of the class:
    countYearsOld(year){
        let currentDate = new Date();
        let currentYear = currentDate.getFullYear();
        let booksYear = parseInt(this.year);
        let yearsOld = currentYear - booksYear;
        console.log(`This book is called "${this.name}" and is ${yearsOld} years old.`);
    }
}

export default Book;