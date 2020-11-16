const fifthImage = document.getElementById("fifthImage");
const fifthPreviewContainer = document.getElementById("fifthImagePreview");
const fifthPreviewImage = fifthPreviewContainer.querySelector(".fifthImage-preview__image");
const fifthPreviewDefaultText = fifthPreviewContainer.querySelector(".fifthImage-preview__default-text");

fifthImage.addEventListener("change", function () {
    const file = this.files[0];

    if (file) {
        const reader = new FileReader();

        fifthPreviewDefaultText.style.display = "none";
        fifthPreviewImage.style.display = "block";

        reader.addEventListener("load", function () {
            fifthPreviewImage.setAttribute("src", this.result);
        });

        reader.readAsDataURL(file);
    }
})