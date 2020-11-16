const sixthImage = document.getElementById("sixthImage");
const sixthPreviewContainer = document.getElementById("sixthImagePreview");
const sixthPreviewImage = sixthPreviewContainer.querySelector(".sixthImage-preview__image");
const sixthPreviewDefaultText = sixthPreviewContainer.querySelector(".sixthImage-preview__default-text");

sixthImage.addEventListener("change", function () {
    const file = this.files[0];

    if (file) {
        const reader = new FileReader();

        sixthPreviewDefaultText.style.display = "none";
        sixthPreviewImage.style.display = "block";

        reader.addEventListener("load", function () {
            sixthPreviewImage.setAttribute("src", this.result);
        });

        reader.readAsDataURL(file);
    }
})