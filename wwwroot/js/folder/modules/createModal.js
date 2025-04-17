
const folderTitleInput = document.getElementById('folderName');
let btnCreateFolder = document.getElementById('createFolderBtn');

if (folderTitleInput) {
    folderTitleInput.addEventListener('input', function () {
        if (this.value.trim() !== '') {
            btnCreateFolder.classList.add('btn-active');
        } else {
            btnCreateFolder.classList.remove('btn-active');
        }
    });
}