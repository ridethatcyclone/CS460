var id = Number($('#itemIDSpan').html());
var intervalID = window.setInterval(ajax_call(id), 5000);

function ajax_call(id) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Items/ListBids/' + id,
        data: { id: id },
        success: displayResults,
        error: itFailed
    })
}

function displayResults(data) {
    $('#out').empty();

    var item = document.getElementById("out");
    data.arr.forEach(function (item) {
        $('#out').append(item);
    })
    console.log(data);
}

function itFailed() {
    console.log("An error occurred.");
}
