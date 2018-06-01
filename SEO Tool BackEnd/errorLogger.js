const fs = require('fs');
module.exports = (err)=>{
      fs.writeFile('../data.json', JSON.stringify({"error": err.message}), "utf8", (e)=>{

      });
};