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
            percentage:roundPlus((tempArr[e]/wordsArray.length)*100, 3)
        });
    });

    return finalArr.slice(0, CalcStopWord(finalArr));
}

function CalcStopWord(wordsArray) {
    let percSum = wordsArray.reduce((sum, currentItem)=>{
        return sum+currentItem.percentage
    }, 0);

    let averagePercentage =
        percSum / wordsArray.length;

    return closest(averagePercentage, wordsArray);
}
function roundPlus(x, n) { //x - число, n - количество знаков
    if(isNaN(x) || isNaN(n)) return false;
    let m = Math.pow(10,n);
    return Math.round(x*m)/m;
}
function closest (num, arr) {
    let curr = arr[0];
    let index;
    let diff = Math.abs (num - curr.percentage);
    for (let val = 0; val < arr.length; val++) {
        let newdiff = Math.abs (num - arr[val].percentage);
        if (newdiff < diff) {
            diff = newdiff;
            curr = arr[val];
            index = val;
        }
    }
    return index;
}