
import { addNewCard } from './modules/addNewCard.js';

import {  } from './modules/toggleContainer.js';

import { } from './modules/importFlashcardPartial.js';

import { bindTrashButtonEvent } from './modules/trashButtonEvent.js';

import { } from './modules/termSection.js';

import { } from './modules/courseSettingModal.js';

import { } from './modules/syncSelectsByType.js';

import { } from './modules/reverseTerm.js';

import { } from './modules/courseSettingModal.js';

document.addEventListener('DOMContentLoaded', function () {
    $(window).on('scroll', function () {
        var scrollTop = $(window).scrollTop();
        var header = $('#course-form-header');

        // Kiểm tra vị trí cuộn, nếu cuộn xuống thì thêm class fixed-top
        if (scrollTop > 100) {
            header.addClass('fixed-top');
        } else {
            header.removeClass('fixed-top');
        }
    });
});