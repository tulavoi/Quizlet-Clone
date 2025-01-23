
// Import functions from flashcardsPartial.js
import { setupClickEventForCard, pressKeyToFlipCard } from './modules/flashcardsPartial.js';

setupClickEventForCard();
pressKeyToFlipCard();

// Import functions from flashcardAction.js
import { textToSpeech } from './modules/flashcardAction.js';

// Import functions from starredFlashcard.js
import { starredFlashcard, starredFlashcards } from './modules/starredFlashcard.js';

// Import functions from flashcardsOptionsModal.js
import { resetCards } from './modules/flashcardsOptionsModal.js';

// Import functions from congratulation.js
import { backToLastCard, resetFlashcards } from './modules/congratulation.js';

