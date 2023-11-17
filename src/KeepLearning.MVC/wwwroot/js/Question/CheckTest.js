$(document).ready(function () {

    class CheckTestQuery {
        constructor(category, answers) {
            this.Category = category;
            this.Answers = answers
        }
    }

    class Answer {
        constructor(numberOfQuestion, questionText, answerText) {
            this.NumberOfQuestion = numberOfQuestion;
            this.QuestionText = questionText;
            this.AnswerText = answerText;
        }
    }

    $("#checkAnswers").click(function (event) {
        CheckAnswers();
    });

    function CheckAnswers() {
        var guessType = $("#Category").val();
        var questions = $(".Question");

        var dataToSend = CreateDataToSend(guessType, questions);

        $.post(`/Question/CheckTest`, dataToSend, (result, status) => {
            AddColumnWithAnswer(result);
            DisableInputs("Answer");
        });
    }

    function AddColumnWithAnswer(result) {
        var tableHead = $('thead>tr');
        var answerColumn = $('.AnswerColumn');

        if (answerColumn.length == 0) {
            AddNewHeadColumn(tableHead);
            AddNewBodyColumn(result);
            ShowResult(result.numberOfGoodAnswers, result.numberOfBadAnswers);
            HiddeButton("checkAnswers");
        }
    }

    function AddNewHeadColumn(tableHead) {
        var newDiv = $("<div></div>").text("Answer");
        var newHeadColumn = $("<th class='AnswerColumn'></th>").append(newDiv);
        tableHead.append(newHeadColumn);
    }

    function AddNewBodyColumn(result) {
        var answers = result.answerResults;

        for (var i = 0; i < answers.length; i++) {
            AddRowWithAnswer(answers[i].numberOfQuestion, answers[i].correctAnswer);
        }
    }

    function AddRowWithAnswer(numberOfQuestion, correctAnswer) {
        var className = '.Question_' + numberOfQuestion + '';
        var row = $(className);

        var newDiv = $("<div></div>").text(correctAnswer);
        var newBodyColumn = $("<td></td>").append(newDiv);
        row.append(newBodyColumn);

        ChangeColorOfUserAnswer(numberOfQuestion, correctAnswer)
    }

    function ChangeColorOfUserAnswer(numberOfQuestion, correctAnswer) {
        var answerInput = $('#Answer_' + numberOfQuestion);
        if (answerInput.val() == correctAnswer) {
            answerInput.css({ 'background-color': 'green', 'font-weight': 'bold' });
        } else if (answerInput.val() == "") {
            answerInput.val("Empty!").css({ 'background-color': 'red', 'font-weight': 'bold', 'color': 'white' });
        } else {
            answerInput.css({ 'background-color': 'red', 'font-weight': 'bold', 'color': 'white' });
        }
    }

    function ShowResult(goodAnswers, badAnswers) {
        var result = $('.Result');
        console.log(result);
        result.show();
        $('.GoodAnswers').text(goodAnswers);
        $('.BadAnswers').text(badAnswers);
    }

    function HiddeButton(name) {
        $('#' + name).hide();
    }

    function DisableInputs(nameOfInputClass) {
        var inputs = $('.' + nameOfInputClass);
        inputs.prop("disabled", true);
    }

    function CreateDataToSend(category, questions) {
        var answers = CreateAnswersToSend(questions);

        return new CheckTestQuery(category, answers);
    }

    function CreateAnswersToSend(questions) {
        var result = [];

        for (let i = 0; i < questions.length; i++) {
            var element = CreateOneAnswerToSend(questions[i]);

            result.push(element);
        }

        return result;
    }

    function CreateOneAnswerToSend(question) {
        var numberOfQuestion = question.children[0].children[1].value;
        var questionText = question.children[1].children[1].value;
        var answerText = question.children[2].children[0].value;

        return new Answer(numberOfQuestion, questionText, answerText);
    }
});