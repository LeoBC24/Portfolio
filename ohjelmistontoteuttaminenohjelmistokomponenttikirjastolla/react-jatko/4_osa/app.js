const express = require('express')
const Blog = require('./models/blog')
const app = express()

app.use(express.json())

app.get('/api/blogs', async (request, response) => {
  const blogs = await Blog.find({})
  response.json(blogs)
})

  
app.post('/api/blogs', async (request, response) => {
  try {
    const { title, url } = request.body

    if (!title || !url) {
      return response.status(400).json({ error: 'title and url are required' })
    }

    const blog = new Blog({
      ...request.body,
      likes: request.body.likes || 0,
    })

    const savedBlog = await blog.save()
    response.status(201).json(savedBlog)
  } catch (error) {
    response.status(400).json({ error: error.message })
  }
})

app.delete('/api/blogs/:id', async (request, response) => {
  try {
    await Blog.findByIdAndDelete(request.params.id)
    response.status(204).end()
  } catch (error) {
    response.status(400).json({ error: error.message })
  }
})
app.put('/api/blogs/:id', async (request, response) => {
  const { id } = request.params
  const { likes } = request.body

  try {
    const updatedBlog = await Blog.findByIdAndUpdate(id, { likes }, { new: true })

    if (!updatedBlog) {
      return response.status(404).json({ error: 'Blog not found' })
    }

    response.json(updatedBlog)
  } catch (error) {
    response.status(400).json({ error: error.message })
  }
})



module.exports = app