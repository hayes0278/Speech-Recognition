
function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(name) {
    const cookieName = name + "=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const cookieArray = decodedCookie.split(';');

    for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i];
        while (cookie.charAt(0) === ' ') {
            cookie = cookie.substring(1);
        }
        if (cookie.indexOf(cookieName) === 0) {
            return cookie.substring(cookieName.length, cookie.length);
        }
    }
    return null; // Return null if the cookie is not found
}

function redirectToNewPage(newUrl) {
    window.location.href = newUrl;
}

function replaceCurrentPage(newUrl) {
    window.location.replace(newUrl);
}

function changeLanguage(newLanguage) {
    setCookie("culture", newLanguage, 5);
    document.getElementById('testArea').Value = $"Your new language: {newLanguage}";
}

function displayMessage(message) {
    document.getElementById('testArea').Value = message;
}

function displayAlert(message) {
    alert(message);
}

function changeCommand(command) {
    document.getElementById('testArea').innerHTML = command;
    alert(command);
}

function changeAction(action) {
    document.getElementById('testArea').innerHTML = action;
    alert(action);
}

document.getElementById("year").innerHTML = new Date().getFullYear();
alert('Test');