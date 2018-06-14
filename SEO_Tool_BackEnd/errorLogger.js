const fs = require('fs');
const dataModel = require('./dataModel').DataModel;
module.exports = (err)=>{
    let data = new dataModel(0, err.message);

    fs.writeFile('../../../../../data.json', JSON.stringify(data), "utf8", (e)=>{
  });
};