
import { } from '../../shared/btnOptionsDropdown.js';
import { generateProgressStep } from './modules/progressUpdater.js';
generateProgressStep();

import { } from './modules/answerHandler.js';
import { } from './modules/helpButtonHandler.js';
import { } from './modules/progressOverview.js';
//updateProgressbar(); // Chỉ gọi hàm này khi hiển thị progress overview

import { showQuestion } from './modules/quizHandler.js';
showQuestion();

import { } from '../detail/modules/flashcardAction.js';
