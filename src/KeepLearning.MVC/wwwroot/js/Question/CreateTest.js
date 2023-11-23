$(document).ready(function () {

    const NumberOfQuestions = [5, 10, 20, 25, 50];

    var createTest = $("#createTest");
    var continentInputs = $(".continentInput");
    var numberOfQuestionDiv = $('.numberOfQuestionDiv');

    ConfigureContinentInputs(createTest, continentInputs, numberOfQuestionDiv);

    function ConfigureContinentInputs(createTest, continentInputs, numberOfQuestionDiv) {
        DiableButton(createTest, continentInputs);
        HideOrShowNumberOfQuestion(numberOfQuestionDiv, continentInputs)

        continentInputs.click(function (event) {
            GetMaxNumberOfQuestion(continentInputs);
            DiableButton(createTest, continentInputs);
            HideOrShowNumberOfQuestion(numberOfQuestionDiv, continentInputs);
        });
    }

    function HideOrShowNumberOfQuestion(numberOfQuestionDiv, continentInputs) {
        // TODO: remove console.log from this file
        console.log(numberOfQuestionDiv);
        if (CheckIfAnyContinentIsChecked(continentInputs)) {
            numberOfQuestionDiv.show();
        } else {
            numberOfQuestionDiv.hide();
        }
    }
    function DiableButton(createTest, continentInputs) {
        if (CheckIfAnyContinentIsChecked(continentInputs)) {
            createTest.prop("disabled", false);
        } else {
            createTest.prop("disabled", true);
        }
    }

    function GetMaxNumberOfQuestion(continentInputs) {
        var dataToSend = CreatePathParamsWithContinents(continentInputs);

        $.ajax({
            url: `/Country/GetNumberOfCountries`,
            type: 'get',
            data: dataToSend,
            success: function (maxNumberOfQuestions) {
                ConfigureSelectForNumberOfQuestions(maxNumberOfQuestions);
            },
            error: function (data) {
                toastr["error"]("Something went wrong")
            }
        });
    }

    function ConfigureSelectForNumberOfQuestions(maxNumberOfQuestions) {
        var numberOfQuestionsSelects = $("#NumberOfQuestion");
        numberOfQuestionsSelects.find('option').remove().end();

        SetMaxNumberOfQuestion(maxNumberOfQuestions, numberOfQuestionsSelects);
    }

    function SetMaxNumberOfQuestion(maxNumberOfQuestions, numberOfQuestionSelects) {
        NumberOfQuestions.forEach(element => {
            AddOptionWithNumber(element, maxNumberOfQuestions, numberOfQuestionSelects);
        });
    }

    function AddOptionWithNumber(item, maxNumberOfQuestions, numberOfQuestionSelect) {
        if (item < maxNumberOfQuestions) {
            AddOption(item, numberOfQuestionSelect);
        }
    }

    function AddOption(value, numberOfQuestionSelect) {
        numberOfQuestionSelect.append("<option value=" + value + ">" + value + "</option>");
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
