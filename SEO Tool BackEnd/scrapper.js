let w = new Promise((resolve, reject)=>{
    let words = [];
    const request = require('request');
    const cheerio = require('cheerio');
    //const windows1251 = require('windows-1251');

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

            //html = new Buffer(html, 'binary');
            //const text = html.toString('binary').windows1251.decode(html);

        let $ = cheerio.load(html);
        $('*').not('script').not('style').contents().each((i, el)=>{
            if(el.nodeType == 3){

                let elWithoutTabs = el.nodeValue.trim();
                let elWithoutNewLines = elWithoutTabs.replace(/\n/g, "");
                elWithoutNewLines = elWithoutNewLines.replace(/(\r\n|\n|\r)/gm, "");
                elWithoutNewLines = elWithoutNewLines.replace(/"/g, "");
                wordsArrFromTextNode = elWithoutNewLines.replace(/,/gm, "").split(" ");
                wordsArrFromTextNode.forEach((item, i)=>{
                    if(item != '' && item.length >=3 && !hasNumber(item) && item != "и" && item != "and" && item != "или" && item != "the"
                        && item != "a" && item != "are" && item != "which"){
                        words.push(item);
                    }
                });
            }
            resolve(words);
        });
        function hasNumber(myString) {
            return /\d/.test(myString);
        }
    }

    });


        function getTextWithoutChildNodes(jqEl) {
            return jqEl.clone()
                .children()
                .remove()
                .end()
                .text();
        }


});

exports.words = w;