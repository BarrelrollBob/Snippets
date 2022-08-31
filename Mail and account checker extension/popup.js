

// I need a means to alert the user if the app isn't working, since if it doesn't, it won't record where the user signs up. The user should know
// holds the list of input elements upon using 'querySelectorAll'
var inputs;
// holds the input elements, complete with identifiers and event listeners
var inputElements = [];
// 
var writtenText;
var valueObj = {
    listOfValues: [1, 2, 3, 4, 5, 6, 7, 8]
};

const body = document.querySelector("body");
const parentDiv = document.createElement("div");
const setButton = document.createElement("button");
const getButton = document.createElement("button");
const clearButton = document.createElement("button");
const testButton = document.createElement("button");
const display = document.createElement("div");
const display2 = document.createElement("div");

parentDiv.innerHTML = "Test";
setButton.innerHTML = "Set";
getButton.innerHTML = "Get";
clearButton.innerHTML = "Clear storage";
testButton.innerHTML = "Test button";

parentDiv.appendChild(setButton);
parentDiv.appendChild(getButton);
parentDiv.appendChild(clearButton);
parentDiv.appendChild(testButton);
body.appendChild(parentDiv);
body.appendChild(display);
body.appendChild(display2);

getOriginUrl();

setButton.addEventListener("click", () => {
    chrome.storage.sync.set({valueObj}, () => {

        chrome.storage.sync.get(['valueObj'], (data) => {
            console.log(data);
            for (var i = 0; i < data['valueObj']["listOfValues"].length; i++) {
                console.log(`Synced values: ${data['valueObj']['listOfValues'][i]}`);
            }
        });
    });        
})

getButton.addEventListener("click", () => {

    var getStorage = chrome.storage.sync.get(["valueObj"]);
    getStorage
    .then
    ( (data) => {

        display.innerHTML = "";
        for (const value of data['valueObj']['listOfValues']) {
            display.innerHTML += value + '<br>';
        }    
    })
    .catch( (error) => {
        
        display.innerHTML = "Nothing in storage";
        console.log(error);
    })
})

clearButton.addEventListener("click", () => {

    chrome.storage.sync.clear();
    display.innerHTML = "Storage has been cleared";
})

testButton.addEventListener("click", async () => {

})

// Function that gets the origin URL from the current tabs' URL

function getOriginUrl() {
    const currentTab = chrome.tabs.query({active: true, currentWindow: true});
    
    currentTab.then( tab => {

        const activeTab = tab[0];
        const activeTabUrl = activeTab.url;
        const fullUrl = new URL(activeTabUrl);
        const urlOrigin = fullUrl.origin;

        display2.innerHTML = activeTabUrl;
        display.innerHTML = urlOrigin;

    }).catch( error => {
        console.log(error);
    })
}



