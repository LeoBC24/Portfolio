const listHelper = require('../utils/list_helper')

describe('mostLikes', () => {
  const listWithOneBlog = [
    {
      _id: '5a422aa71b54a676234d17f8',
      title: 'Go To Statement Considered Harmful',
      author: 'Edsger W. Dijkstra',
      url: 'https://homepages.cwi.nl/~storm/teaching/reader/Dijkstra68.pdf',
      likes: 5,
      __v: 0
    }
  ]

  test('when list has only one blog, returns the author with the likes of that blog', () => {
    const result = listHelper.mostLikes(listWithOneBlog)
    expect(result).toEqual({ author: 'Edsger W. Dijkstra', likes: 5 })
  })

  const listWithMultipleBlogs = [
    {
      _id: '1',
      title: 'First Post',
      author: 'John Doe',
      url: 'https://example.com/first',
      likes: 10,
      __v: 0
    },
    {
      _id: '2',
      title: 'Second Post',
      author: 'Jane Smith',
      url: 'https://example.com/second',
      likes: 5,
      __v: 0
    },
    {
      _id: '3',
      title: 'Third Post',
      author: 'John Doe',
      url: 'https://example.com/third',
      likes: 20,
      __v: 0
    }
  ]

  test('when list has multiple blogs, returns the author with the most likes', () => {
    const result = listHelper.mostLikes(listWithMultipleBlogs)
    expect(result).toEqual({ author: 'John Doe', likes: 30 })
  })

  const listWithTiedAuthors = [
    {
      _id: '1',
      title: 'A',
      author: 'Author A',
      url: 'https://example.com/a',
      likes: 10,
      __v: 0
    },
    {
      _id: '2',
      title: 'B',
      author: 'Author B',
      url: 'https://example.com/b',
      likes: 10,
      __v: 0
    }
  ]

  test('when there is a tie, returns one of the top authors', () => {
    const result = listHelper.mostLikes(listWithTiedAuthors)
    expect(['Author A', 'Author B']).toContain(result.author)
    expect(result.likes).toBe(10)
  })
})
