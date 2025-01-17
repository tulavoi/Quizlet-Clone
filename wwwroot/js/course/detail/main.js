
// Import functions from flashcardsPartial.js
import {
    cards,
    currIndexCard,
    setupClickEventForCard,
    pressKeyToFlipCard,
    toggleShuffle
} from './modules/flashcardsPartial.js';

setupClickEventForCard();
pressKeyToFlipCard();

// Import functions from flashcardAction.js
import { textToSpeech } from './modules/flashcardAction.js';

// Import functions from starredFlashcard.js
import { starredFlashcard } from './modules/starredFlashcard.js';

// Import functions from flashcardsOptionsModal.js
import { resetCards } from './modules/flashcardsOptionsModal.js';

