// Creating an array with several items:
let myArray = ["book", 5, "pencil", true, "Friday", 1954, "green"];
console.log(`The initial array is: ${myArray.join(", ")}`);

// Removing the last item:
myArray.pop();
console.log(`The array with the last item removed: ${myArray.join(", ")}`);

// Moving the last item to the first position:
let lastItem = myArray[myArray.length-1];
myArray.pop();
myArray.unshift(lastItem);
console.log(`The array with the last moved into the first position: ${myArray.join(", ")}`);

// Sorting the items alphabetically:
myArray.sort();
console.log(`The array sorted alphabetically: ${myArray.join(", ")}`);

// Finding if a specific item is in the array:
valueToBeFound = 1954;
console.log(`The array contains the searched value ${valueToBeFound}: ${myArray.includes(valueToBeFound)}`);

// Removing a specific item from the array:
const indexToDelete = myArray.indexOf("book");
if (indexToDelete > -1) { // only splice when an item is found
    myArray.splice(indexToDelete, 1) // 2nd parameter means remove 1 item only
}
console.log(`The array with the "book" element removed: ${myArray.join(", ")}`);
