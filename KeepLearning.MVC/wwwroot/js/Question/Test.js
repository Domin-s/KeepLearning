$(document).ready(function () {
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

        $.post(`/Question/CheckTest`, dataToSend, (data, status) => {
            console.log(data);
        });
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