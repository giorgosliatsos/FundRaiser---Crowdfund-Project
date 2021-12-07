$(document).ready(function () {
    if ($("#Results").length != 0) {
        loadData()
    }

});

function loadData() {

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
                + '<td>' + backer.firstName + '</td>'
                + '<td>' + backer.lastName + '</td>'
                + '<td>' + backer.dateOfBirth + '</td>'
                + '<td>' + backer.moneyGoal + '</td>'
                + '</tr>'));

            resultData += '</table>';
            $("#Results").html(resultData);

        })
        .fail(failure => {
            console.log('error in communication');
            console.log(JSON.stringify(failure));
        });
}


