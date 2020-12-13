var pathName = window.location.pathname;
var search = window.location.search;

fetch(pathName + search)
    .then(response => {
        var $make = $('#makes'),
            $model = $('#models'),
            $options = $model.find('option');

        $make.on('change', function () {
            $model.html($options.filter('[value="' + this.value + '"]'));
        }).trigger('change');
    });

fetch(pathName + search)
    .then(response => {
        var $singlebutton = $('#singlebutton');
        var $selectedModel = document.getElementById('models');

        $singlebutton.on('click', function () {
            document.getElementById("Model").value = $selectedModel.options[$selectedModel.selectedIndex].text;
        });
    });