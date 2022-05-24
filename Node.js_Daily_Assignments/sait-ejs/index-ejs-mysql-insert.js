/* Marat Nikitin, CPRG 210 - Web Application Concepts, Day 8-13 Node.js - Daily Exercises, November 2021 */

/* This file is used for Assignment 6 only: inserting values into MySQL "travelexperts" database using the registration form.
    I used a separate file for this assignment to avoid conflicts between Assignments 4 and 6, where the same registration 
    page is used for different purposes (console.log form data in Assignment 4 vs. insert data into database in Assignment 6). */

const express = require("express");
const app = express();
const mysql = require("mysql");
const http = require("http");
const fs = require("fs");

app.use(express.urlencoded({"extended": true}));

app.set("view engine", "ejs");

/* Placing this 'app.get("/"...' fragment ahead of 'app.use(express.static' allows to serve other files 
	than the default index.html file */
    
    app.get("/", (req, res) => { 
        res.render(__dirname + "/views/index.ejs");
        /* Code from header.ejs and footer.ejs files is inserted into the "/views/index.ejs" files & a wholesome 
            webpage made of three .ejs files is compiled as a result */
        console.log("A cascade of .ejs files is used at localhost:8000");
});

app.use(express.static("views", {extensions: ["html", "css", "js"]}));
app.use(express.static("media"));

app.listen(8000, ()=>{ 
    console.log("Server started on port 8000 using the index-ejs-mysql-insert.js file from the 'sait-express2' folder"); 
});

/* Below I described which files from which paths should be served when these corresponding url extensions are added 
	afer "localhost" in the address line of a browser */

app.get("/about", (req, res)=>{
    res.render(__dirname + "/views/about.ejs");
});

app.get("/register", (req, res)=>{
    res.render(__dirname + "/views/register.ejs");
});

app.get("/contact", (req, res)=>{
    res.render(__dirname + "/views/contact.ejs");
});

app.post("/register", (req, res)=>{
    res.render(__dirname + "/views/thankyou.ejs");
    console.log(req.body); // Data from the registration form will be posted as an object in the Node.js Command Prompt.
    const conn = mysql.createConnection({
        host: "localhost",
		user: "Marat",
		password: "Marat",
		database: "travelexperts"
    });
    conn.connect((err)=>{
        if (err) throw err;
        // Inserting customer information from the registration form into the Travel Experts database
        var insertCustomer = "insert into customers (CustFirstName, CustLastName, CustAddress,"
        + " CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId)"
        + " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        /* Registration form had to be updated by adding missing fields required in the database and hiding redundant 
            fields by commenting them out */
        conn.query(
            insertCustomer 
            [
                req.body.fname, req.body.lname, req.body.address, req.body.city, req.body.province, req.body.postalcode,
                req.body.country, req.body.phone, req.body.phone, req.body.email, req.body.agentid
                /* These are the fields from the registration form to be inserted in the 'customer' table of the 
                "travelexperts" MySQL database in the order described higher above, right after 'var insertCustomer = ...' */
            ], 
            (err, results, field)=>{
            if(err) throw err;
            conn.end((err)=>{
                if (err) throw err;
            });
        })
    });
});
 
/* Below I set that if a requested url can not be accessed because of an Error 404, then 
	a customised page404.html is displayed to inform a user about this error. */

app.use((req, res)=>{
    res.status(404).render("page404");
});
