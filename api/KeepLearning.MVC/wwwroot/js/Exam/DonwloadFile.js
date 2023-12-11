$(document).ready(function () {

    var downloadPDF = $("#downloadPDF");
    var downloadWord = $("#downloadWord");

    downloadPDF.click(function (event) {
        Download("pdf");
    });

    downloadWord.click(function (event) {
        Download("word");
    });

    function Download(fileType) {
        var dataToSend = CreateDataToSend(fileType);

        $.post(`/Question/Download`, dataToSend, (result, status) => {
            console.log("status: " + status);
            console.log(result);
        });
    }

    class TestToDownload {
        constructor(name, numberOfQuestion, category, continents, question, fileType) {
            this.Name = name;
            this.NumberOfQuestion = numberOfQuestion;
            this.Question = question;
            this.Category = category;
            this.Continents = continents;
            this.FileType = fileType;
        }
    }

    class Question {
        constructor(numberOfQuestion, questionText) {
            this.NumberOfQuestion = numberOfQuestion;
            this.QuestionText = questionText;
        }
    }

    function CreateDataToSend(fileType) {
        var name = $("#Name").val();
        var numberOfQuestion = $("#NumberOFQuestion").val();
        var category = $("#Category").val();
        var continents = $("#Continents");
        var questions = $(".Question");

        var questionsToSend = CreateQuestionsToSend(questions);

        var testToDownload = new TestToDownload(
            name,
            numberOfQuestion,
            category,
            continents,
            questionsToSend,
            fileType
        );

        return testToDownload
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