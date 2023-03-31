$(document).ready(() => {

    var toggleBackgroundColor = () => {
        var currentClasses = $("#left-div").attr("class");
        
        if(currentClasses === "square blue-background") {
            $("#left-div").attr("class", "square red-background");
            return;
        }
        $("#left-div").attr("class", "square blue-background");

    };

    $("#test-button").click(() => {
        toggleBackgroundColor();
    });
});