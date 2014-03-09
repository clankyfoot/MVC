var replaceInput = null;

$(document).ready(function () {
    $("#createButton").click(function () {
        $("#createPageForm").show(700);

        var element = null;
        for (var i = 0; i < $("#createPageForm").children("input").length; i++) {
            element = $("#createPageForm").children("input").get(i);
            alert($(element).id + " " + $(element).val());
        }
    });
    $("#createPageForm > .create").click(function () {
        create_click($("#createPageForm"));
    });
    $("#createPageForm > .cancel").click(function () {
        
        $("#createPageForm").slideUp(700, null);
    });
    $("#createPageForm > input").on("keyup change blur paste cut click", function () {
        
        if ($(this).val() == "" || $(this).val().length < 3) {
            $(this).next("span").addClass("field-validation-error");
            $(this).next("span").text("Invalid");
        } else {
            $(this).next("span").addClass("field-validation-valid");
            $(this).next("span").text("Valid");
        }
    });
});

///
/// Returns a HtmlInputButton 
///
function HtmlInput(id, className, role, type, text, required, click) {

    var input = document.createElement("input");

    if (id != null) { input.setAttribute("id", id); }
    if (className != null) { input.setAttribute("class", className); }
    if (role != null) { input.setAttribute("role", role); }
    if (text != null) {
        input.setAttribute("value", text);
    } else {
        input.setAttribute("value", "text");
    }
    if (type != null) { input.setAttribute("type", type); }
    if (required != null || required == false) { input.setAttribute("required", "required"); }
    if (click != null) {
        if (typeof click == "string") {
            input.setAttribute("onclick", click);
        } else {
            input.onclick = click;
        }
    }

    return input;
}
/// 
/// Creates a paragraph Tag element
///
function HtmlParagraph(id, className, text) {
    var p = document.createElement("p");
    
    if (id != null) { p.setAttribute("id", id); };
    if (className != null) { p.setAttribute("className"); }
    if (text != null) { p.innerText = text; }

    return p;
}
//
// responds to the edit click event
//
function edit_click(thisObj) {
    
    replaceInput = "edit";

    var p = $(thisObj).parent("p").parent("div");
    p = p.children("p").first();
    p.replaceWith(HtmlInput($(p).attr("id"), null, "textbox", "text", $(p).text(), true, null));

    $(thisObj).next("input").replaceWith(HtmlInput("cancel-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Cancel", false, "cancel_click(this)"));
    $(thisObj).replaceWith(HtmlInput("save-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Save", false, "save_click(this)"));
}
//
// reacts to the delete click event.
//
function delete_click(thisObj) {
    
    replaceInput = "delete";

    $(thisObj).prev("input").replaceWith(HtmlInput("save-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Confirm", false, "save_click(this)"));
    $(thisObj).replaceWith(HtmlInput("cancel-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Cancel", false, "cancel_click(this)"));
}

function save_click(thisObj) {
    
    var id = $(thisObj).parent("p").attr("id");
    var name = $(thisObj).parent("p").parent("div").children("input").first().val();

    switch (replaceInput) {
        case "edit":
            $.ajax({
                cache: false,
                type: "POST",
                contentType: "application/json charset=UTF-8",
                url: "../Page/updatePageName",
                data: '{ id: "' + id + '", name: "' + name + '" }',
                dateType: "json"
            }).done(function (data, response) {
                if (data == "True") {
                    $(".error-summary").children("*").remove("*");
                    $(".success-summary").children("*").replaceWith("Your Changes have been made, please allow for up to 24 hours for changes to be reflected");
                } else if (data == "False") {
                    $(".success-summary").children("*").remove("*");
                    $(".error-summary").children("*").replaceWith("<p>There was an error processing your request. A ticket has been sent to the Administrator</p>");
                }
                
                cancel_click($(thisObj).next("input"));
            }).error(function (request, status, error) {
                alert("there was an error, " + request.statusText);
            })
            break;
        case "delete":
            $.ajax({
                cache: false,
                type: "POST",
                contentType: "application/json charset=UTF-8",
                url: "../Page/deletePage",
                data: '{ idOrName: ' + id + '}',
                dataType: "json"
            }).done(function (data, response) {
                if (data == "True") {
                    $(thisObj).parent("p").parent("div").remove().slideUp(700, "slow", null);
                    $(".error-summary").children("*").remove("*");
                    $(".success-summary").children("*").replaceWith("Your Changes have been made, please allow for up to 24 hours for changes to be reflected");
                } else if (data == "False") {
                    $(".success-summary").children("*").remove("*");
                    $(".error-summary").children("*").replaceWith("<p>There was an error processing your request. A ticket has been sent to the Administrator</p>");
                }
            }).error(function (request, status, error) {
                alert("there was an error" + request.statusText);
            });
            break;
        default:
            break;
    }
}
//
// removes the inner panel and replaces the Edit, Delete Buttons
//
function cancel_click(thisObj) {
    switch (replaceInput) {
        case "edit":
            var p = $(thisObj).parent("p").parent("div");
            p = p.children("input").first();
            p.replaceWith(HtmlParagraph($(p).attr("id"), null, $(p).val()));
            break;
        case "delete":
            // not sure if we need the following code...yet...
            //$(thisObj).prev("input").replaceWith(HtmlInput("edit-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Edit", false, "edit_click(this)"));
            // $(thisObj).replaceWith(HtmlInput("delete-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Delete", false, "delete_click(this)"))
            break;
        default:
            break;
    }
    $(thisObj).prev("input").replaceWith(HtmlInput("edit-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Edit", false, "edit_click(this)"));
    $(thisObj).replaceWith(HtmlInput("delete-" + $(thisObj).parent("p").attr("id"), null, "button", "button", "Delete", false, "delete_click(this)"))
    replaceInput = null;
}
//
// when the create form "create" button is clicked
//
function create_click(form) {
    var valid = false;

    var element = $(form).children("input").first();

    for (var i = 0; i < $(form).children("input").length; i++) {
        if ($(element).val() == "" || $(element).val().length < 3) {
            $(element).next("span").text("Invalid");
            $(element).next("span").addClass("field-validation-error");
        } else {
            $(element).next("span").text("Valid");
            $(element).next("span").addClass("field-validation-valid");
        }
        element = $(element).next("input");
    }
}