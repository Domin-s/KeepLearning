$(document).ready(function () {
    var continentSelect = $('.continentSelect');
    var continentRows = $('.continent');

    continentSelect.click(function (event) {
        HideOrShowContinents(continentSelect, continentRows);
    });

    function HideOrShowContinents(continents) {
        for (let i = 0; i < continents.length; i++) {
            var continentnName = GetFirstPartOfContientName(continents.get(i));
            var rows = $('.' + continentnName);
            var isChecked = continents.get(i).checked

            HideOrShowRowsWithCountry(isChecked, rows);
        }
    }

    function GetFirstPartOfContientName(continent) {
        return continent.value.split(/(\s+)/)[0];
    }

    function HideOrShowRowsWithCountry(isChecked, rows) {
        if (isChecked) {
            rows.show();
        } else {
            rows.hide();
        }
    }
});