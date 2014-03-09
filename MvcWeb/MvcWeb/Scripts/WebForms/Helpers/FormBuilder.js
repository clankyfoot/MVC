//
// builds a password div
//
function buildPassword() {
    
    var div = document.createElement("div");
    
    var label = document.createElement("label");
    label.htmlFor = "password";
    label.innerText = "Password";
    
    var password = document.createElement("input");
    password.required = true;
    password.type = "password";
    password.setAttribute("role", "textbox");
    password.setAttribute("id", "password");
    password.onblur = function () {
        if(password .value != ""){
            span.setAttribute("class", "validation-success");
        }
    }

    var span = document.createElement("span");
    span.clientHeight = password.clientHeight;
    span.clientWidth = 50;
    span.setAttribute("class", "validation-error");

    div.appendChild(label);
    div.appendChild(password);
    div.appendChild(span);
}
//
// builds a username div
//
function buildUsername() {

    var div = document.createElement("div");

    var label = document.createElement("label");
    label.htmlFor = "username";
    label.innerText = "Username";

    var username = document.createElement("input");
    username.value = "";
    username.type = "text";
    username.setAttribute("role", "textbox");
    username.setAttribute("id", "username");
    username.onblur = function () {
        if (username.value != "") {
            span.setAttribute("class", "validation-success");
        }
    }

    var span = document.createElement("span");
    span.clientHeight = password.clientHeight;
    span.clientWidth = 50;
    span.setAttribute("class", "validation-error");

    div.appendChild(label);
    div.appendChild(username);
    div.appendChild(span);
}
//
// Builds an e-mail div
//
function buildEmail() {

    var div = document.createElement("div");

    var label = document.createElement("label");
    label.htmlFor = "email";
    label.innerText = "Email";

    var email = document.createElement("input");
    email.value = "";
    email.type = "text";
    email.setAttribute("role", "textbox");
    email.setAttribute("id", "email");
    email.onblur = function () {
        if (email.value != "") {
            span.setAttribute("class", "validation-success");
        }
    }

    var span = document.createElement("span");
    span.clientHeight = password.clientHeight;
    span.clientWidth = 50;
    span.setAttribute("class", "validation-error");

    div.appendChild(label);
    div.appendChild(email);
    div.appendChild(span);
}
//
// builds a confirmPassword div
//
function buildConfirmPassword() {

    var div = document.createElement("div");

    var label = document.createElement("label");
    label.htmlFor = "confirmPassword";
    label.innerText = "Password";

    var confirmFassword = document.createElement("input");
    confirmPassword.required = true;
    confirmPassword.type = "password";
    confirmPassword.setAttribute("role", "textbox");
    confirmPassword.setAttribute("id", "confirmPassword");
    confirmPassword.onblur = function () {
        if (confirmPassword.value == document.getElementById("password").getAttribute("value")) {
            span.setAttribute("class", "validation-success");
        }
    }

    var span = document.createElement("span");
    span.clientHeight = confirmPassword.clientHeight;
    span.clientWidth = 50;
    span.setAttribute("class", "validation-error");

    div.appendChild(label);
    div.appendChild(confirmPassword);
    div.appendChild(span);
}
//
// builds a phone div
//
function buildPhone() {

    var div = document.createElement("div");

    var label = document.createElement("label");
    label.htmlFor = "phone";
    label.innerText = "phone";

    var phone = document.createElement("input");
    phone.required = true;
    phone.type = "tel";
    phone.setAttribute("role", "textbox");
    phone.setAttribute("id", "phone");
    phone.onblur = function () {
        if (phone.value != "") {
            span.setAttribute("class", "validation-success");
        }
    }

    var span = document.createElement("span");
    span.clientHeight = phone.clientHeight;
    span.clientWidth = 50;
    span.setAttribute("class", "validation-error");

    div.appendChild(label);
    div.appendChild(phone);
    div.appendChild(span);
}