$(document).ready(function () {

    $("#checkAnswers").click(function (event) {
        CheckAnswers();
    });

    function CheckAnswers() {
        var guessType = $("#GuessType").val();
        var dataToSend = 'Question=' + question.text() + "&Answer=" + answer.val() + "&GuessType=" + guessType;

        $.ajax({
            url: `/Question/CheckTest`,
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
});