let array = ["James", "Brennie"];
console.log(array);

array.push("Robert");
console.log(array);


let middleIndex = Math.floor(array.length / 2);
array[middleIndex] = "Calvin";
console.log(array);

array.shift();
console.log(array);


array.unshift("Rose", "Regal");
console.log(array);