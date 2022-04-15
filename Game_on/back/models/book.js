var mongoose = require("mongoose")
var Schema = mongoose.Schema

var BookSchema = new Schema({
    title: {type: String, required: true},
    yearOfPublication: {type: Number, required: true},
    author: {type: String, required: true}
})

// BookSchema.virtual('name').get(()=>{
//     return this.author.subStrig(0, indexOf(' '))
// })

var BookModel = mongoose.model('book', BookSchema)

BookModel.sacuvaj = function sacuvaj(reqBook){
    var book = new BookModel({
        title: reqBook.title,
        yearOfPublication: reqBook.yearOfPublication,
        author: reqBook.author
    })

    book.save((err)=>{
        if(err)
            console.log(err.stack)
    })

    return book
}

module.exports = BookModel
