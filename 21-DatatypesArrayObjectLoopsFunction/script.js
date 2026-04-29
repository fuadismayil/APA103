// 1. Arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek
function removeDuplicates(arr) {
    let newArr = [];
    let tekrarSayi = 0;
    for (let i = 0; i < arr.length; i++) {
        let varmi = false;
        for (let j = 0; j < newArr.length; j++) {
            if (arr[i] === newArr[j]) {
                varmi = true;
            }
        }
        if (varmi === false) {
            newArr.push(arr[i]);
        } else {
            tekrarSayi++;
        }
    }
    console.log("Tekrarsiz array:", newArr);
    console.log("Tekrar reqemlerin sayi:", tekrarSayi);
}
removeDuplicates([1, 2, 3, 2, 4, 5, 1, 6, 3]);

// 2. Verilmis sozun polindrom olub olmadigini yoxlamaq
function checkPalindrome(word) {
    let reverseWord = "";
    for (let i = word.length - 1; i >= 0; i--) {
        reverseWord += word[i];
    }
    if (word === reverseWord) {
        console.log(word + " polindromdur");
    } else {
        console.log(word + " polindrom deyil");
    }
}
checkPalindrome("ana");
checkPalindrome("salam");

// 3. Girilen ededin verilmis arrayde nece elementden kicik oldugunu tapmaq
function countBiggerElements(arr, number) {
    let count = 0;
    for (let i = 0; i < arr.length; i++) {
        if (number < arr[i]) {
            count++;
        }
    }
    console.log(number + " ededi arrayde " + count + " elementden kicikdir");
}
countBiggerElements([3, 8, 12, 5, 20, 1], 6);

// 4. Daxil edilen ededin Abundant ve ya Deficient oldugunu yoxlamaq
function checkNumber(number) {
    let sum = 0;
    for (let i = 1; i < number; i++) {
        if (number % i === 0) {
            sum += i;
        }
    }
    if (sum > number) {
        console.log(number + " Abundant ededdir");
    } else {
        console.log(number + " Deficient ededdir");
    }
}
checkNumber(12);
checkNumber(13);

// 5. Array-in butun elementlerini kvadrata yukseldib yeni array qaytaran funksiya
function squareArray(arr) {
    let newArr = [];
    for (let i = 0; i < arr.length; i++) {
        newArr.push(arr[i] * arr[i]);
    }
    return newArr;
}
let result = squareArray([2, 3, 4, 5]);
console.log(result);