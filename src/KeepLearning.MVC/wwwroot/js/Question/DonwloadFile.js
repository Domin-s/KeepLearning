$(document).ready(function () {

    var downloadPDF = $("#downloadPDF");
    var downloadWord = $("#downloadWord");

    downloadPDF.click(function (event) {
        DownloadPDF();
    });

    downloadWord.click(function (event) {
        DownloadWord();
    });

    function DownloadPDF() {
        var dataToSend = CreateDataToSend();

        $.post(`/Question/DownloadPDF`, dataToSend, (result, status) => {
            console.log("status: " + status);
            console.log(result);
        });
    }

    function DownloadWord() {
        var dataToSend = CreateDataToSend();

        $.post(`/Question/DownloadWord`, dataToSend, (result, status) => {
            console.log("status: " + status);
            console.log(result);
        });
    }

    class Test {
        constructor(name, numberOfQuestion, category, continents, question) {
            this.Name = name;
            this.NumberOfQuestion = numberOfQuestion;
            this.Question = question;
            this.Category = category;
            this.Continents = continents;
        }
    }

    class Question {
        constructor(numberOfQuestion, questionText) {
            this.NumberOfQuestion = numberOfQuestion;
            this.QuestionText = questionText;
        }
    }

    function CreateDataToSend() {
        var name = $("#Name").val();
        var numberOfQuestion = $("#NumberOFQuestion").val();
        var category = $("#Category").val();
        var continents = $("#Continents");
        var questions = $(".Question");

        var questionsToSend = CreateQuestionsToSend(questions);

        return new Test(name, numberOfQuestion, category, continents, questionsToSend);
    }

    function CreateQuestionsToSend(questions) {
        var result = [];

        for (let i = 0; i < questions.length; i++) {
            var element = CreateOneQuestionToSend(questions[i]);

            result.push(element);
        }

        return result;
    }

    function CreateOneQuestionToSend(question) {
        var numberOfQuestion = question.children[0].children[1].value;
        var questionText = question.children[1].children[1].value;

        return new Question(numberOfQuestion, questionText);
    }
});