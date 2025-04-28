
import { questionsPerStep } from './progressUpdater.js';

export const questions = [
    {
        id: 1,
        question: "được gửi đến, được chuyển đến",
        answers: [
            { text: "ちょきんします (貯金します)", isCorrect: false },
            { text: "やせます (痩せます)", isCorrect: false },
            { text: "ふとります (太ります)", isCorrect: false },
            { text: "とどきます (届きます)", isCorrect: true },
        ]
    },

    {
        id: 2,
        question: "rắc rối, khó xử, có vấn đề",
        answers: [
            { text: "付けます（つけます", isCorrect: false },
            { text: "咲きます（さきます)", isCorrect: false },
            { text: "困ります（こまります)", isCorrect: true },
            { text: "拾います（ひろいます)", isCorrect: false },
        ]
    },

    {
        id: 3,
        question: "nở (hoa)",
        answers: [
            { text: "付けます（つけます", isCorrect: false },
            { text: "咲きます（さきます)", isCorrect: true },
            { text: "困ります（こまります)", isCorrect: false },
            { text: "拾います（ひろいます)", isCorrect: false },
        ]
    },

    {
        id: 4,
        question: "giảm cân",
        answers: [
            { text: "やせます (痩せます)", isCorrect: true },
            { text: "ふとります (太ります)", isCorrect: false },
            { text: "とどきます (届きます)", isCorrect: false },
            { text: "ちょきんします (貯金します)", isCorrect: false },
        ]
    },
    {
        id: 5,
        question: "bị béo lên",
        answers: [
            { text: "ふとります (太ります)", isCorrect: true },
            { text: "やせます (痩せます)", isCorrect: false },
            { text: "こまります (困ります)", isCorrect: false },
            { text: "つけます (付けます)", isCorrect: false },
        ]
    },
    {
        id: 6,
        question: "gửi tiết kiệm",
        answers: [
            { text: "ちょきんします (貯金します)", isCorrect: true },
            { text: "とどきます (届きます)", isCorrect: false },
            { text: "ひろいます (拾います)", isCorrect: false },
            { text: "さきます (咲きます)", isCorrect: false },
        ]
    },
    {
        id: 7,
        question: "nhặt lên",
        answers: [
            { text: "拾います（ひろいます)", isCorrect: true },
            { text: "困ります（こまります)", isCorrect: false },
            { text: "太ります（ふとります)", isCorrect: false },
            { text: "痩せます（やせます)", isCorrect: false },
        ]
    },
    {
        id: 8,
        question: "bật (đèn, điều hòa...)",
        answers: [
            { text: "つけます（付けます)", isCorrect: true },
            { text: "けします（消します)", isCorrect: false },
            { text: "とどきます（届きます)", isCorrect: false },
            { text: "こまります（困ります)", isCorrect: false },
        ]
    },
    //{
    //    id: 9,
    //    question: "hỏng hóc, bị hư",
    //    answers: [
    //        { text: "こしょうします（故障します)", isCorrect: true },
    //        { text: "咲きます（さきます)", isCorrect: false },
    //        { text: "付けます（つけます)", isCorrect: false },
    //        { text: "拾います（ひろいます)", isCorrect: false },
    //    ]
    //},
    //{
    //    id: 10,
    //    question: "học tập",
    //    answers: [
    //        { text: "べんきょうします（勉強します)", isCorrect: true },
    //        { text: "遊びます（あそびます)", isCorrect: false },
    //        { text: "働きます（はたらきます)", isCorrect: false },
    //        { text: "寝ます（ねます)", isCorrect: false },
    //    ]
    //},
    //{
    //    id: 11,
    //    question: "chơi, vui chơi",
    //    answers: [
    //        { text: "あそびます（遊びます)", isCorrect: true },
    //        { text: "べんきょうします（勉強します)", isCorrect: false },
    //        { text: "寝ます（ねます)", isCorrect: false },
    //        { text: "飲みます（のみます)", isCorrect: false },
    //    ]
    //},
    //{
    //    id: 12,
    //    question: "ngủ",
    //    answers: [
    //        { text: "ねます（寝ます)", isCorrect: true },
    //        { text: "おきます（起きます)", isCorrect: false },
    //        { text: "べんきょうします（勉強します)", isCorrect: false },
    //        { text: "はたらきます（働きます)", isCorrect: false },
    //    ]
    //},
    //{
    //    id: 13,
    //    question: "dậy (thức dậy)",
    //    answers: [
    //        { text: "おきます（起きます)", isCorrect: true },
    //        { text: "寝ます（ねます)", isCorrect: false },
    //        { text: "遊びます（あそびます)", isCorrect: false },
    //        { text: "飲みます（のみます)", isCorrect: false },
    //    ]
    //},
    //{
    //    id: 14,
    //    question: "tắt (đèn, điều hòa...)",
    //    answers: [
    //        { text: "けします（消します)", isCorrect: true },
    //        { text: "つけます（付けます)", isCorrect: false },
    //        { text: "ちょきんします（貯金します)", isCorrect: false },
    //        { text: "ひろいます（拾います)", isCorrect: false },
    //    ]
    //},
];

export function getQuestionsForStep(stepIndex) {
    const start = stepIndex * questionsPerStep;
    const end = start + questionsPerStep;
    return questions.slice(start, end);
}

