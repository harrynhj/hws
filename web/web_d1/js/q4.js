function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.slice(0, maxlength - 1) + "…";
    }
    return str;
}

let str = "Hello, world!";
let maxLength = 10;
console.log(truncate(str, maxLength));