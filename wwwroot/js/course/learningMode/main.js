
import { } from '../../shared/btnOptionsDropdown.js';
import { } from './modules/settingPanel/settingPanelEvents.js';

import { initQuizState } from './modules/quiz/quizState.js';
initQuizState();

import { renderLearningProgess } from './modules/progressBar/learningProgress/progressRenderer.js';
renderLearningProgess();

import { renderUI } from './modules/uiHandler.js';
renderUI();
