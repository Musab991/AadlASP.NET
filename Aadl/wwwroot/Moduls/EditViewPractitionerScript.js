
let ClsPractitioner = {
    GetCasesByPractitionerTypeId: function (practitionerTypeId) {

        //ajax call from api
        // get data  .
        //select element to draw data inside it
        Helper.AjaxCallGet('https://localhost:7055/api/Practitioner/Cases/' + practitionerTypeId, null, 'json', function (data) {

                console.log("Data:\t", data);

            },
            function (xhr, status, error) {

                console.log("xhr:\t", xhr);
                console.log("status:\t", status);
                console.log("error:\t", error);


            });


    }

}


//$(document).ready(function () {
//    // Remove all click handlers for .loadMore
//    $('.loadMore').off('click');

//    $(".product-page-per-view select").on("change", function () {

//        // Get the selected option element
//        var selectedOption = $(this).find('option:selected');

//        // Get the id and value of the selected option
//        var selectedId = selectedOption.attr('id');


//        // Perform actions based on the selected id
//        switch (selectedId) {
//            case "productPerPage_24":
//                ClsItems.changeTotalElementsPerPage(24);
//                console.log("Selected ID is 24 Products Per Page.");
//                // Implement logic for 24 Products Per Page
//                break;
//            case "productPerPage_50":
//                ClsItems.changeTotalElementsPerPage(50);

//                console.log("Selected ID is 50 Products Per Page.");
//                // Implement logic for 50 Products Per Page
//                break;
//            case "productPerPage_100":
//                ClsItems.changeTotalElementsPerPage(100);
//                console.log("Selected ID is 100 Products Per Page.");
//                // Implement logic for 100 Products Per Page
//                break;
//            default:
//                console.log("Default or unknown selection.");
//                break;
//        }


//    })
//});

