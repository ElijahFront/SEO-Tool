const fs = require('fs');
const dataModel = require('./dataModel').DataModel;
module.exports = (err)=>{
    console.log("hello from errorLogger");
    let data = new dataModel(0, err.message);
    console.log(data);
    fs.writeFile('../../../../../data.json', JSON.stringify(data), "utf8", (e)=>{
        console.log(e);
  });
};