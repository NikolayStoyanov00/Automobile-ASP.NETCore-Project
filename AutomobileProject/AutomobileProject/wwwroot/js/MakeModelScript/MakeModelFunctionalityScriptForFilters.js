fetch('/Cars/AllCars')
    .then(response => {
        var $make = $('#makes'),
            $model = $('#models'),
            $options = $model.find('option'),
            $select = document.getElementById("models"),
            $all = document.getElementById("all");

        $make.on('change', function () {
            $model.html($options.filter('[value="' + this.value + '"]'));
            $select.add($all, $select[0]);
            $all.attr('selected', 'selected');
            $model.trigger('change');
        }).trigger('change');
    });

fetch('/Cars/AllCars')
    .then(response => {
        var $submitButton = $('#submitButton');
        var $selectedModel = document.getElementById('models');

        $submitButton.on('click', function () {
            document.getElementById("Model").value = $selectedModel.options[$selectedModel.selectedIndex].text;
        });
    });