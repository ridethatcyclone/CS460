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
            searchString = $("#sbar").val().replace(" ", "+");
            $("#sbar").val('');
            requestLink = "http://api.giphy.com/v1/gifs/search?q=" + searchString + "&api_key=" + key;

            $(".gifRow").html(null);
            console.log(requestLink);

            $.ajax({
                type: 'GET',
                url: requestLink,
                dataType: 'json',
                success: function (response) {
                    console.log('success', response);
                    

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
            })
        }

        
    })
}


$(document).ready(main);