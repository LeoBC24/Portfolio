const dummy = (blogs) => {
    return 1
  }


  const totalLikes = (blogs) => {
    return blogs.reduce((sum, blog) => sum + blog.likes, 0)
  }
  
  const favoriteBlog = (blogs) => {
    if (blogs.length === 0) {
      return null  // Return null if the list is empty
    }
  
    return blogs.reduce((maxBlog, currentBlog) => {
      return currentBlog.likes > maxBlog.likes ? currentBlog : maxBlog
    })
  }
  
  const mostBlogs = (blogs) => {
    if (blogs.length === 0) {
      return null  // Return null if there are no blogs
    }
  
    const authorBlogCount = blogs.reduce((authorCounts, blog) => {
      authorCounts[blog.author] = (authorCounts[blog.author] || 0) + 1
      return authorCounts
    }, {})
  
    const mostBlogsAuthor = Object.entries(authorBlogCount)
      .reduce((max, current) => {
        return current[1] > max[1] ? current : max
      })
  
    return {
      author: mostBlogsAuthor[0],
      blogs: mostBlogsAuthor[1]
    }
  }
  
  const mostLikes = (blogs) => {
    if (blogs.length === 0) {
      return null  // Return null if there are no blogs
    }
  
    // Accumulate likes per author
    const authorLikeCount = blogs.reduce((authorCounts, blog) => {
      authorCounts[blog.author] = (authorCounts[blog.author] || 0) + blog.likes
      return authorCounts
    }, {})
  
    // Find the author with the maximum total likes
    const mostLikesAuthor = Object.entries(authorLikeCount)
      .reduce((max, current) => {
        return current[1] > max[1] ? current : max
      })
  
    return {
      author: mostLikesAuthor[0],
      likes: mostLikesAuthor[1]
    }
  }
  
  module.exports = {
    dummy,
    totalLikes,
    favoriteBlog,
    mostBlogs,
    mostLikes
  }