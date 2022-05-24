/* Marat Nikitin, CPRG 210 - Web Application Concepts, Day 8-13 Node.js - Daily Exercises, November 2021 */

/* This file is used for Assignments 4-5 */

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
    console.log("Server started on port 8000 using the index-ejs.js file from the 'sait-express2' folder"); 
});

/* Random greetings are generated inside the index.ejs file - it's a legacy of doing the "Assignment 2: Node Modules". */

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

app.post("/register", (request,response)=> {
    console.log(request.body); /* Data from the form will be posted as an object in the Node.js Command Prompt. */
    response.render(__dirname + "/views/thankyou.ejs"); /* A user is redirected to a customised Thank You page */
 });

 /* Connection to the travelexperts database is created */
 var getConnection = ()=>{
     return mysql.createConnection({
         host: "localhost",
         user: "Marat",
         password: "Marat", /* Make sure that this user with precisely this password is authorised at phpMyAdmin */
         database: "travelexperts"
     });
 }
 
/* Data is retrieved from the database using an sql query:*/
app.get("/getpackages", (req, res)=>{
     var conn = getConnection();
     conn.connect((err)=>{
         if (err) throw err;
         
         var sql = "select * from packages"; 
         conn.query(sql, (err, result, fields)=>{
             if (err) throw err;
             
             res.render("index-mysql", { result: result }); /* index-mysql.ejs file is used to display the information 
                about packages comprehensively */
             conn.end((err)=>{
                 if (err) throw err;
             });
         });
     });
});

/* Below I set that if a requested url can not be accessed because of an Error 404, then 
	a customised page404.html is displayed to inform a user about this error. */

app.use((req, res)=>{
    res.status(404).render("page404");
});
