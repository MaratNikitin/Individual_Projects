/* Marat Nikitin, CPRG 210 - Web Application Concepts, Day 8-13 Node.js - Daily Exercises, November 2021 */
/* Assignments 1-3 solutions use this index.js file */

/* In the two lines of code below server using the Express app is required and then initialized */
const express = require("express");
const app = express();

const http = require("http");
const fs = require("fs");

/* Defining an array of paths to the files to be chosen randomly as default pages at localhost:8000. These pages
	differ only by indices (i.e. 0-3) in their <title> elements. Random greetings are displayed at the top parts of these
	webpages (right below the "Welcome to Travel Experts") and are generated using inline scripts inside those HTML files */
const filesArray = ["/views/index.html", "/views/index1.html", "/views/index2.html", "/views/index3.html"];
/* Random greetings are generated inside those index?.html files described above */

/* Placing this 'app.get("/"...' fragment ahead of 'app.use(express.static)' allows to serve other files 
	than the default index.html file */
/* Below be choose a random file to be displayed by default at localhost */
app.get("/", (req, res) => {
	var randomPath = filesArray[Math.floor(Math.random() * (filesArray.length))];
	console.log("The random path for a default localhost page is: " + randomPath); 
	/* This console.log above is used to demonstrate that choosing a random file when refreshing the default localhost address 
		indeed works. You can see a chosen random file's index in a title of a page. */ 
	res.sendFile(__dirname + randomPath);
});

/* Below we describe folders to be used to retrieve files from when displaying static pages */

app.use(express.static("views", { "extensions": ["html", "htm"] }));
// app.use(express.static("media"));

app.use(express.urlencoded( { extended: true }));

app.listen(8000, ()=>{ console.log("Server started on port 8000 using the index.js file from the 'sait-express' folder"); });

/* Below I described which files from which paths should be served when these corresponding url extensions are added 
	afer "localhost" in the address line of a browser */

app.get("/about", (req, res)=>{
	res.sendFile(__dirname + "/about.html");
});

app.get("/contact", (req, res)=>{
	res.sendFile(__dirname + "/contact.html");
});

app.get("/register", (req, res)=>{
	res.sendFile(__dirname + "/register.html");
});

/* Below I set that if a requested url can not be accessed because of an Error 404, then 
	a customised page404.html is displayed to inform a user about this error. */

app.use(function(req,res){
    res.status(404).sendFile(__dirname + "/views/page404.html");
});
