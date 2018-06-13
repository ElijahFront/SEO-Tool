let w = new Promise((resolve, reject)=>{
    let words = [];
    const request = require('request');
    const cheerio = require('cheerio');
    //const windows1251 = require('windows-1251');
    // const jschardet = require("jschardet");

    let url = process.argv[2] != undefined ? process.argv[2] : "https://api.jquery.com/contents/";

    const options = {
        uri: url,
        method: 'GET',
        encoding: 'binary'
    };

    request(url, (err, response, html)=>{
        if(err){
            reject(err);
        }else{
            // let encoding = jschardet.detect(new Buffer(html, 'binary').toString('binary')).encoding;
            // if(encoding == "windows-1251" || encoding == "windows-1252"){
            //     reject({message:"The site has encoding that our service cannot work with: " + encoding + ". Please contact your webmaster to solve this issue"});
            // }

        let $ = cheerio.load(html);
        $('*').not('script').not('style').contents().each((i, el)=>{
            if(el.nodeType == 3){
                let elWithoutTabs = el.nodeValue.trim();
                let elWithoutNewLines = elWithoutTabs.replace(/\n/g, "");
                elWithoutNewLines = elWithoutNewLines.toLowerCase();
                elWithoutNewLines = elWithoutNewLines.replace(/(\r\n|\n|\r)/gm, "");
                elWithoutNewLines = elWithoutNewLines.replace(/"/g, "");
                elWithoutNewLines = elWithoutNewLines.replace(/[\),\(]/g, ""); ///\bde\b/g
                wordsArrFromTextNode = elWithoutNewLines.replace(/,/gm, "").split(" ");
                wordsArrFromTextNode.forEach((item, i)=>{
                    if(isWordOk(item)){
                        words.push(item);
                    }
                });
            }
        });

    }
        resolve(words);
    });
    function hasNumber(myString) {
        return /\d/.test(myString);
    }
    function getTextWithoutChildNodes(jqEl) {
        return jqEl.clone()
            .children()
            .remove()
            .end()
            .text();
    }
    function isWordOk(word) {
        let forbiddenWords = ["the","that","this","for","these","with","their","also","и","and","или","or","a","an","are","is","which","will",
            "would","как","только","а","так","также","у","в","около","возле",".",",",";","для","это","над","под","уже","нет","тех","что",
        "того","который","которую","эту",
        "оно","они","она","которых"];

        return (word != "" && word.length >=3 && !hasNumber(word) && !forbiddenWords.includes(word));

    }

});

exports.words = w;