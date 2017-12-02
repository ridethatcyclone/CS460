/* Thank you to Michael Brown for helping me with this code: https://github.com/mgeorgebrown89 */

function ajaxDisplay(id) {
    var source = '/Home/Genre/';
    console.log(source);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        data: { id : id },
        url: source,
        success: displayResults,
        error: errorOnAjax
    });
}

function displayResults(data) {
    $('#out').empty();

    var item = document.getElementById("out");

    data.arr.forEach(function (item) {
        $('#out').append(item);
    });
}

function errorOnAjax() {
    console.log("Error");
}
 