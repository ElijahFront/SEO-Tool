let words = require("./scrapper");
const jsonWriter = require('./jsonWriter');
const errLogger = require('./errorLogger');

words.words.then((res)=>{
    jsonWriter(countWords(res));
}, (err)=>{
     errLogger(err); // TODO: add decent logger
});

function countWords(wordsArray) {
    let tempArr = {};
    let finalArr = [];
    wordsArray.forEach((e)=>{
        if(!(e in tempArr)){
            tempArr[e] = 1;
        }else{
            tempArr[e] = tempArr[e] +1;
        }
    });
    keysSorted = Object.keys(tempArr).sort(function(a,b){return tempArr[b]-tempArr[a]});

    keysSorted.forEach((e)=>{
        finalArr.push({
            word:e,
            count:tempArr[e],
            percentage:(tempArr[e]/wordsArray.length)*100
        });
    });

    return finalArr;
}