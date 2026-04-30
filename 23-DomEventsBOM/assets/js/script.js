let inputOne = document.querySelector(".first-input");
let inputTwo = document.querySelector(".second-input");
let total = document.querySelector("#result");
let sumBtn = document.querySelector("#plus");
let subBtn = document.querySelector("#minus");
let multBtn = document.querySelector("#mult");
let divBtn = document.querySelector("#divide");

function ResetInput() {
    inputOne.value = "";
    inputTwo.value = "";
}
function CheckInputvalue() {
    let isBadInput1 = inputOne.validity.badInput;
    let isBadInput2 = inputTwo.validity.badInput;    
    let val1 = inputOne.value.trim();
    let val2 = inputTwo.value.trim();

    if (isBadInput1 || isBadInput2) {
        alert("Wrong input type, only numbers!");
        return false;
    }
    if (val1 === "" || val2 === "") {
        alert("You can't leave input empty!");
        return false;
    }
    return true;
}
function Sum() {
    if (CheckInputvalue() === false) {
        return;
    }
    let n1 = Number(inputOne.value);
    let n2 = Number(inputTwo.value);
    total.value = n1 + n2;
    ResetInput();
}
function Sub() {
    if (CheckInputvalue() === false) {
        return;
    }
    let n1 = Number(inputOne.value);
    let n2 = Number(inputTwo.value);
    total.value = n1 - n2;
    ResetInput();
}
function Mult() {
    if (CheckInputvalue() === false) {
        return;
    }
    let n1 = Number(inputOne.value);
    let n2 = Number(inputTwo.value);
    total.value = n1 * n2;
    ResetInput();
}
function Divide() {
    if (CheckInputvalue() === false) {
        return;
    }
    let n1 = Number(inputOne.value);
    let n2 = Number(inputTwo.value);
    if (n2 === 0) {
        alert("You cannot divide by zero!");
        ResetInput();
        return;
    }
    total.value = n1 / n2;
    ResetInput();
}
sumBtn.addEventListener("click", Sum);
subBtn.addEventListener("click", Sub);
multBtn.addEventListener("click", Mult);
divBtn.addEventListener("click", Divide);