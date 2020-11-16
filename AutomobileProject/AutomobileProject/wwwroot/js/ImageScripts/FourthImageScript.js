const fourthImage = document.getElementById("fourthImage");
const fourthPreviewContainer = document.getElementById("fourthImagePreview");
const fourthPreviewImage = fourthPreviewContainer.querySelector(".fourthImage-preview__image");
const fourthPreviewDefaultText = fourthPreviewContainer.querySelector(".fourthImage-preview__default-text");

fourthImage.addEventListener("change", function () {
    const file = this.files[0];

    if (file) {
        const reader = new FileReader();

        fourthPreviewDefaultText.style.display = "none";
        fourthPreviewImage.style.display = "block";

        reader.addEventListener("load", function () {
            fourthPreviewImage.setAttribute("src", this.result);
        });

        reader.readAsDataURL(file);
    }
})