$(document).ready(function () {
    var createTest = $("#createTest");
    var continentInputs = $(".continentInput");

    ConfigureContinentInputs(createTest, continentInputs);

    function ConfigureContinentInputs(createTest, continentInputs) {
        createTest.prop("disabled", true);

        continentInputs.click(function (event) {
            DiableButton(createTest, continentInputs);
            SetMaxNumberOfQuestion(continentInputs);
        });
    };

    function DiableButton(createTest, continentInputs) {
        if (CheckIfAnyContinentIsChecked(continentInputs)) {
            createTest.prop("disabled", false);
        } else {
            createTest.prop("disabled", true);
        }
    };

    function SetMaxNumberOfQuestion(continentInputs) {
        console.log("SetMaxNumberOfQuestion");
        console.log(continentInputs);
        var numberOfQuestion = $("#NumberOfQuestion");
        var maxNumberOfQuestion = GetMaxNumberOfQuestion(continentInputs);

    };

    function GetMaxNumberOfQuestion(continentInputs) {
        var dataToSend = CreatePathParamsWithContinents(continentInputs);
        console.log(dataToSend);

        $.ajax({
            url: `/Country/GetNumberOfCountries`,
            type: 'get',
            data: dataToSend,
            success: function (data) {
                console.log("data :: " + data);
            },
            error: function (data) {
                toastr["error"]("Something went wrong")
            }
        });
    };

    function CreatePathParamsWithContinents(continentInputs) {
        var continentsAsString = "";

        for (let i = 0; i < continentInputs.length; i++) {
            if (continentInputs.get(i).checked) {
                if (continentsAsString == "") {
                    continentsAsString += "Continents=" + SetProperNameForContinent(continentInputs.get(i).value);
                } else {
                    continentsAsString += "&Continents=" + SetProperNameForContinent(continentInputs.get(i).value);
                }
            }
        }

        return continentsAsString;
    };

    function SetProperNameForContinent(continent) {
        switch (continent) {
            case "N. America": return "NorthAmerica";
            case "S. America": return "SouthAmerica";
            default: return continent;
        }
    }

    function CheckIfAnyContinentIsChecked(continents) {
        console.log(continents)

        for (let i = 0; i < continents.length; i++) {
            console.log("continents[i].prop('checked')");
            console.log(continents.get(i).checked);

            if (continents.get(i).checked) {
                return true;
            }
        }

        return false;
    };
});
