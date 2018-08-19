// Write your JavaScript code.

// When the user scrolls the page, execute myFunction 
window.onscroll = function () { fixedNavBar() };

// Get the navbar
var navbar = document.getElementById("navbar");
var navbarCollapse = document.getElementById("navbar_collapse");

// Get the offset position of the navbar
//var sticky = navbar.offsetTop;
var sticky = 85;

// Add the sticky class to the navbar when you reach its scroll position. Remove "sticky" when you leave the scroll position
function fixedNavBar() {
    //debugger;
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky");
        navbarCollapse.classList.add("sticky");
    } else {
        navbar.classList.remove("sticky");
        navbarCollapse.classList.remove("sticky");
    }
}