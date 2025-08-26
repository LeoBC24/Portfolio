const app = require('./app')
const mongoose = require ('mongoose')

const mongoUrl= 'mongodb+srv://LeoFullStack:Single1Word@phonebook.oyndo8t.mongodb.net/bloglist?retryWrites=true&w=majority&appName=blogs'

mongoose.connect(mongoUrl)
  .then(() => {
    console.log('Connected to MongoDB')
  })
  .catch((error) => {
    console.error('Error connecting to MongoDB:', error.message)
  })

const PORT = 3003
app.listen(PORT, () => {
  console.log(`Server running at http://localhost:${PORT}/api/blogs`)
})