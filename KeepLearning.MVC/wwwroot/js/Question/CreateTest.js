$(document).ready(function () {
    var createTest = $("#createTest");
    var continents = $(".continentInput");

    createTest.prop("disabled", true);

    continents.click(function (event) {
        DiableButton();
    });

    function DiableButton() {
        if (CheckIfAnyCountryIsChoosen()) {
            createTest.prop("disabled", false);
        } else {
            createTest.prop("disabled", true);
        }
    };

    function CheckIfAnyCountryIsChoosen() {
        console.log(continents)

        for (let i = 0; i < continents.length; i++) {
            console.log("continents[i].prop('checked')");
            console.log(continents.get(i).checked);

            if (continents.get(i).checked) {
                return true;
            }
        }

        return false;
    }
});
