// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var id = null;

function Move() {
    var elem = document.getElementById("Cart");
    var pos = 0;
    if (pos == 0) elem.style.display = "flex";
    clearInterval(id);
    id = setInterval(frame, 5);
    function frame() {
        if (pos == 50) {
            clearInterval(id);
        } else {
            pos++;
            if (pos == -5) {
                
            }
            elem.style.width = pos + 'px';
            elem.style.height = pos + 'px';

        }
    }
}

$(document).ready(function () {

});

