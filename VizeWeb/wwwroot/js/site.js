// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#v-pills-tab a").on("click", function () {
        console.log("Burdyaımm");
        var tabName = $(this).attr('aria-controls');
        console.log("Burdyaımm2");
        $('[role=tabpanel]').removeClass("show active");
        $("#" + tabName).addClass("show active");
        console.log("Burdyaımm3");
        $("#v-pills-tab a.active").toggleClass("active");
        $(this).addClass("active");
    });
});