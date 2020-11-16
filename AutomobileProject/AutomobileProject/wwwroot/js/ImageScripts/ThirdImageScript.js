const thirdImage = document.getElementById("thirdImage");
const thirdPreviewContainer = document.getElementById("thirdImagePreview");
const thirdPreviewImage = thirdPreviewContainer.querySelector(".thirdImage-preview__image");
const thirdPreviewDefaultText = thirdPreviewContainer.querySelector(".thirdImage-preview__default-text");

thirdImage.addEventListener("change", function () {
    const file = this.files[0];

    if (file) {
        const reader = new FileReader();

        thirdPreviewDefaultText.style.display = "none";
        thirdPreviewImage.style.display = "block";

        reader.addEventListener("load", function () {
            thirdPreviewImage.setAttribute("src", this.result);
        });

        reader.readAsDataURL(file);
    }
})