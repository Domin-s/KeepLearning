$(document).ready(function () {
    var goodAnswers = 0;
    var badAnswers = 0;

    class CheckTestQuery {
        constructor(guessType, answers) {
            this.GuessType = guessType;
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
        var guessType = $("#GuessType").val();
        var questions = $(".Question");

        var dataToSend = CreateDataToSend(guessType, questions);

        $.post(`/Question/CheckTest`, dataToSend, (result, status) => {
            goodAnswers = result.numberOfGoodAnswers;
            badAnswers = result.numberOfBadAnswers;
            AddColumnWithAnswer(result);
            DisableInputs("Answer");
        });
    }

    function AddColumnWithAnswer(result) {
        var tableHead = $('thead>tr');

        AddNewHeadColumn(tableHead);
        AddNewBodyColumn(result);
    }

    function AddNewHeadColumn(tableHead) {
        var newDiv = $("<div></div>").text("Answer");
        var newHeadColumn = $("<th></th>").append(newDiv);
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
    }

    function DisableInputs(nameOfInputClass) {
        var inputs = $('.' + nameOfInputClass);
        inputs.prop("disabled", true);
    }

    function AddResult() {

    }

    function CreateDataToSend(guessType, questions) {
        var answers = CreateAnswersToSend(questions);

        return new CheckTestQuery(guessType, answers);
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