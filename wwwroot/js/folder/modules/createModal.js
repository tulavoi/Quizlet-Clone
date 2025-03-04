import { postData } from '../../shared/postData.js';

const folderTitleInput = document.getElementById('folderName');
let btnCreateFolder = document.getElementById('createFolderBtn');

folderTitleInput.addEventListener('input', function () {
    if (this.value.trim() !== '') {
        btnCreateFolder.classList.add('btn-active');
    } else {
        btnCreateFolder.classList.remove('btn-active');
    }
});