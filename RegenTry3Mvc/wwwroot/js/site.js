$(document).ready(function() {
    if ($("#Results").length != 0) {
        loadUser()
    }

});

function loadUser() {

    const urlParams = new URLSearchParams(window.location.search);
    const role = urlParams.get('role');

    let urlAPI = "https://localhost:44313/api/backerprofile/" + window.location.pathname.split("/").pop();
    if (role == "Creator") urlAPI = "https://localhost:44313/api/creatorprofile/" + window.location.pathname.split("/").pop();
     
    let method = 'GET';

    $.ajax(
        {
            url: urlAPI,
            method: method
        })
        .done(result => {
            let resultData = "<table  class='table'>";
            resultData += ('<tr>'
                + '<td>' + result.id + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + result.firstName + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + result.lastName + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + "" + '</td>'
                + '<td>' + result.dateOfBirth + '</td>'
                + '</tr>');

            resultData += '</table>';
            $("#Results").html(resultData);

        })
        .fail(failure => {
            console.log('error in communication');
            console.log(JSON.stringify(failure));
        });
}
//}

//function loadCreators(id) {

//    let urlAPI = 'https://localhost:44313/api/creatorprofile/'+id;
//    let method = 'GET';

//    $.ajax(
//        {
//            url: urlAPI,
//            method: method
//        })
//        .done(result => {
//            let resultData = "<table  class='table'>";
//            resultData += ('<tr>'
//                + '<td>' + result.id + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.firstName + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.lastName + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.dateOfBirth + '</td>'
//                + '</tr>');

//            resultData += '</table>';
//            $("#CreatorResults").html(resultData);

//        })
//        .fail(failure => {
//            console.log('error in communication');
//            console.log(JSON.stringify(failure));
//        });
//}

//function loadCreators(id) {

//    let urlAPI = 'https://localhost:44313/api/creatorprofile/'+id;
//    let method = 'GET';

//    $.ajax(
//        {
//            url: urlAPI,
//            method: method
//        })
//        .done(result => {
//            let resultData = "<table  class='table'>";
//            resultData += ('<tr>'
//                + '<td>' + result.id + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.firstName + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.lastName + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.dateOfBirth + '</td>'
//                + '</tr>');

//            resultData += '</table>';
//            $("#CreatorResults").html(resultData);

//        })
//        .fail(failure => {
//            console.log('error in communication');
//            console.log(JSON.stringify(failure));
//        });
//}

////}

//function loadBackers(id) {

//    let urlAPI = 'https://localhost:44313/api/backerprofile/';
//    let method = 'GET';

//    $.ajax(
//        {
//            url: urlAPI,
//            method: method
//        })
//        .done(result => {
//            let resultData = "<table  class='table'>";
//            resultData += ('<tr>'
//                + '<td>' + result.id + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.firstName + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.lastName + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + "" + '</td>'
//                + '<td>' + result.dateOfBirth + '</td>'
//                + '</tr>');

//            resultData += '</table>';
//            $("#BackerResults").html(resultData);

//        })
//        .fail(failure => {
//            console.log('error in communication');
//            console.log(JSON.stringify(failure));
//        });
//}




