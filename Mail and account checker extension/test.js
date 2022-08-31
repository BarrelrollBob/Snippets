// Simple program to test asynchronous properties of Promise
// Contains a button and a <p> to display results

const testDisplay = document.querySelector("#test");
const testDisplay1 = document.querySelector("#test1");
const testDisplay2 = document.createElement('p');
const button = document.querySelector("button");

const body = document.querySelector('body');
body.appendChild(testDisplay2);

var number = 1;

button.addEventListener("click", () => {
    promiseFunc();
    window.location.href = "http://stackoverflow.com";
})
// testDisplay.innerHTML = "";

function promiseFunc() {

    testDisplay1.innerHTML = null;

    testDisplay2.innerHTML = "Async!";

    /* setTimeout(idkSmth( () => {
        console.log(number);
        if ( number % 2 != 0 ) {
            return 20;
        }
        else return 50;
    }, 4000)); */

    let promise = new Promise(something);
    promise
    .then( (resolve) => {
        testDisplay.innerHTML = resolve;
    }, (reject) => {
        testDisplay.innerHTML = reject;
    })
}

// execution handler function
function something(resolve, reject) {

    if (number == 1) {
        resolve('hi');
        number++;
    }
    else { 
        reject('bye');
        number = 1;
    }
}

