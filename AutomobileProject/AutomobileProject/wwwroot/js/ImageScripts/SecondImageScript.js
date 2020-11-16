const secondImage = document.getElementById("secondImage");
const secondPreviewContainer = document.getElementById("secondImagePreview");
const secondPreviewImage = secondPreviewContainer.querySelector(".secondImage-preview__image");
const secondPreviewDefaultText = secondPreviewContainer.querySelector(".secondImage-preview__default-text");

secondImage.addEventListener("change", function () {
    const file = this.files[0];

    if (file) {
        const reader = new FileReader();

        secondPreviewDefaultText.style.display = "none";
        secondPreviewImage.style.display = "block";

        reader.addEventListener("load", function () {
            secondPreviewImage.setAttribute("src", this.result);
        });

        reader.readAsDataURL(file);
    }
})