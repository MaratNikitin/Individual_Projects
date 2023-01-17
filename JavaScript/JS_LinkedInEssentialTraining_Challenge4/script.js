/**
 * Challenge: Create an advanced function.
 * - Loop through backpackObjectArray to create an article with the class "backpack".
 * - Give the article the ID of the current backpack object.
 * - Set the inner HTML of the article to the existing HTML output provided in const content.
 * - Append each backpack object to the <main> element.
 */
import Backpack from "./components/Backpack.js";
import backpackObjectArray from "./components/data.js";

const everydayPack = new Backpack(
  "pack01",
  "Everyday Backpack",
  30,
  "grey",
  15,
  26,
  26,
  false,
  "December 5, 2018 15:00:00 PST",
  "../assets/images/everyday.svg"
);

function displayBackPack(backpack) {
  const content = `
    <h1>${backpack.name}</h1>
    <ul">
      <li>Volume:<span> ${
        backpack.volume
      }l</span></li>
      <li>Color:<span> ${
        backpack.color
      }</span></li>
      <li>Age:<span> ${backpack.backpackAge()} days old</span></li>
      <li>Number of pockets:<span> ${
        backpack.pocketNum
      }</span></li>
      <li>Left strap length:<span> ${
        backpack.strapLength.left
      } inches</span></li>
      <li">Right strap length:<span> ${
        backpack.strapLength.right
      } inches</span></li>
      <li>Lid status:<span> ${
        backpack.lidOpen ? "open" : "closed"
      }</span></li>
    </ul>
  
  `;

  const main = document.querySelector(".maincontent");

  const newArticle = document.createElement("article");
  newArticle.classList.add("backpack");
  newArticle.setAttribute("id", "everyday");
  newArticle.innerHTML = content;

  main.append(newArticle);
}

//displayBackPack(everydayPack);

console.log(backpackObjectArray);

for (const backpackItem of backpackObjectArray){
  displayBackPack(backpackItem);
}