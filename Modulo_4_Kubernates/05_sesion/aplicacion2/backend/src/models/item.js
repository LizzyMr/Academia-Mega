const {Schema, model} = require('mongoose');

const itemSchema = new Schema({
    name: {type: String, required: true},
    price: {type: Number, required: true}
});

module.exports = model('Item', itemSchema);