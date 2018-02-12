$(function () {// Image click & ...
    $(function () {
        var imageContainer = $("#fullscreen_image_container");
        var image = $("#imgFullscreen");
        var imageContainerCloser = $(".close");
        $(".image").click(function () {
            // Make image fullscreen etc.
            var src = this.src;

            image.attr("src", src);
            image.css("display", "block");
            imageContainerCloser.css("display", "block");
            imageContainer.css("display", "block");
        });
        imageContainerCloser.click(function () {
            image.css("display", "none");
            imageContainerCloser.css("display", "none");
            imageContainer.css("display", "none");
        });
        /*
        image.click(function () {
            image.css("display", "none");
            imageContainerCloser.css("display", "none");
            imageContainer.css("display", "none");
        });
        /**/
    });
});