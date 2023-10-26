$(document).ready(function () {

    const NumberOfQuestions = [5, 10, 20, 25, 50];

    var createTest = $("#createTest");
    var continentInputs = $(".continentInput");

    ConfigureContinentInputs(createTest, continentInputs);

    function ConfigureContinentInputs(createTest, continentInputs) {
        createTest.prop("disabled", true);

        continentInputs.click(function (event) {
            DiableButton(createTest, continentInputs);
            GetMaxNumberOfQuestion(continentInputs);
        });
    }

    function DiableButton(createTest, continentInputs) {
        if (CheckIfAnyContinentIsChecked(continentInputs)) {
            createTest.prop("disabled", false);
        } else {
            createTest.prop("disabled", true);
        }
    }

    function SetMaxNumberOfQuestion(maxNumberOfQuestion) {
        console.log("maxNumberOfQuestion");
        console.log(maxNumberOfQuestion);

        var numberOfQuestionSelect = $("#NumberOfQuestion");
        numberOfQuestionSelect.find('option').remove();

        NumberOfQuestions.forEach(element => {
            AddOption(element, maxNumberOfQuestion, numberOfQuestionSelect);
        });
    }

    function AddOption(item, maxNumberOfQuestion, numberOfQuestionSelect) {
        console.log("numberOfQuestionSelect");
        console.log(numberOfQuestionSelect);

        if (item < maxNumberOfQuestion) {
            numberOfQuestionSelect.append("<option value=" + item + ">" + item + "</option>")
        }
    }

    function GetMaxNumberOfQuestion(continentInputs) {
        var dataToSend = CreatePathParamsWithContinents(continentInputs);
        console.log(dataToSend);

        $.ajax({
            url: `/Country/GetNumberOfCountries`,
            type: 'get',
            data: dataToSend,
            success: function (maxNumberOfQuestion) {
                SetMaxNumberOfQuestion(maxNumberOfQuestion)
            },
            error: function (data) {
                toastr["error"]("Something went wrong")
            }
        });
    }

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
    }

    function SetProperNameForContinent(continent) {
        switch (continent) {
            case "N. America": return "NorthAmerica";
            case "S. America": return "SouthAmerica";
            default: return continent;
        }
    }

    function CheckIfAnyContinentIsChecked(continents) {
        for (let i = 0; i < continents.length; i++) {
            if (continents.get(i).checked) {
                return true;
            }
        }

        return false;
    }
});
