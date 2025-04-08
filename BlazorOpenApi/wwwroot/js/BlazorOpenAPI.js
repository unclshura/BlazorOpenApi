function ScrollTo(elementId) {
    var element = document.getElementById(elementId);
    if (element != null) {
        element.scrollIntoView({
            block: "start"
//            behavior: 'smooth'
        });
        window.scrollBy(0, -64); // Adjust scrolling with a negative value here
    }
}