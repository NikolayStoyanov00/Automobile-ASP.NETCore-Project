fetch('/Offer/AddCar')
    .then(response => {
        var $make = $('#makes'),
            $model = $('#models'),
            $options = $model.find('option'),
            $hiddenModel = $('#Model');

        $make.on('change', function () {
            $model.html($options.filter('[value="' + this.value + '"]'));
            $model.trigger('change');
        }).trigger('change');
    });

fetch('/Offer/AddCar')
    .then(response => {
        var $singlebutton = $('#singlebutton');
        var $selectedModel = document.getElementById('models');

        $singlebutton.on('click', function () {
            document.getElementById("Model").value = $selectedModel.options[$selectedModel.selectedIndex].text;
            console.log(document.getElementById("Model").textContent);
        });
    });