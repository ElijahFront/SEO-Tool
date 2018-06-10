let w = new Promise((resolve, reject)=>{
    let words = [];
    const request = require('request');
    const cheerio = require('cheerio');
    //const windows1251 = require('windows-1251');
    const jschardet = require("jschardet");

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
            let encoding = jschardet.detect(new Buffer(html, 'binary').toString('binary')).encoding;
            if(encoding == "windows-1251" || encoding == "windows-1252"){
                reject({message:"The site has encoding that our service cannot work with: " + encoding + "please contact your webmaster to solve this issue"});
            }

        let $ = cheerio.load(html);
        $('*').not('script').not('style').contents().each((i, el)=>{
            if(el.nodeType == 3){

                let elWithoutTabs = el.nodeValue.trim();
                let elWithoutNewLines = elWithoutTabs.replace(/\n/g, "");
                elWithoutNewLines = elWithoutNewLines.replace(/(\r\n|\n|\r)/gm, "");
                elWithoutNewLines = elWithoutNewLines.replace(/"/g, "");
                elWithoutNewLines = elWithoutNewLines.replace(/[\),\(]/g, ""); ///\bde\b/g
                elWithoutNewLines = elWithoutNewLines.replace(/(the|that|this|for|these|with|their|also|и|and|или|or|a|an|are|is|which|will|would|как|только|а|так|также|у|в|около|возле|.|,|;)\b/ig, "");
                wordsArrFromTextNode = elWithoutNewLines.replace(/,/gm, "").split(" ");
                wordsArrFromTextNode.forEach((item, i)=>{
                    if(item != '' && item.length >=3 && !hasNumber(item)){
                        words.push(item);
                    }
                });
            }

        });
        function hasNumber(myString) {
            return /\d/.test(myString);
        }
    }
        resolve(words);
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