$(document).ready(function () {
    if ($("#BackerResults").length != 0) {
        loadBackers()
    }
    if ($("#Results").length != 0) {
        loadCreators()
    }

});

function loadCreators() {

    let urlAPI = 'https://localhost:44313/api/creatorprofile/';
    let method = 'GET';

    $.ajax(
        {
            url: urlAPI,
            method: method
        })
        .done(result => {
            let resultData = "<table  class='table'>";
            result.forEach(cretor => resultData += ('<tr>'
                + '<td>' + cretor.id + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + cretor.firstName + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + cretor.lastName + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + cretor.dateOfBirth + '</td>'
                + '</tr>'));

            resultData += '</table>';
            $("#Results").html(resultData);

        })
        .fail(failure => {
            console.log('error in communication');
            console.log(JSON.stringify(failure));
        });
}

function loadBackers() {

    let urlAPI = 'https://localhost:44313/api/backerprofile/';
    let method = 'GET';

    $.ajax(
        {
            url: urlAPI,
            method: method
        })
        .done(result => {
            let resultData = "<table  class='table'>";
            result.forEach(backer => resultData += ('<tr>'
                + '<td>' + backer.id + '</td>'
                + '<td>' + ""+ '</td>'
                + '<td>' + backer.firstName + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + backer.lastName + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + backer.dateOfBirth + '</td>'
                + '</tr>'));

            resultData += '</table>';
            $("#BackerResults").html(resultData);

        })
        .fail(failure => {
            console.log('error in communication');
            console.log(JSON.stringify(failure));
        });
}




