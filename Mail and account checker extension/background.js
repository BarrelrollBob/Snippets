


chrome.runtime.onMessage.addListener( (message) => {
    message = 'kekbur';
    if (message === 'smth lol') message;
})

chrome.tabs.onUpdated.addListener( async () => {
    await chrome.tabs.query({active: true, currentWindow: true}, tab => {

        const activeTab = tab[0];

        chrome.scripting.executeScript(
            {target: {tabId: activeTab.id},
            func: () => {

                chrome.runtime.sendMessage('smth lol', (response) => {

                    let error = chrome.runtime.lastError;
                    if (error) return error; 
                    alert(`Value has been sent to the extension. It responded with: ${response}`);
                });

                let inputs = document.querySelectorAll("input");
                let inputElements = [];

                inputs.forEach( inputElement => {
                    inputElements.push(inputElement);
                });

                /* const validElements = searchEmailSubmitInput(inputElements);

                validElements.submitButton.addEventListener('click', () => {
                    // get the value of validElements.emailInput
                })
                // now: communicate between content script and background script    */             
            }
        });
    });    
});

function searchEmailSubmitInput(inputArray) {
    
    let isEmailInput, isSubmitButton;
    let inputs = {};

    for (var i = 0; i < inputArray.length; i++) {
                    
        isEmailInput = inputArray[i].getAttribute('type') == 'email' ? true : false;
        isSubmitButton = inputArray[i].getAttribute('type') == 'submit' ? true : false;

        if (isEmailInput) inputs.emailInput = inputArray[i];
        if (isSubmitButton) inputs.submitButton = inputArray[i];
    }

    if (inputs.emailInput && inputs.submitButton) {
        alert("The extension works here");
        return inputs;
    }
    alert("The extension couldn't find the necessary fields on this page");
}