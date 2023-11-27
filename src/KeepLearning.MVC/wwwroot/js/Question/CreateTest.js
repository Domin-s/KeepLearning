$(document).ready(function () {

    class GetNumberOfCountriesQuery {
        constructor(continents) {
            this.Continents = continents
        }
    }

    class Continents {
        constructor(name) {
            this.Name = name;
        }
    }

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
        var dataToSend = CreateDataToSend(continentInputs);

        $.post(`/Country/GetNumberOfCountries`, dataToSend, (maxNumberOfQuestions, status) => {
            ConfigureSelectForNumberOfQuestions(maxNumberOfQuestions);
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

    function CreateDataToSend(continentInputs) {
        var continents = CreateContientsToSend(continentInputs);

        return new GetNumberOfCountriesQuery(continents);
    }

    function CreateContientsToSend() {
        var continents = [];

        for (let i = 0; i < continentInputs.length; i++) {
            if (continentInputs.get(i).checked) {
                var element = CreateOneContinentToSend(continentInputs[i]);

                continents.push(element);
            }
        }

        return continents;
    }

    function CreateOneContinentToSend(question) {
        var name = question.value;

        return new Continents(name);
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
