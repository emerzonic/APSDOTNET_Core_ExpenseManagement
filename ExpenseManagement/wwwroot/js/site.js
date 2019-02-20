// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function(){
    $("#addCommentButton").click(function(){
       $("#addCommentForm").toggleClass("d-none");
        $(this).addClass("d-none");
    })

    
    $("#addCommentTextbox").focus(function(e) {
        $("#submitCommentButton, #cancelCommentButton").toggleClass("d-none");
    })

     $("#cancelCommentButton").click(function(){
       $("#addCommentForm").toggleClass("d-none");
        $("#submitCommentButton, #cancelCommentButton").toggleClass("d-none");
    })
})