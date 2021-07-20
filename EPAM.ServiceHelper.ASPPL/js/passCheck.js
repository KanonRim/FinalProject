form = document.getElementById("regForm");

form.onsubmit = function () {
    let pas = document.getElementById('password');
    let pasAgain = document.getElementById('password-again');
    if (pas.value != pasAgain.value) {
        pasAgain.setCustomValidity("Пароли не совпадают");
        console.log(pas.value + "Passwords don't match" + pasAgain.value);
        return false; // prevent the form from submitting
    } else {
        pasAgain.setCustomValidity('');
    }
}

document.getElementById("password-again").onchange = function (e) {
    e.target.setCustomValidity('')
}
