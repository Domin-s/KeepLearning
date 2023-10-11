$(document).ready(function () {

    var question = $("#question");
    var inputString = $("#userAnswer");
    var goodAnswer = $("#goodAnswer");

    $("#checker").click(function () {
        if (inputString.val() == goodAnswer.val()) {
            toastr["success"]("Good answer! Congratulations!!");
            RefreshDataOnWebsite();
            inputString.val('');
        } else {
            toastr["error"]("Wrong answer! You can write another answer again!");
            AddAnswerToHistory(question.text(), inputString.val(), goodAnswer.val());
            inputString.val('');
        }
    });

    $("#getAnotherRandomQuestion").click(function (event) {
        RefreshDataOnWebsite();
    });

    function RefreshDataOnWebsite() {
        var continent = $("#Continent").val();
        var guessType = $("#GuessType").val();

        var dataToSend = 'Continent=' + continent + "&GuessType=" + guessType;

        AddAnswerToHistory(question.text(), inputString.val(), goodAnswer.val());

        $.ajax({
            url: `/Question/RandomAnotherQuestion`,
            type: 'get',
            data: dataToSend,
            success: function (data) {
                question.text(data.questionText);
                goodAnswer.val(data.answerText);

                console.log(goodAnswer.val())
            },
            error: function (data) {
                toastr["error"]("Something went wrong")
            }
        })
    }

    function AddAnswerToHistory(question, userAnswer, goodAnswer) {
        var answerHistory = $("#answerHistory");

        if (userAnswer == goodAnswer) {
            var nextLi = $("<li></li>").text(question + " => " + userAnswer).css('color', 'green');
            answerHistory.append(nextLi);
        } else {
            var nextLi = $("<li></li>").text(question + " => " + userAnswer).css('color', 'red');
            answerHistory.append(nextLi);
        }
    };
});