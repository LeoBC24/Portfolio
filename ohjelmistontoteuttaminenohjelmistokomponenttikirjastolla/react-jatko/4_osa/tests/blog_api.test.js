const mongoose = require('mongoose')
const supertest = require('supertest')
const app = require('../app')
const Blog = require('../models/blog')
const api = supertest(app)

beforeAll(async () => {
  const mongoUrl = 'mongodb+srv://LeoFullStack:Single1Word@phonebook.oyndo8t.mongodb.net/bloglist?retryWrites=true&w=majority&appName=blogs'
  await mongoose.connect(mongoUrl)
})

beforeEach(async () => {
  await Blog.deleteMany({})

  const initialBlogs = [
    {
      title: 'First Blog',
      author: 'Tester One',
      url: 'http://example.com/1',
      likes: 1,
    },
    {
      title: 'Second Blog',
      author: 'Tester Two',
      url: 'http://example.com/2',
      likes: 2,
    },
  ]

  await Blog.insertMany(initialBlogs)
})

test('blogs are returned as json and correct length', async () => {
  const response = await api
    .get('/api/blogs')
    .expect(200)
    .expect('Content-Type', /application\/json/)

  expect(response.body).toHaveLength(2)
})

test('blog posts have an id field instead of _id', async () => {
  const response = await api.get('/api/blogs')
  const blog = response.body[0]

  expect(blog.id).toBeDefined()
  expect(blog._id).toBeUndefined()
})
test('a valid blog can be added', async () => {
    const newBlog = {
      title: 'New Blog Post',
      author: 'Author Tester',
      url: 'http://example.com/new',
      likes: 5
    }
  
    // POST the new blog
    await api
      .post('/api/blogs')
      .send(newBlog)
      .expect(201)
      .expect('Content-Type', /application\/json/)
  
 
    const response = await api.get('/api/blogs')
  
  
    expect(response.body).toHaveLength(3)
  
  
    const titles = response.body.map(r => r.title)
    expect(titles).toContain('New Blog Post')
  })
  test('if likes property is missing, it defaults to 0', async () => {
    const newBlog = {
      title: 'Blog without likes',
      author: 'No Likes Author',
      url: 'http://example.com/nolikes',
    }
  
    const response = await api
      .post('/api/blogs')
      .send(newBlog)
      .expect(201)
      .expect('Content-Type', /application\/json/)
  
    expect(response.body.likes).toBe(0)
  })
  test('blog without title is not added', async () => {
    const newBlog = {
      author: 'Missing Title',
      url: 'http://example.com/missingtitle',
      likes: 1,
    }
  
    await api
      .post('/api/blogs')
      .send(newBlog)
      .expect(400)
  
    const blogsAtEnd = await api.get('/api/blogs')
    expect(blogsAtEnd.body).toHaveLength(2)
  })
  
  test('blog without url is not added', async () => {
    const newBlog = {
      title: 'Missing URL',
      author: 'Missing Url Author',
      likes: 1,
    }
  
    await api
      .post('/api/blogs')
      .send(newBlog)
      .expect(400)
  
    const blogsAtEnd = await api.get('/api/blogs')
    expect(blogsAtEnd.body).toHaveLength(2)
  })
  test('a blog can be deleted', async () => {
    const blogsAtStart = await api.get('/api/blogs')
    const blogToDelete = blogsAtStart.body[0]
  
    await api
      .delete(`/api/blogs/${blogToDelete.id}`)
      .expect(204)
  
    const blogsAtEnd = await api.get('/api/blogs')
  
    expect(blogsAtEnd.body).toHaveLength(blogsAtStart.body.length - 1)
    const titles = blogsAtEnd.body.map(b => b.title)
    expect(titles).not.toContain(blogToDelete.title)
  })
  test('a blog post can be updated', async () => {
    const blogsAtStart = await api.get('/api/blogs')
  
    const blogToUpdate = blogsAtStart.body[0]
    const updatedBlog = {
      likes: blogToUpdate.likes + 1,
    }
  
    const response = await api
      .put(`/api/blogs/${blogToUpdate.id}`)
      .send(updatedBlog)
      .expect(200)
      .expect('Content-Type', /application\/json/)
  
    expect(response.body.likes).toBe(blogToUpdate.likes + 1)
  
    const blogsAtEnd = await api.get('/api/blogs')
    const updatedBlogInDb = blogsAtEnd.body.find(blog => blog.id === blogToUpdate.id)
  
    expect(updatedBlogInDb.likes).toBe(blogToUpdate.likes + 1)
  })
  
afterAll(async () => {
  await mongoose.connection.close()
})
