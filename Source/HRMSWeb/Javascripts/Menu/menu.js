$(document).ready(function () {

    var currentLocation = $(location).attr("href");
    var selectedMenu = currentLocation.substring(currentLocation.indexOf("#/") + 2);
    if (selectedMenu.indexOf("?") > 0) {
        selectedMenu = selectedMenu.substring(0, selectedMenu.indexOf("?"));
    }

    $('[id^="mainmenu"]').each(function () {

        //handler for re-selecting the current selected menu when refreshed button is clicked.
        if (selectedMenu == "") {
            $("#mainmenu1").addClass("active");
        }
        else if ($(this).html().indexOf(selectedMenu) > 0) {
            $(this).addClass("active");
        }
        else if ($(this).html().indexOf(selectedMenu) > 0) {
            $(this).addClass("active");
        }

        $(this).click(
            function () {
                //to make sure the div messages won't display on initial load of the view
                $("#noDataFound").hide();
                $("#errorMessage").hide();

                if ($(this).attr("class") != "active" || $(this).attr("class") != "dropdown active") {
                    $(this).addClass("active");
                }
                var selectedMenu = $(this).attr("id");
                //toggle active class for the remaining menu items
                $('[id^="mainmenu"]').each(function () {
                    if ($(this).attr("id") != selectedMenu) {
                        $(this).removeClass("active");
                    }
                })
            }
         );
    });
});