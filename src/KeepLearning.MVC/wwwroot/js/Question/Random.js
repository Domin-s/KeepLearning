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

    $(answer).keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            CheckAnswer();
        }
    });

    function RefreshDataOnWebsite() {
        var continent = $("#Continent").val();
        var category = $("#Category").val();

        var dataToSend = 'Continent=' + continent + "&Category=" + category;

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
        var category = $("#Category").val();
        var dataToSend = 'Question=' + question.text() + "&Answer=" + answer.val() + "&Category=" + category;

        $.ajax({
            url: `/Question/CheckAnswer`,
            type: 'get',
            data: dataToSend,
            success: function (data) {
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