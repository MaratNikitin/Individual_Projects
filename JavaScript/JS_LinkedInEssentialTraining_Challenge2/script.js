const navigationBarContent = `
<style>
.topnav {
    //background-color: #999;
    overflow: hidden;
  }
  
  /* Style the links inside the navigation bar */
  .topnav a {
    float: right;
    color: #00008B;
    text-align: center;
    padding: 10px 25px;
    text-decoration: none;
    font-size: 17px;
  }
  
  /* Change the color of links on hover */
  .topnav a:hover {
    background-color: #ddd;
    color: black;
  }
  
  /* Add a color to the active/current link */
  .topnav a.active {
    background-color: #04AA6D;
    color: white;
  }
</style>
<div class="topnav">
  <a href="#contact">Contact</a>
  <a href="#news">News</a>
  <a href="#about">About</a>
  <a class="active" href="#home">Home</a>
</div>
`;

const main = document.querySelector("body");
const newArticleElement = document.createElement("article");
newArticleElement.innerHTML = navigationBarContent;

main.prepend(newArticleElement);