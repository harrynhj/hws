function checkEmailId(str) {
    if (str.includes("@") && str.includes(".")) {
        return true;
    }
    return false;
}

let email1 = "test@gmail.com";
let email2 = "testgmail.com";
console.log(checkEmailId(email1));
console.log(checkEmailId(email2));