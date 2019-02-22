
$(document).ready(function(){
    $("#addCommentButton").click(function(){
       $("#addCommentForm").fadeIn( "slow" )
                           .toggleClass("d-none");
        $(this).fadeOut( "slow" );
    })

    
    $("#addCommentTextbox").focus(function(e) {
        $("#submitCommentButton, #cancelCommentButton").fadeIn( "slow" )
                                                       .toggleClass("d-none");
    })

     $("#cancelCommentButton").click(function(){
       $("#addCommentForm").fadeOut( "slow" )
                           .toggleClass("d-none");
        $("#submitCommentButton, #cancelCommentButton").fadeOut( "slow" )
                                                       .toggleClass("d-none");
    })
})