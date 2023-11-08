$(document).ready(function () {
    var isIncorrect = false;
    var question = $("#Question");
    var answer = $("#Answer");

    $("#getAnotherRandomQuestion").click(function (event) {
        AddAnswerToHistory(question.text(), answer.text(), isIncorrect);
        RefreshDataOnWebsite();
    });

    $("#answerChecker").click(function (event) {
        CheckAnswer();
    });

    function RefreshDataOnWebsite() {
        var continent = $("#Continent").val();
        var guessType = $("#GuessType").val();

        var dataToSend = 'Continent=' + continent + "&GuessType=" + guessType;

        $.ajax({
            url: `/Question/RandomAnotherQuestion`,
            type: 'get',
            data: dataToSend,
            success: function (data) {
                question.text(data.questionText);
                answer.val(data.answerText);
            },
            error: function (data) {
                toastr["error"]("Something went wrong")
            }
        })
    }

    function CheckAnswer() {
        var guessType = $("#GuessType").val();
        var dataToSend = 'Question=' + question.text() + "&Answer=" + answer.val() + "&GuessType=" + guessType;

        $.ajax({
            url: `/Question/CheckAnswer`,
            type: 'get',
            data: dataToSend,
            success: function (data) {
                console.log("val :: " + answer.val());
                AddAnswerToHistory(question.text(), answer.val(), data);
                RefreshDataOnWebsite();
            },
            error: function (data) {
                toastr["error"]("Something went wrong")
            }
        })
    }

    function AddAnswerToHistory(question, userAnswer, isCorrect) {
        var answerHistory = $("#answerHistory");

        if (isCorrect) {
            toastr["success"]("Good answer! Congratulations!!");

            var nextLi = $("<li></li>").text(question + " => " + userAnswer).css({ 'color': 'green', 'font-weight': 'bold' });
            answerHistory.append(nextLi);
        } else {
            toastr["error"]("Wrong answer. Write another or click in another random question.");

            var nextLi = $("<li></li>").text(question + " => " + userAnswer).css({ 'color': 'red', 'font-weight': 'bold' });
            answerHistory.append(nextLi);
        }
    };
});