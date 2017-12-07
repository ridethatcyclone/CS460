var searchString = '';
var requestLink = '';
var key = $("#key").data("value");

function main() 
{
    $("#submitButton").on('click', function () {
        if (!($("#sbar").val())) {
            console.log("Nothing entered.");
        }
        else {
            var animated = $("input[name='animated']:checked").val();
            searchString = $("#sbar").val().replace(" ", "+");
            $("#sbar").val('');
            requestLink = "http://api.giphy.com/v1/gifs/search?q=" + searchString + "&api_key=" + key;

            $(".gifRow").html(null);

            $.ajax({
                type: 'GET',
                url: requestLink,
                dataType: 'json',
                success: function (response) {

                    if (animated == 'true') {
                        for (i = 0; i < 9; i++) {
                            if (i < 3) {
                                $('#topRow').append('<div class="col-md-4 gifCol"><img src="' + response.data[i].images.fixed_width.url + '" class="displayGif"></div>');
                            }
                            else if (i >= 3 && i < 6) {
                                $('#middleRow').append('<div class="col-md-4 gifCol"><img src="' + response.data[i].images.fixed_width.url + '" class="displayGif"></div>');
                            }
                            else {
                                $('#bottomRow').append('<div class="col-md-4 gifCol"><img src="' + response.data[i].images.fixed_width.url + '" class="displayGif"></div>');
                            }
                        }
                    }

                    else {
                        for (i = 0; i < 9; i++) {
                            if (i < 3) {
                                $('#topRow').append('<div class="col-md-4 gifCol"><img src="' + response.data[i].images.fixed_width_still.url + '" class="displayGif"></div>');
                            }
                            else if (i >= 3 && i < 6) {
                                $('#middleRow').append('<div class="col-md-4 gifCol"><img src="' + response.data[i].images.fixed_width_still.url + '" class="displayGif"></div>');
                            }
                            else {
                                $('#bottomRow').append('<div class="col-md-4 gifCol"><img src="' + response.data[i].images.fixed_width_still.url + '" class="displayGif"></div>');
                            }
                        }
                    }

                }
            });

            $.ajax({
                type: 'POST',
                url: '/Home/Index/',
                data: { search: searchString },
                success: function () {
                    console.log("Yay");
                }
            });
        }

        
    })
}


$(document).ready(main);