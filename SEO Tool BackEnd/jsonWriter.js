const fs = require('fs');
const dataModel = require('./dataModel').DataModel;
module.exports = (data) =>{
    let _data = new dataModel(1, data);
    //let jsonData = JSON.stringify(data);

    fs.writeFile("../data.json", JSON.stringify(_data, null, 4), "utf8", (err)=>{
        if(err) console.log(err);
    });
};