document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()

})

function handleProfileImageUpload() {
    try {
        let fileUploader = document.querySelector('#fileUploader')

        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {

                if (this.files.lenght > 0) {
                    this.form.submit()
                }
            })
        }

    }
    catch { }
}