const fs = require('fs');

module.exports = (data) =>{

    let jsonData = JSON.stringify(data);

    fs.writeFile("../data.json", jsonData, "utf8", (err)=>{
        if(err) console.log(err);

    });

};